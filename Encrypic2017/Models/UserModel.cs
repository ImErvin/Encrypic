using Encrypic2017.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Popups;

namespace Encrypic2017.Models
{
    class UserModel
    {
        APIService apiService = new APIService();
        public UserModel()
        {
            
        }

        public async Task<Response> postUser(User user)
        {
            return await apiService.postUser(user);
        }

        public async Task<Response> authenticateUser(Authentication auth)
        {
            return await apiService.authenticateUser(auth);
        }

        public async Task<Response> searchUsers(Search query)
        {
            return await apiService.searchUsers(query);
        }
    }
}
