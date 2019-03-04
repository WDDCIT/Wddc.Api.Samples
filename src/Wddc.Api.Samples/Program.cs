using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wddc.Api.Samples.Core;
using Flurl.Http;
using Flurl;
using System.Linq;

namespace Wddc.Api.Samples
{
    public class Program
    {
        protected static string CustomerId => "32922_WOOFTEST";
        protected static string ApiUrl => "https://api.clientvantage.ca/api/";

        public static void Main(string[] args)
        {
            ProcessOrderExamples().Wait();
        }

        public async static Task ProcessOrderExamples()
        {
            var client = new HttpClient();

            // sends WDDC's identity server a discovery document request
            var disco = await client.GetDiscoveryDocumentAsync("https://is4.clientvantage.ca/");

            if (disco.IsError)
            {
                Console.Error.WriteLine(disco.Error);
                return;
            }

            Console.WriteLine(JsonConvert.SerializeObject(disco, Formatting.Indented));

            #region 1. Authentication

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
                return;
            }

            Console.WriteLine(tokenResponse.Json);

            #endregion
            
            #region 2. Add to shopping cart

            var shoppingCart = await ApiUrl
                .AppendPathSegment("ShoppingCart")
                .WithOAuthBearerToken(tokenResponse.AccessToken)
                .PostJsonAsync(new AddToCartRequest
                {
                    CustomerId = CustomerId,
                    ProductSku = "103871",
                    Quantity = 5
                })
                .ReceiveJson<ShoppingCart>();

            Console.WriteLine(JsonConvert.SerializeObject(shoppingCart, Formatting.Indented));

            #endregion

            #region 3. Add discontinued product to cart

            try
            {
                // this tries to add a discontinued product to cart
                var result = await ApiUrl
                    .AppendPathSegment("ShoppingCart")
                    .WithOAuthBearerToken(tokenResponse.AccessToken)
                    .PostJsonAsync(new AddToCartRequest
                    {
                        CustomerId = CustomerId,
                        ProductSku = "112501",
                        Quantity = 5
                    })
                    .ReceiveJson<ShoppingCart>();
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
    }
}
