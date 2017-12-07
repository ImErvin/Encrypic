using Encrypic2017.Views.Dashboard;
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

namespace Encrypic2017.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterView : Page
    {
        public MasterView()
        {
            this.InitializeComponent();
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // you can also add items in code behind
            NavView.MenuItems.Add(new NavigationViewItemSeparator());
            NavView.MenuItems.Add(new NavigationViewItem()
            { Content = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });

            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "apps")
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

                    case "My Profile":
                        ContentFrame.Navigate(typeof(ProfileView));
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

                    case "profile":
                        ContentFrame.Navigate(typeof(ProfileView));
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
    }
}
