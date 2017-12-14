using Encrypic2017.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypic2017.Models
{
    class MessageModel
    {
        APIService apiService = new APIService();

        public async Task<Response> postMessage(Message message)
        {
            return await apiService.postMessage(message);
        }

        public async Task<Response> searchMessage(Search query)
        {
            return await apiService.searchMessage(query);
        }
    }
}
