using Encrypic2017.Data;
using Encrypic2017.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Encrypic2017.Views.Login
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : Page
    {
        UserModel um = new UserModel();
        User user = new User("John", "Murphy", "john", "12345", "secret", "hey", DateTime.Now);
        public LoginView()
        {
            this.InitializeComponent();
            this.createUser();
        }

        public async void createUser()
        {
            await um.postUser(user);
        }

        private void signin_button_Click(object sender, RoutedEventArgs e)
        {
            this.createUser();
        }

        private void sign_up_hl_Click(Windows.UI.Xaml.Documents.Hyperlink sender, Windows.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            Frame.Navigate(typeof(RegisterView));
        }
    }
}
