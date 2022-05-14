using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Class
    {
        public static double Area(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public static double Sota(double coeffBuilders, double radiusStation, double radiusCity)
        {
            return coeffBuilders * (radiusStation / radiusCity) * (radiusStation / radiusCity);
        }
        
        public static int StationCount(double sota, double clauster)
        {
            return (int)Math.Round(sota / clauster);
        }

        public static int AdaptiveSummary(double d1, double d2, double d3)
        {
            return (int)(Math.Pow(d1, 5 / 2) + Math.Pow(d2, 3 / 2) + Math.Pow(d3, 1 / 2));
        }
    }
}
