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

        const string ServerUrl = "http://127.0.0.1:3000/users"; //specify your server url

        public string response;

        public void ClientHeaderInfo(HttpClient client)
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));
        }

        public virtual async Task<string> postUser(User user)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            
            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    var result = await client.PostAsync(ServerUrl + "/postUser", content);
                    var resposne = Convert.ToString(await result.Content.ReadAsStringAsync());
                    await new MessageDialog(await result.Content.ReadAsStringAsync()).ShowAsync();
                    if (result.IsSuccessStatusCode)
                    {
                        return resposne;
                    }
                    else
                    {
                        return resposne;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    return ex.Message;
                }
            }

        }

        public virtual async Task<String> authenticateUser(Authentication auth)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(auth), Encoding.UTF8, "application/json");

            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    HttpResponseMessage result = await client.PostAsync(ServerUrl + "/authenticate", content);
                    await new MessageDialog(await result.Content.ReadAsStringAsync()).ShowAsync();
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return await result.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    return ex.Message;
                }
            }

        }

        public virtual async Task getUser(string username)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(username), Encoding.UTF8, "application/json");

            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    HttpResponseMessage result = await client.PostAsync(ServerUrl, content);
                    await new MessageDialog(await result.Content.ReadAsStringAsync()).ShowAsync();
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }

        }

    }
}
