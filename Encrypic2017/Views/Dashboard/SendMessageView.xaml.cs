using Encrypic2017.Data;
using Encrypic2017.ViewModels;
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
    public sealed partial class SendMessageView : Page
    {
        MessageViewModel MVM;
        FileViewModel FVM;
        string toUsername = "Message to ";
        public SendMessageView()
        {
            this.InitializeComponent();
            MVM = new MessageViewModel();
            FVM = new FileViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string u = (string)e.Parameter;

            MVM.messageTo = u;
            toUsername += u;
        }

        private void closePicture_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FriendsListView));
        }

        private async void upload_button_Click(object sender, RoutedEventArgs e)
        {
            MVM.fileAttachment = await FVM.uploadImage();
            setImage(MVM.fileAttachment);
        }

        private async void sendMessage_button_Click(object sender, RoutedEventArgs e)
        {
            await MVM.sendMessage();
        }

        private async void setImage(string base64Image)
        {
            if(base64Image == "")
            {
                previewImage.Visibility = Visibility.Collapsed;
            }
            else
            {
                byte[] data = Convert.FromBase64String(base64Image);
                if (data.Count() > 1)
                {
                    MemoryStream ms = new MemoryStream(data, 0, data.Length);
                    BitmapImage img = new BitmapImage();
                    var ras = ms.AsRandomAccessStream();
                    await img.SetSourceAsync(ras);
                    previewImage.Source = img;
                    previewImage.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
