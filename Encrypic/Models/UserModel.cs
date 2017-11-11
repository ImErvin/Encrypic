using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace Encrypic.Models
{
    class UserModel
    {
        private List<UserObject> userList { get; set; }

        public UserModel()
        {

        }

        public async void getUsers()
        {
            var userFile = await
                Package.Current.InstalledLocation.GetFileAsync("Data\\UserData.txt");
            var fileText = await FileIO.ReadTextAsync(userFile);

            try
            {
                var userJson = JsonArray.Parse(fileText);
                Debug.WriteLine(userJson);
            }catch(Exception exJa)
            {
                Debug.WriteLine(exJa);
            }

            
        }

    }
}
