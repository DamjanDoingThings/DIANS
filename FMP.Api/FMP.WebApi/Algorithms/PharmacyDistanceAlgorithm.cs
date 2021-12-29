using FMP.Database.Database.Models;
using FMP.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMP.WebApi.Algorithms
{
    public class Coordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    public class PharmacyDistanceAlgorithm
    {
        public static List<PharmacyDistanceData> Distances(string from, List<Pharmacy> pharmacies)
        {
            var originSplit = from.Split(',');

            var origin = new Coordinate
            {
                Latitude = double.Parse(originSplit[0].Trim(' ').Replace(".", ",")),
                Longitude = double.Parse(originSplit[1].Trim(' ').Replace(".", ",")),
            };

            var pharmacyDistances = new List<PharmacyDistanceData>();
            /// find closest point to fixed
            foreach (var pharmacy in pharmacies)
            {
                var coordSplit = pharmacy.LocationCoordinate.Split(',');
                var coord = new Coordinate
                {
                    Latitude = double.Parse(coordSplit[0].Trim(' ').Replace(".", ",")),
                    Longitude = double.Parse(coordSplit[1].Trim(' ').Replace(".", ",")),
                };

                var distance = Distance(origin, coord);
                pharmacyDistances.Add(new PharmacyDistanceData
                {
                    Pharmacy = pharmacy,
                    Origin = origin,
                    DistanceFromOrigin = distance
                });
            }

            return pharmacyDistances;
        }

        private static double ToRadians(
           double angleIn10thofaDegree)
        {
            // Angle in 10th
            // of a degree
            return (angleIn10thofaDegree *
                           Math.PI) / 180;
        }
        private static double Distance(
            Coordinate coordOrigin,
            Coordinate coordTo)
        {
            double lat1 = coordOrigin.Latitude;
            double lat2 = coordTo.Latitude;
            double lon1 = coordOrigin.Longitude;
            double lon2 = coordTo.Longitude;

            // The math module contains
            // a function named toRadians
            // which converts from degrees
            // to radians.
            lon1 = ToRadians(lon1);
            lon2 = ToRadians(lon2);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            // Haversine formula
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of earth in
            // kilometers. Use 3956
            // for miles
            double r = 6371;

            // calculate the result
            return (c * r);
        }
    }
}
