using Encrypic2017.Views.Dashboard;
using Encrypic2017.Views.Login;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Encrypic2017.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterView : Page
    {
        public BitmapImage bitmapImage { get; set; }
        public Uri ImageUri { get; set; }
        public MasterView()
        {
            this.InitializeComponent();
            setBackgroundImage();
            ContentFrame.Navigate(typeof(InboxView));
        }

        private void setBackgroundImage()
        {
            Random rnd = new Random();
            string url = "ms-appx://Encrypic2017/Assets/background_images/bg"+ rnd.Next(1, 22)+".jpg";
            ImageUri = new Uri(url);
            bitmapImage = new BitmapImage(ImageUri);
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "home")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Navigate(typeof(ProfileSettingsView));
            }
            else
            {
                switch (args.InvokedItem)
                {
                    case "Home":
                        ContentFrame.Navigate(typeof(InboxView));
                        break;

                    case "Friends":
                        ContentFrame.Navigate(typeof(FriendsListView));
                        break;

                    case "Camera":
                        ContentFrame.Navigate(typeof(CameraView));
                        break;
                }
            }
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(ProfileSettingsView));
            }
            else
            {

                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag)
                {
                    case "home":
                        ContentFrame.Navigate(typeof(InboxView));
                        break;

                    case "friends":
                        ContentFrame.Navigate(typeof(FriendsListView));
                        break;

                    case "camera":
                        ContentFrame.Navigate(typeof(CameraView));
                        break;
                }
            }
        }

        private void logout_appbutton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginView));
        }
    }
}
