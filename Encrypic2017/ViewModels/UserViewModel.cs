using Encrypic2017.Data;
using Encrypic2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

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
    }
}
