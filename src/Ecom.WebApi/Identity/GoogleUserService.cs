using Ecom.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecom.WebApi.Identity
{
    public class GoogleUserService : IExternalUserService
    {
        private  const string ClientId = "client_id";
        private  const string ClientSecret = "client_secret";
        private  const string UserEmail = "user_email";
        private  const string RedirectUrl = "redirect_uri";
        private  const string GrantType = "grant_type";
        private const string GoogleTokenFetchingUrl = "https://accounts.google.com/o/oauth2/token";
        private const string GoogleUserAccessUrl = "https://www.googleapis.com/oauth2/v1/userinfo?access_token={0}";

        private readonly IEcomConfigManager ecomConfigManager;
        private readonly IHttpClientFactory httpClientFactory;

        public GoogleUserService(IEcomConfigManager ecomConfigManager, IHttpClientFactory httpClientFactory)
        {
            this.ecomConfigManager = ecomConfigManager;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<UserDto> GetUserInfoAsync(string email)
        {
            OAuthInfo oauthInfo = ecomConfigManager.GetOAthInfo();
            HttpClient httpClient = httpClientFactory.CreateClient();

            var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(ClientId, oauthInfo.ClientId),
                    new KeyValuePair<string, string>(ClientSecret, oauthInfo.ClientSecret),
                    new KeyValuePair<string, string>(UserEmail, email),
                    new KeyValuePair<string, string>(RedirectUrl, oauthInfo.RedirectUrl),
                    new KeyValuePair<string, string>(RedirectUrl, oauthInfo.RedirectUrl),
                    new KeyValuePair<string, string>(GrantType, oauthInfo.GrantType)
                };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, GoogleTokenFetchingUrl) { Content = new FormUrlEncodedContent(postData) };
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);
            responseMessage.EnsureSuccessStatusCode();

            string jsonResponse = await responseMessage.Content.ReadAsStringAsync();

            var token = JsonConvert.DeserializeObject<OAuthAccessToken>(jsonResponse);
            string userAccessUrl = string.Format(GoogleUserAccessUrl, token.access_token);

            var userDataJsonResponse = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, userAccessUrl));
            var userDataJson = await userDataJsonResponse.Content.ReadAsStringAsync();
            var googleUserInfo = JsonConvert.DeserializeObject<UserDto>(userDataJson);

            return googleUserInfo;
        }
    }
}
