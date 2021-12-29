using FMP.Database.Database.Models;
using FMP.WebApi.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMP.WebApi.Models
{
    public class PharmacyDistanceData
    {
        public Pharmacy Pharmacy { get; set; }

        public Coordinate Origin { get; set; }

        public double DistanceFromOrigin { get; set; }
    }
}
