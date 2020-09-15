using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Desktop.Services
{
    public class Requests
    {
        // public const string HOST = "https://webapihalm.azurewebsites.net/api/";

        public const string HOST = "https://webapihalm.azurewebsites.net/api/";

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

        public static string GetRequest(string path)
        {
            var client = new HttpClient();

            var response = client.GetAsync(HOST + path);
            var statusCode = response.Result;

            string result = statusCode.Content.ReadAsStringAsync().Result;

            return result;
        }

        public static string GetRequest_ID(string path, int id)
        {
            var client = new HttpClient();

            var response = client.GetAsync(HOST + path + id);
            var statusCode = response.Result;

            string result = statusCode.Content.ReadAsStringAsync().Result;

            return result;
        }

        public async static Task<HttpResponseMessage> PutRequestAsync(string path, Object objectClass)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(objectClass, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(HOST + path, content);

            return response;
        }
        public static Task<HttpResponseMessage> DeleteRequestAsync(string path, int id)
        {
            var client = new HttpClient();

            var response = client.DeleteAsync(HOST + path + id);

            return response;
        }
    }
}
