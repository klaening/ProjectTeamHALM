using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMobile.Services
{
    class APIServices
    {
        private const string HOST = "https://webapihalm.azurewebsites.net/api/";
        public static async Task<HttpResponseMessage> PostRequestAsync(string path, Object objectclass)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(objectclass, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(HOST + path, content);
            return response;
        }

        public static string GetRequest(string path, string source)
        {
            var client = new HttpClient();

            var response = client.GetAsync(HOST + path + source);
            var statusCode = response.Result;

            string result = statusCode.Content.ReadAsStringAsync().Result;

            return result;
        }
        public static string GetRequest(string path)
        {
            try
            {
                var client = new HttpClient();

                var response = client.GetAsync(HOST + path);
                var statusCode = response.Result;

                string result = statusCode.Content.ReadAsStringAsync().Result;

                return result;
            }
            catch (Exception e)
            {
                var error = e;
                return e.Message;
            }
           
        }

        internal static object GetRequest(object apiPaths)
        {
            throw new NotImplementedException();
        }

        public async static Task<HttpResponseMessage> PutRequestAsync(string path, Object objectclass)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(objectclass, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(HOST + path, content);
            return response;
        }
    }
}
