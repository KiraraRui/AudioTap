using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace ProjectAudioTap.Managers
{
    class GoogleAuth
    {
        //Credentials for authorization to google Oauth
        public static readonly string ClientId = "782724761235-staeiq81q7ln0tcejmdd0gbitl3fd0at.apps.googleusercontent.com";
        public static readonly string ClientSecret = "";
        public static readonly string RedirectUri = "";

        public async Task<string> GetAccessTokenAsync(string code)
        {
            var requestUrl =
                "https://www.googleapis.com/oauth2/v4/token"
                + "?code=" + code
                + "&client_id=" + ClientId
                + "&client_secret=" + ClientSecret
                + "&redirect_uri=" + RedirectUri
                + "&grant_type=authorization_code";

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(requestUrl, null);

            var json = await response.Content.ReadAsStringAsync();


            /* 
             * NGL this one specificly is taken from the net.
             * This one i did not find an alternative as i want JsonSerialize instead of NewtonSoft JsonConvert BUT.
             *
             * JsonSerialize which is by microsoft and is simply a "replacement" for NewtonSoft JsonConvert which is by NewtonSoft
             * So the only reason we really wanna use JsonSerialize is because eventually the JsonConvert will become depricated.
             *
             * As far as i understand it does as following : We get out accesstoken and then converts it from a json type to .NET type
             * So here the Token becomes a converted token value which is a string by the name access_token
            */
            var accessToken = JsonConvert.DeserializeObject<JObject>(json).Value<string>("access_token");

            return accessToken;
        }

    }
}
