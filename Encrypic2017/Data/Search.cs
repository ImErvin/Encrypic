using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypic2017.Data
{
    class Search
    {
        public string query { get; set; }
        public ObservableCollection<User> userResults { get; set; }
        public ObservableCollection<User> messageResults { get; set; }
    }
}
