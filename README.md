# Wddc Api Samples

Console application showing how to authenticate and access WDDC's API.

## Getting Started

Download the solution

```
git clone https://github.com/wddcit/wddc.api.samples/
cd .\wddc.api.samples\src\wddc.api.samples
```

Make sure to update your client credentials and enter your username + password

```
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
```

Run the solution

### Built With

* [Flurl](https://flurl.io/)
* [IdentityModel](https://identitymodel.readthedocs.io/en/latest/)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* [Wddc Api](https://api.clientvantage.ca/)

## Authors

* **Jason Reddekopp** - *Initial work* - [GitHub](https://github.com/jreddeko)
