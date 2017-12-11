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

        public async void postUser(User user)
        {
            await apiService.postUser(user);
        }

    }
}
