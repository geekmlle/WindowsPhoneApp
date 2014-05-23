using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace PhoneApp1
{
    public partial class FinalPage : PhoneApplicationPage
    {
        String phoneNumber = null;

        public FinalPage()
        {
            InitializeComponent();
            phoneNumber = (String)NavigationService.GetNavigationData();
        }

        public void sendText()
        {
            GeoLocation GL = new GeoLocation();
            SmsComposeTask SMSCompose = new SmsComposeTask();
            SMSCompose.To = phoneNumber;
            SMSCompose.Body = "I have arrived safely to my destination!";
            SMSCompose.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sendText();
        }
    }
}