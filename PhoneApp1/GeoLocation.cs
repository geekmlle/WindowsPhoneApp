using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using Windows.Devices.Geolocation;
using System.Windows.Threading;

namespace PhoneApp1
{
    class GeoLocation
    {

        public String GetLocationCourseAndSpeed()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
           watcher.TryStart(true, TimeSpan.FromMilliseconds(1000));

            if (watcher.Position.Location.IsUnknown != true)
            {
                GeoCoordinate coord = watcher.Position.Location;
                System.Diagnostics.Debug.WriteLine("Course: {0}, Speed: {1}",
                    coord.Course,
                    coord.Speed);
                return ("Course: "+coord.Course+", Speed: "+coord.Speed);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Unknown");
                return ("Return Unknown");
            }
        }

        public String GetLocationProperty()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            GeoCoordinate coord = watcher.Position.Location;

            if (coord.IsUnknown != true)
            {
                System.Diagnostics.Debug.WriteLine("Lat: {0}, Long: {1}",
                    coord.Latitude,
                    coord.Longitude);
                return ("Latitude: " + coord.Latitude + ", Longitude: " + coord.Longitude);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Unknown latitude and longitude.");
                return ("Unknown Latitude and Longitude");
            }
        }


    }
}
