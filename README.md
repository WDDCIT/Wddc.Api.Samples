# Wddc Api Samples

Some samples to interact with our API.

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
    ClientId = "", // client_id
    ClientSecret = "",  // your client_secret

    UserName = "", // your username
    Password = "", // your password
    Scope = ""
});
```

Run the solution

### Built With

* [Flurl](https://flurl.io/)
* [IdentityModel](https://identitymodel.readthedocs.io/en/latest/)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)

## Authors

* **Jason Reddekopp** - *Initial work* - [GitHub](https://github.com/jreddeko)
