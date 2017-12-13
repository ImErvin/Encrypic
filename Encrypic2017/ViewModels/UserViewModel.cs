using Encrypic2017.Data;
using Encrypic2017.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace Encrypic2017.ViewModels
{
    class UserViewModel : NotificationBase<User>
    {
        public UserModel um = new UserModel();

        public User newUser = new User();

        public User currentUser = new User();

        public Authentication auth = new Authentication();

        public Response res = new Response();

        public ObservableCollection<User> searchResults = new ObservableCollection<User>();

        public Search searchQuery = new Search();

        public UserViewModel(User user = null) : base(user) {
            
        }

        public string firstName
        {
            get { return This.firstName; }
            set { SetProperty(This.firstName, value, () => This.firstName = value); }
        }
        public string surname
        {
            get { return This.surname; }
            set { SetProperty(This.surname, value, () => This.surname = value); }
        }
        public string username
        {
            get { return This.username; }
            set { SetProperty(This.username, value, () => This.username = value); }
        }
        public string password
        {
            get { return This.password; }
            set { SetProperty(This.password, value, () => This.password = value); }
        }
        public string secretkey
        {
            get { return This.secretkey; }
            set { SetProperty(This.secretkey, value, () => This.secretkey = value); }
        }
        public string friends
        {
            get { return This.password; }
            set { SetProperty(This.friends, value, () => This.friends = value); }
        }
        public string createdAt
        {
            get { return This.createdAt; }
            set { SetProperty(This.createdAt, value, () => This.createdAt = value); }
        }
        public string profilePicture
        {
            get { return This.profilePicture; }
            set { SetProperty(This.profilePicture, value, () => This.profilePicture = value); }
        }

        public async Task<Response> registerUser()
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                res.data = "{'msg':'Please fill in all the details'}";
                res.status = "BadRequest";
                return res;
            }
            else
            {
                newUser.firstName = firstName;
                newUser.surname = surname;
                newUser.username = username;
                newUser.password = password;
                newUser.secretkey = firstName + "" + surname;
                newUser.friends = "No Friends";
                newUser.createdAt = DateTime.Now.ToString();
                newUser.profilePicture = await uploadImage();

                return await um.postUser(newUser);
            }
        }

        public async Task<string> uploadImage()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (var stream = await file.OpenStreamForReadAsync())
                {
                    using (var memory = new MemoryStream())
                    {
                        await stream.CopyToAsync(memory);
                        byte[] array = memory.ToArray();
                        string result = Convert.ToBase64String(array);
                        return result;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<Response> authenticateUser()
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                res.data = "{'msg':'Please fill in all the details'}";
                res.status = "BadRequest";
                return res;
            }
            else
            {
                auth.username = username;
                auth.password = password;
                return await um.authenticateUser(auth);
            }
        }

        public async Task<Response> searchUser()
        {
            if(string.IsNullOrEmpty(searchQuery.query))
            {
                res.data = "{'msg':'Please fill in all the details'}";
                res.status = "BadRequest";
                await new MessageDialog("Search field is empty.").ShowAsync();
                return res;
            }else
            {
                searchQuery.userResults = null;
                res = await um.searchUsers(searchQuery);
                try
                {
                    searchResults.Clear();
                    var users = JsonArray.Parse(res.data);
                    convertJsonToUsers(users);
                }
                catch (Exception exJA)
                {
                    MessageDialog dialog = new MessageDialog(exJA.Message);
                    await dialog.ShowAsync();
                }
                return res;
            }
        }


        public async Task<Response> updateUser()
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(surname) && string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                res.data = "{'msg':'Please fill in all the details'}";
                res.status = "BadRequest";
                return res;
            }
            else
            {
                newUser.firstName = firstName;
                newUser.surname = surname;
                newUser.username = username;
                newUser.password = password;
                newUser.secretkey = secretkey;
                newUser.friends = friends;
                newUser.createdAt = createdAt;
                newUser.profilePicture = profilePicture;

                return await um.putUser(newUser);
            }
        }

        public async void getUserDetails()
        {
            try
            {
                string jsonString = await um.getFromLocalStorage();
                convertToJsonUser(jsonString);
            }
            catch (Exception err)
            {
                MessageDialog dialog = new MessageDialog(err.Message);
                await dialog.ShowAsync();
            }
        }

        public void convertToJsonUser(string jsonData)
        {
            var data = JsonConvert.DeserializeObject<RootObject>(jsonData);
            this.firstName = data.user.firstName;
            this.surname = data.user.surname;
            this.username = data.user.username;
            this.secretkey = data.user.secretkey;
            this.friends = data.user.friends;
            this.createdAt = data.user.createdAt;
            this.profilePicture = "null";
        }

        public void convertJsonToUsers(JsonArray jsonData)
        {
            //searchResults = new ObservableCollection<User>();
            foreach (var item in jsonData)
            {
                // get the object
                var obj = item.GetObject();

                User temp = new User();

                // get each key value pair and sort it to the appropriate elements
                // of the class
                foreach (var key in obj.Keys)
                {
                    IJsonValue value;
                    if (!obj.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        case "firstName": // based on generic object key
                            temp.firstName = value.GetString();
                            break;
                        case "surname":
                            temp.surname = value.GetString();
                            break;
                        case "username":
                            temp.username = value.GetString();
                            break;
                        case "secretkey":
                            temp.secretkey = value.GetString();
                            break;
                        case "createdAt":
                            temp.createdAt = value.GetString();
                            break;
                        //case "profilePicture":
                        //    temp.profilePicture = value.GetString();
                        //    break;
                    }
                } // end foreach (var key in obj.Keys)
                Debug.Write(temp.username + "\n");
                temp.profilePicture = "null";
                searchResults.Add(temp);
            } // end foreach (var item in array)
        }
    }

    class RootObject
    {
        public User user { get; set; }
    }
}
