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
    public partial class Page1 : PhoneApplicationPage
    {

        String phoneNumber = null;

        public Page1()
        {
            InitializeComponent();
            phoneNumber = (String)NavigationService.GetNavigationData();
            
        }

        public void sendText()
        {
           
            SmsComposeTask SMSCompose = new SmsComposeTask();
            SMSCompose.To = phoneNumber;
            SMSCompose.Body = "Kelly has arrived safely to her destination ()!";
            SMSCompose.Show();

        }
    }
}