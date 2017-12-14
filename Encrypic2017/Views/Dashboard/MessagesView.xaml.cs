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
    public sealed partial class MessagesView : Page
    {
        MessageViewModel MVM;
        string base64;
        public MessagesView()
        {
            this.InitializeComponent();
            MVM = new MessageViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            base64 = (string)e.Parameter;

            Debug.WriteLine(base64);
        }

        private void openMessage_button_Click(object sender, RoutedEventArgs e)
        {
            setImage(base64);
            lockedMessage.Visibility = Visibility.Collapsed;
            openedMessage.Visibility = Visibility.Visible;
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InboxView));
        }

        private void closePicture_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InboxView));
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
                sentImage.Source = img;
            }
        }
    }
}
