using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Encrypic2017.Data
{
    class APIService
    {

        public APIService()
        {

        }


        private static readonly HttpClient client = new HttpClient();

        const string ServerUrl = "http://127.0.0.1:3000/users/postUser"; //specify your server url

        public void ClientHeaderInfo(HttpClient client)
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));
        }

        public virtual async Task postUser(User user)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            
            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    var result = await client.PostAsync(ServerUrl, content);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }

        }

    }
}
