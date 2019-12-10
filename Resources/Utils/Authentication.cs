using Newtonsoft.Json;
using Resources.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.Utils
{
    public class Authentication
    {
        RestClient client = new RestClient("https://localhost:44324");
        public User LoggedInUser { get; set; }

        private bool IsUserLoggedIn { get; set; }
        private ApiToken ActiveToken { get; set; }
        private static Authentication Instance { get; set; }

        private Authentication()
        {
            LoggedInUser = new User();
        }

        public static Authentication GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Authentication();
            }

            return Instance;
        }

        public bool LogIn(string userName, string password)
        {
            LoggedInUser.UserName = userName;
            LoggedInUser.Password = password;

            ActiveToken = RequestToken();

            if (ActiveToken.AccessToken == null)
            {
                IsUserLoggedIn = false;
                return false; // login fail
            }

            IsUserLoggedIn = true;
            return true; // login success
        }

        private ApiToken RequestToken()
        {

            if (ActiveToken == null || TokenExpired())
            {
                var tokenRequest = new RestRequest("/Api/Token", Method.POST);
                tokenRequest.AddParameter("username", LoggedInUser.UserName);
                tokenRequest.AddParameter("password", LoggedInUser.Password);
                tokenRequest.AddParameter("grant_type", "password");
                tokenRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
                IRestResponse tokenResponse = client.Execute(tokenRequest);
                ActiveToken = JsonConvert.DeserializeObject<ApiToken>(tokenResponse.Content);
            }

            return ActiveToken;
        }

        public bool TokenExpired()
        {
            return DateTime.Parse(ActiveToken.Expires) < DateTime.Now;
        }

        public bool UserLoggedIn()
        {
            return IsUserLoggedIn;
        }

        public bool AddAuthHeader(RestRequest request)
        {
            if (UserLoggedIn())
            {
                ActiveToken = RequestToken();
                request.AddHeader("Authorization", $"Bearer {ActiveToken.AccessToken}");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
