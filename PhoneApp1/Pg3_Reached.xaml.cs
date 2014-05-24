﻿using System;
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
        DateTime initialDate;
        PassParameters ps;

        public FinalPage()
        {
            InitializeComponent();
            ps = (PassParameters)NavigationService.GetNavigationData();
            phoneNumber = ps.getPhoneNumber();
            initialDate = ps.getInitialDate();
        }

        public void sendText()
        {

            GeoLocation GL = new GeoLocation();
            SmsComposeTask SMSCompose = new SmsComposeTask();
            SMSCompose.To = phoneNumber;

            double speed = CalculateSpeed();

            String location = GL.GetLocationProperty();
            
            SMSCompose.Body = "I have arrived safely to my destination! (Avg Speed: "+speed+"mph)";
            
            SMSCompose.Show();

        }

        public double CalculateSpeed()
        {
            TimeSpan elapsedTime = DateTime.UtcNow - initialDate;
            GeoLocation GL = new GeoLocation();
            GL.Location();

            /*dlon = lon2 - lon1 
            dlat = lat2 - lat1 
            a = (sin(dlat/2))^2 + cos(lat1) * cos(lat2) * (sin(dlon/2))^2 
            c = 2 * atan2( sqrt(a), sqrt(1-a) ) 
            d = R * c (where R is the radius of the Earth)*/

            double lat1 =  DegreeToRadian(ps.getInitialLatitude());
            double lat2 =  DegreeToRadian(GL.getLatitude());
            double lon1 = DegreeToRadian(ps.getInitialLongitude());
            double lon2 = DegreeToRadian(GL.getLongitude());

            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow((Math.Sin(dlat / 2)),2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow((Math.Sin(dlon / 2)),2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = 3961 * c; //3961 miles = Radius of the Earth. It is equivalent to 6373 km

            //     miles / second
            double speed = distance / elapsedTime.TotalHours;

           // return Math.Round(speed,2);
           // MessageBox.Show(elapsedTime.TotalHours.ToString());
            return speed;
            
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sendText();
        }
    }
}