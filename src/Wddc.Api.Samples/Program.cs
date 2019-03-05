using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wddc.Api.Samples.Core;
using Flurl.Http;
using Flurl;
using System.Linq;
using System.Collections.Generic;

namespace Wddc.Api.Samples
{
    public class Program
    {
        protected static string CustomerId => "32922_WOOFTEST";
        protected static string ApiUrl => "http://localhost:49761/api/";

        public static void Main(string[] args)
        {
            // insert products asynchronously to WDDC's shopping cart
            InsertProductsAsync().Wait();

            // runs some different samples on how to interact with WDDC resources
            RunSamplesAsync().Wait();
        }

        #region Utilities

        /// <summary>
        /// Authenticates using WDDC's identity server https://is4.clientvantage.ca
        /// </summary>
        /// <returns>token response</returns>
        protected async static Task<TokenResponse> GetTokenResponseAsync()
        {
            var client = new HttpClient();

            // sends WDDC's identity server a discovery document request
            var disco = await client.GetDiscoveryDocumentAsync("https://is4.clientvantage.ca/");

            if (disco.IsError)
            {
                await Console.Error.WriteLineAsync(disco.Error);
                throw new Exception(disco.Error);
            }

            Console.WriteLine(JsonConvert.SerializeObject(disco, Formatting.Indented));

            // sends a token request to WDDC's identity server using the password grant type.
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "woofware_client", // client_id
                ClientSecret = "",  // your client_secret

                UserName = "woofware_test_user", // your username
                Password = "", // your password
                Scope = "api api_roles offline_access"
            });

            if (tokenResponse.IsError)
            {
                await Console.Error.WriteLineAsync(tokenResponse.Error);
                throw new Exception(tokenResponse.Error);
            }

            Console.WriteLine(tokenResponse.Json);

