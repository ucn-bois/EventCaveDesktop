using Newtonsoft.Json;
using Resources.Entities;
using Resources.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Resources.Controllers
{
    public class CategoryController
    {
        RestClient client = new RestClient("https://localhost:44324");
        Authentication auth = Authentication.GetInstance();

        public ICollection<Category> GetAll()
        {
            var request = new RestRequest("Api/Categories", Method.GET);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            auth.AddAuthHeader(request);
            request.RequestFormat = DataFormat.Json;

            IRestResponse<List<Category>> response = client.Execute<List<Category>>(request);
            List<Category> categories = new List<Category>();
            if (response.Data != null && auth.UserLoggedIn())
            {
                categories = response.Data;
            }
            return categories;
        }

        public Category GetById(object categoryId)
        {
            var request = new RestRequest(String.Format("Api/Categories/{0}", categoryId), Method.GET);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            auth.AddAuthHeader(request);
            request.RequestFormat = DataFormat.Json;
            IRestResponse<Category> response = client.Execute<Category>(request);

            return response.Data;
        }

        public bool Create(Category category)
        {
            bool success = false;
            var request = new RestRequest("Api/Categories", Method.POST);
            auth.AddAuthHeader(request);
            request.AddParameter("Name", category.Name);
            request.AddParameter("Description", category.Description);
            request.AddParameter("Image", category.Image);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                success = true;
            }

            return success;
        }

        public bool Update(Category category)
        {
            bool success = false;
            var request = new RestRequest("Api/Categories", Method.PUT);
            auth.AddAuthHeader(request);
            request.AddParameter("Name", category.Name);
            request.AddParameter("Description", category.Description);
            request.AddParameter("Image", category.Image);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                success = true;
            }

            return success;
        }

        public bool Delete(int categoryId)
        {
            bool success = false;
            var request = new RestRequest(string.Format("Api/Categories/{0}", categoryId), Method.DELETE);
            auth.AddAuthHeader(request);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                success = true;
            }

            return success;
        }
    }
}
