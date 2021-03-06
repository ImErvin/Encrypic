﻿using Encrypic2017.Data;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Encrypic2017.Views.Dashboard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InboxView : Page
    {
        MessageViewModel MVM;
        public InboxView()
        {
            this.InitializeComponent();
            MVM = new MessageViewModel();
            loadMessages();
        }

        private async void loadMessages()
        {
            try
            {
                Response res = await MVM.searchMessages();
                if (res.status == "OK")
                {
                    if (MVM.searchResults.Count() == 0)
                    {
                        noMessages.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        noMessages.Visibility = Visibility.Collapsed;
                    }

                }
            }
            catch
            {
                Debug.WriteLine("Error loading messages");
            }
            
        }

        private void MessagesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Selection CLICK" + MessagesList.SelectedItem);
            this.Frame.Navigate(typeof(MessagesView), MessagesList.SelectedItem);
        }
    }
}