            return tokenResponse;
        }

        protected async static Task<AddToCartResult> InsertProductToCartAsync(TokenResponse tokenResponse, string productSku, int quantity)
        {
            return await ApiUrl
                .AppendPathSegment("ShoppingCart")
                .WithOAuthBearerToken(tokenResponse.AccessToken)
                .PostJsonAsync(new AddToCartRequest
                {
                    CustomerId = CustomerId,
                    ProductSku = productSku,
                    Quantity = quantity
                })
                .ReceiveJson<AddToCartResult>();
        }

        #endregion

        #region Actions

        public async static Task InsertProductsAsync()
        {
            #region 1. Authentication

            var tokenResponse = await GetTokenResponseAsync();

            #endregion

            #region 2. Add products

            // products that exist in WDDC and won't throw an error
            var goodProducts = new List<string> { "103158", "102680", "126089", "125133", "126231", "106497", "106508", "107170", "107267", "107268", "107269", "113272", "113273", "904967", "904968", "904969", "904970", "904971", "904972", "904973", "904974", "904975", "904976", "904977", "904978", "904979", "904980", "904981", "904983", "904984" };

            // products that are discontinued and will throw an erro
            var discontinuedProducts = new List<string> { "903354", "112501", "130918", "134949", "134954", "134948", "134956", "134953", "135030", "135038", "135033", "135037", "135065", "135458", "135459", "136893", "300748", "130999", "131289", "131206", "131290", "131291", "131293", "131294", "131295", "131297", "131209", "131213", "131214", "131247" };

            // unavailable products (we don't have stock and don't allow back orders)
            var tempUnavailableProducts = new List<string> { "137374", "137375", "907645", "907483", "134711", "128828", "129473", "128340", "130793", "130795", "130327", "130330", "130331", "125079", "123530", "128927", "121592", "123054", "123055", "906325", "122707", "122708", "122738", "122606", "123314", "123315", "123316", "123317", "905638", "122194" };

            // products that we don't carry
            var notFoundProducts = new List<string> { "someunlistedproduct1", "someunlistedproduct2", "someunlistedproduct3", "someunlistedproduct4", "someunlistedproduct5" };

            // union all the products above
            var productsToAdd = goodProducts
                .Union(discontinuedProducts)
                .Union(tempUnavailableProducts)
                .Union(notFoundProducts);

            // insert all products asynchronously
            var tasks = productsToAdd
                .Select(_ => InsertProductToCartAsync(tokenResponse, _, (new Random()).Next(0, 10)));

            // wait for all tasks to finish
            var results = await Task.WhenAll(tasks);

            // group results by error
            var grouping = results
                .GroupBy(
                    _ => new { _.Success, _.Error }, 
                    _ => _.ProductSku, 
                    (key, g) => new { key.Success, key.Error, Products = g.ToList() }
                );

            // products that were inserted
            Console.WriteLine(JsonConvert.SerializeObject(grouping.Where(_ => _.Success), Formatting.Indented));

            // products that had an error
            Console.WriteLine(JsonConvert.SerializeObject(grouping.Where(_ => !_.Success), Formatting.Indented));

            #endregion
        }

        public async static Task RunSamplesAsync()
        {
            #region 1. Authentication

            var tokenResponse = await GetTokenResponseAsync();

            #endregion

            #region 2. Add to shopping cart

            var addToCartResult = await InsertProductToCartAsync(tokenResponse, "103871", 5);

            Console.WriteLine(JsonConvert.SerializeObject(addToCartResult, Formatting.Indented));

            #endregion

            #region 3. Add discontinued product to cart

            try
            {
                // this tries to add a discontinued product to cart
                var result = await InsertProductToCartAsync(tokenResponse, "112501", 5);
            }
            catch (FlurlHttpException ex)
            {
                // parse content from server response
                var response = await ex.Call.Response.Content.ReadAsStringAsync();
                Console.Error.WriteLine(response);
            }

            #endregion

            #region 4. View shopping cart

            // get shopping cart for specified customer
            var shoppingCartResponse = await ApiUrl
                .AppendPathSegment("ShoppingCart")
                .WithOAuthBearerToken(tokenResponse.AccessToken)
                .SetQueryParam("customerId", CustomerId)
                .GetAsync()
                .ReceiveJson<Listing<ShoppingCart>>();

            Console.WriteLine(JsonConvert.SerializeObject(shoppingCartResponse, Formatting.Indented));

            #endregion

            #region 5. Attempting to view shopping cart you don't have access too

            // will fail with 401
            try
            {
                await ApiUrl
                   .AppendPathSegment("ShoppingCart")
                   .WithOAuthBearerToken(tokenResponse.AccessToken)
                   .SetQueryParam("customerId", "some_other_customer")
                   .GetAsync()
                   .ReceiveJson<Listing<ShoppingCart>>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    await Console.Error.WriteLineAsync(ex.Message);
                else // something else happened
                    throw ex;
            }

            #endregion

            #region 6. View Orders

            // sends request to WDDC's api which returns a listing of orders
            var listOrdersResponse = await ApiUrl
                .AppendPathSegment("OrderProcessing")
                .AppendPathSegment("GetOrders")
                .WithOAuthBearerToken(tokenResponse.AccessToken)
                .SetQueryParams(new ListOptions
                {
                    Page = 0,
                    PageSize = 25,
                    Sort = "createdutc_desc"
                })
                .GetAsync()
                .ReceiveJson<Listing<Order>>();

            Console.WriteLine(JsonConvert.SerializeObject(listOrdersResponse, Formatting.Indented));

            #endregion

            // This requires at least one order placed on your account to run
            #region 7. View order status

            if (listOrdersResponse.Total == 0)
                return;

            // send order status request to server
            var orderStatusResult = await ApiUrl
                .AppendPathSegment("OrderProcessing")
                .AppendPathSegment("GetOrderStatus")
                .WithOAuthBearerToken(tokenResponse.AccessToken)
                .SetQueryParams(new OrderStatusRequest
                {
                    CustomerId = listOrdersResponse.Results.FirstOrDefault().CustomerId,
                    OrderId = listOrdersResponse.Results.FirstOrDefault().Id,
                    OrderType = listOrdersResponse.Results.FirstOrDefault().OrderType
                })
                .GetAsync()
                .ReceiveJson<OrderStatusResult>();

            Console.WriteLine(JsonConvert.SerializeObject(orderStatusResult, Formatting.Indented));

            #endregion
        }

        #endregion
    }
}
