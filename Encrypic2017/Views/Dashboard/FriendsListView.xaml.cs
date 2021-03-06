﻿using Encrypic2017.Data;
using Encrypic2017.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Encrypic2017.Views.Dashboard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FriendsListView : Page
    {
        UserViewModel UVM;
        Response res = new Response();
        public FriendsListView()
        {
            this.InitializeComponent();
            UVM = new UserViewModel();
            loadFriends();
        }

        private async void loadFriends()
        {
            Response res = await UVM.getUserFriends();
            if (res.status == "OK")
            {
                if (UVM.friendsList.Count() == 0)
                {
                    noFriends.Visibility = Visibility.Visible;
                }
                else
                {
                    noFriends.Visibility = Visibility.Collapsed;
                }

            }
        }

        private async void searchUsers_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            Response res = await UVM.searchUser();
            Debug.WriteLine(res.status);
            
            if(res.status == "OK")
            {
                if(UVM.searchResults.Count() == 0)
                {
                    noResults.Visibility = Visibility.Visible;
                    searchResults.Visibility = Visibility.Collapsed;
                    friendsList.Visibility = Visibility.Collapsed;
                    closeSearch_button.Visibility = Visibility.Visible;
                    noFriends.Visibility = Visibility.Collapsed;
                }
                else
                {
                    noResults.Visibility = Visibility.Collapsed;
                    searchResults.Visibility = Visibility.Visible;
                    friendsList.Visibility = Visibility.Collapsed;
                    closeSearch_button.Visibility = Visibility.Visible;
                    noFriends.Visibility = Visibility.Collapsed;
                }
                
            }
        }

        private void searchResults_Loaded(object sender, RoutedEventArgs e)
        {
            var listView = (ListView)sender;
            //listView.ItemsSource = searchR;
        }

        private void searchUsers_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            noResults.Visibility = Visibility.Visible;
            friendsList.Visibility = Visibility.Collapsed;
            closeSearch_button.Visibility = Visibility.Visible;
            searchResults.Visibility = Visibility.Collapsed;
            noFriends.Visibility = Visibility.Collapsed;
        }

        private void closeSearch_button_Click(object sender, RoutedEventArgs e)
        {
            noResults.Visibility = Visibility.Collapsed;
            friendsList.Visibility = Visibility.Visible;
            searchResults.Visibility = Visibility.Collapsed;
            closeSearch_button.Visibility = Visibility.Collapsed;
            loadFriends();
        }

        private void addFriend_button_Click(object sender, RoutedEventArgs e)
        {
            var value = ((Button)sender).Tag;
            UVM.addFriend(value.ToString());
        }

        private void messageFriend_button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(((Button)sender).Tag);
            this.Frame.Navigate(typeof(SendMessageView), ((Button)sender).Tag);
        }
    }
}
