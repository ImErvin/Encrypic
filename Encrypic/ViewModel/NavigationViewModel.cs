using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Encrypic.ViewModel
{
    class NavigationViewModel
    {
        Frame navigationFrame = new Frame();

        public void navigateHome()
        {
            navigationFrame.Navigate(typeof(Views.DashboardView), null);
        }

        public void navigateCamera()
        {
            navigationFrame.Navigate(typeof(Views.DashboardView), null);
        }

        public void navigateSettings()
        {
            navigationFrame.Navigate(typeof(Views.SettingsView), null);
        }

        public void navigateLogout()
        {
            navigationFrame.Navigate(typeof(Views.LoginView), null);
        }

        public void navigateSignin()
        {
            navigationFrame.Navigate(typeof(Views.LoginView), null);
        }

        public void navigateSignup()
        {
            navigationFrame.Navigate(typeof(Views.RegisterView), null);
        }
    }
}
