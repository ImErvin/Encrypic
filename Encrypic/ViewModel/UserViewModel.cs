using Encrypic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypic.ViewModel
{
    class UserViewModel
    {
        UserModel userModel = new UserModel();
        List<UserObject> userList;

        public UserViewModel()
        {
            
        }

        public void initiateUserList()
        {
            Debug.WriteLine("initating");
            this.userList = userModel.getUserList();
            Debug.WriteLine(userList[0].firstName);
        }

        public void userLogin(string username, string password)
        {
            if (userList == null)
            {
                initiateUserList();
            }

            foreach (var user in userList)
            {
                Debug.WriteLine(user.username + " " + user.password);
                if (user.username == username)
                {
                    Debug.WriteLine(user.username + " " + user.password);
                }
            }
        }

    }
}
