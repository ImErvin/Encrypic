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
        // Default Consstructor
        public APIService()
        {

        }

        // Create the client
        private static readonly HttpClient client = new HttpClient();

        // Set the serverUrl
        const string ServerUrl = "http://127.0.0.1:3000/"; //specify your server url

        public Response res = new Response();

        LocalStorageService lss = new LocalStorageService();

        public void ClientHeaderInfo(HttpClient client)
        {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));
        }

        // POST USER -------------------------------------------------------------------------------------- 

        public virtual async Task<Response> postUser(User user)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            
            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    var result = await client.PostAsync(ServerUrl + "users/postUser", content);

                    res.data = Convert.ToString(await result.Content.ReadAsStringAsync());
                    res.status = Convert.ToString(result.StatusCode);

                    if (result.IsSuccessStatusCode)
                    {
                        return res;
                    }
                    else
                    {
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    res.data = "{'msg':'There was an error connecting to backend - Try again later'}";
                    res.status = "Internal Server Error";
                    return res;
                }
            }

        }

        // Put User --------------------------------------------------------------------------------------

        public virtual async Task<Response> putUser(User user)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    var result = await client.PutAsync(ServerUrl + "users/putUser", content);

                    res.data = Convert.ToString(await result.Content.ReadAsStringAsync());
                    res.status = Convert.ToString(result.StatusCode);

                    if (result.IsSuccessStatusCode)
                    {
                        saveToLocalStorage(res.data);
                        return res;
                    }
                    else
                    {
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    res.data = "{'msg':'There was an error connecting to backend - Try again later'}";
                    res.status = "Internal Server Error";
                    return res;
                }
            }

        }

        // Authenticate User --------------------------------------------------------------------------------

        public virtual async Task<Response> authenticateUser(Authentication auth)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(auth), Encoding.UTF8, "application/json");

            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    HttpResponseMessage result = await client.PostAsync(ServerUrl + "users/authenticate", content);

                    res.data = Convert.ToString(await result.Content.ReadAsStringAsync());
                    res.status = Convert.ToString(result.StatusCode);

                    if (result.IsSuccessStatusCode)
                    {
                        saveToLocalStorage(res.data);
                        return res;
                    }
                    else
                    {
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    res.data = "{'msg':'There was an error connecting to backend - Try again later'}";
                    res.status = "Internal Server Error";
                    return res;
                }
            }

        }

        // Search users ------------------------------------------------------------------------------------

        public virtual async Task<Response> searchUsers(Search query)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");

            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    HttpResponseMessage result = await client.PostAsync(ServerUrl + "users/search", content);

                    res.data = Convert.ToString(await result.Content.ReadAsStringAsync());
                    res.status = Convert.ToString(result.StatusCode);

                    if (result.IsSuccessStatusCode)
                    {
                        return res;
                    }
                    else
                    {
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    res.data = "{'msg':'There was an error connecting to backend - Try again later'}";
                    res.status = "Internal Server Error";
                    return res;
                }
            }
        }

        public virtual async Task<Response> getUserFriends(Search query)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");

            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    HttpResponseMessage result = await client.PostAsync(ServerUrl + "users/userFriends", content);

                    res.data = Convert.ToString(await result.Content.ReadAsStringAsync());
                    res.status = Convert.ToString(result.StatusCode);

                    if (result.IsSuccessStatusCode)
                    {
                        return res;
                    }
                    else
                    {
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    res.data = "{'msg':'There was an error connecting to backend - Try again later'}";
                    res.status = "Internal Server Error";
                    return res;
                }
            }
        }

        public virtual async Task<Response> postMessage(Message message)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    HttpResponseMessage result = await client.PostAsync(ServerUrl + "messages/postMessage", content);

                    res.data = Convert.ToString(await result.Content.ReadAsStringAsync());
                    res.status = Convert.ToString(result.StatusCode);

                    if (result.IsSuccessStatusCode)
                    {
                        return res;
                    }
                    else
                    {
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    res.data = "{'msg':'There was an error connecting to backend - Try again later'}";
                    res.status = "Internal Server Error";
                    return res;
                }
            }
        }

        public virtual async Task<Response> searchMessage(Search query)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");

            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    HttpResponseMessage result = await client.PostAsync(ServerUrl + "messages/search", content);

                    res.data = Convert.ToString(await result.Content.ReadAsStringAsync());
                    res.status = Convert.ToString(result.StatusCode);

                    if (result.IsSuccessStatusCode)
                    {
                        return res;
                    }
                    else
                    {
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    res.data = "{'msg':'There was an error connecting to backend - Try again later'}";
                    res.status = "Internal Server Error";
                    return res;
                }
            }
        }

        public virtual async Task<Response> deleteMessage(Message message)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    HttpResponseMessage result = await client.PostAsync(ServerUrl + "messages/deleteMessage", content);

                    res.data = Convert.ToString(await result.Content.ReadAsStringAsync());
                    res.status = Convert.ToString(result.StatusCode);

                    if (result.IsSuccessStatusCode)
                    {
                        return res;
                    }
                    else
                    {
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    res.data = "{'msg':'There was an error connecting to backend - Try again later'}";
                    res.status = "Internal Server Error";
                    return res;
                }
            }
        }


        public void saveToLocalStorage(string data)
        {
            lss.saveUser(data);
        }

        public async Task<string> getFromLocalStorage()
        {
            return await lss.getUser();
        }
    }
}
