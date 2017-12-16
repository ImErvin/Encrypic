using Encrypic2017.Data;
using Encrypic2017.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Encrypic2017.Views.Dashboard
{
    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfileSettingsView : Page
    {
        UserViewModel UVM;

        Response res = new Response();
        public ProfileSettingsView()
        {
            Debug.WriteLine("hey");
            this.InitializeComponent();
            UVM = new UserViewModel();
            setupPage();
        }

        private async void setupPage()
        {
            await UVM.getUserDetails();
            if(UVM.profilePicture != "")
            {
                setImage(UVM.profilePicture);
            }
        }

        private async void updateProfile_Button_Click(object sender, RoutedEventArgs e)
        {
            res = await UVM.updateUser();

            if (res.status == "OK")
            {
                var data = (JObject)JsonConvert.DeserializeObject(res.data);
                string msg = data["msg"].Value<string>();
                errormessage.Text = msg;
                errormessage.Visibility = Visibility.Visible;
            }
            else
            {
                var data = (JObject)JsonConvert.DeserializeObject(res.data);
                string msg = data["msg"].Value<string>();
                errormessage.Text = msg;
                errormessage.Visibility = Visibility.Visible;
            }
        }

        private async void uploadPhoto_button_Click(object sender, RoutedEventArgs e)
        {
            string base64Image = await UVM.uploadImage();
            UVM.profilePicture = base64Image;
            try
            {
                setImage(base64Image);
            }
            catch
            {
                Debug.WriteLine("Can't upload picture");
            }
        }

        private async void setImage(string base64Image)
        {
            byte[] data = Convert.FromBase64String(base64Image);
            if (data.Count() > 1)
            {
                MemoryStream ms = new MemoryStream(data, 0, data.Length);
                BitmapImage img = new BitmapImage();
                var ras = ms.AsRandomAccessStream();
                await img.SetSourceAsync(ras);
                profilePictureImage.ImageSource = img;
            }
        }
    }
}
