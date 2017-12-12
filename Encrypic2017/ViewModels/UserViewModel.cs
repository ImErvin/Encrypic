using Encrypic2017.Data;
using Encrypic2017.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Authentication auth = new Authentication();

        public Response res = new Response();

        public List<User> searchResults = new List<User>();

        public string query { get; set; }

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
        public DateTime createdAt
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
                res.status = "Bad Request";
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
                newUser.createdAt = DateTime.Now;
                newUser.profilePicture = await uploadImage();

                return await um.postUser(newUser);
            }
        }
        
        public async Task<Response> authenticateUser()
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                res.data = "{'msg':'Please fill in all the details'}";
                res.status = "Bad Request";
                return res;
            }
            else
            {
                auth.username = username;
                auth.password = password;
                return await um.authenticateUser(auth);
            }
        }

        public async void searchUser()
        {
            await um.searchUsers(query);
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
                        await new MessageDialog(result).ShowAsync();
                        return result;
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
