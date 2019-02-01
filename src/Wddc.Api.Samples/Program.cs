using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Wddc.Api.Samples.Core;
using Flurl.Http;
using Flurl;

namespace Wddc.Api.Samples
{
    public class Program
    {
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

            #region 1. Authentication

            // sends a token request to WDDC's identity server using the password grant type.
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "", // client_id
                ClientSecret = "",  // your client_secret

                UserName = "", // your username
                Password = "", // your password
                Scope = "api api_roles offline_access"
            });

            if (tokenResponse.IsError)
            {
                Console.Error.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);

            #endregion

            #region 2. Process Order

            // generates a new order
            var processOrderRequest = GenerateProcessOrderRequest();

            // sends request to WDDC's api which returns a PlaceOrderResult
            var placeOrderResult = await "https://api-development.clientvantage.ca/api/"
                .AppendPathSegment("orderprocessing/processorder")
                .WithOAuthBearerToken(tokenResponse.AccessToken)
                .PostJsonAsync(processOrderRequest)
                .ReceiveJson<PlaceOrderResult>();

            if (placeOrderResult.Success)
                Console.WriteLine(JsonConvert.SerializeObject(placeOrderResult, Formatting.Indented));
            else
                Console.Error.WriteLine(string.Join(",", placeOrderResult.Errors));

            #endregion

            #region 3. View Orders

            // generate order list options
            var orderListOptions = new OrderListOptions
            {
                CustomerId = "99999",
                Page = 1,
                PageSize = 25,
            };

            // sends request to WDDC's api which returns a listing of orders
            var listOrdersResponse = await "https://api-development.clientvantage.ca/api/"
                .AppendPathSegment("order")
                .SetQueryParams(orderListOptions)
                .WithOAuthBearerToken(tokenResponse.AccessToken)
                .GetJsonAsync<Listing<Order>>();

            Console.WriteLine(JsonConvert.SerializeObject(listOrdersResponse, Formatting.Indented));
            
            #endregion
        }

        #region utilities

        protected static ProcessOrderRequest GenerateProcessOrderRequest()
        {
            return new ProcessOrderRequest
            {
                BillingAddress = GenerateAddress(),
                OrderItems = GenerateOrderItems(),
                ShippingMethod = ShippingMethod.RegularShipping.ToString(),
                PurchaseOrder = "somepo",
                CustomerId = "99999",
            };
        }

        protected static ICollection<OrderItem> GenerateOrderItems()
        {
            return new List<OrderItem>{
                new OrderItem
                {
                    // WDDC's item number
                    ProductSku = "126089",
                    Quantity = 2,
                },
                new OrderItem
                {                    
                    // WDDC's item number
                    ProductSku = "125133",
                    Quantity = 1,
                }
            };
        }

        protected static Address GenerateAddress()
        {
            return new Address
            {
                Address1 = "8882 170 St NW",
                City = "Edmonton",
                CountryTwoLetterIsoCode = "CA",
                Email = "guestservices@wem.ca",
                PhoneNumber = "(780) 444-5330",
                FirstName = "wested",
                LastName = "mall",
                ZipPostalCode = "T5T 4J2",
                StateProvinceAbbreviation = "AB",
            };
        }

        #endregion
    }
}
