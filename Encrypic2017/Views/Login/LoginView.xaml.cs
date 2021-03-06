﻿using Encrypic2017.Data;
using Encrypic2017.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        UserViewModel UVM;

        Response res = new Response();
        public LoginView()
        {
            this.InitializeComponent();
            UVM = new UserViewModel();
        }

        private async void signin_button_Click(object sender, RoutedEventArgs e)
        {

            res = await UVM.authenticateUser();

            if(res.status == "OK")
            {
                Frame.Navigate(typeof(MasterView));
            }
            else
            {
                var data = (JObject)JsonConvert.DeserializeObject(res.data);
                string msg = data["msg"].Value<string>();
                errormessage.Text = msg;
                errormessage.Visibility = Visibility.Visible;
            }
        }

        private void sign_up_hl_Click(Windows.UI.Xaml.Documents.Hyperlink sender, Windows.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            Frame.Navigate(typeof(RegisterView));
        }
    }
}
