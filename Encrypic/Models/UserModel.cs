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
        private List<UserObject> userList = new List<UserObject>();

        public UserModel()
        {
            this.getUsers();
        }

        public async void getUsers()
        {
            var userFile = await
                Package.Current.InstalledLocation.GetFileAsync("Data\\UserData.txt");
            var fileText = await FileIO.ReadTextAsync(userFile);

            try
            {
                var userJson = JsonArray.Parse(fileText);
                setUserList(userJson);
            }
            catch(Exception exJa)
            {
                Debug.WriteLine(exJa);
            }
        }

        public List<UserObject> getUserList()
        {
            Debug.WriteLine(userList.ToString());
            return userList;
        }

        public void setUserList(JsonArray userJson)
        {
            
            foreach (var item in userJson)
            {
                var obj = item.GetObject();

                UserObject user = new UserObject();

                foreach (var key in obj.Keys)
                {
                    IJsonValue value;
                    if (!obj.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        case "firstName":
                            user.firstName = value.GetString();
                            break;
                        case "surname":
                            user.surname = value.GetString();
                            break;
                        case "username":
                            user.username = value.GetString();
                            break;
                        case "password":
                            user.password = value.GetString();
                            break;
                        case "secretkey":
                            user.secretkey = value.GetString();
                            break;
                    }
                }

                userList.Add(user);
            }
            Debug.WriteLine(userList[0].username.ToString());
        }

    }
}
