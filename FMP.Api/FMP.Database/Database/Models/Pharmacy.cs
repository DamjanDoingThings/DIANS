using System;
using System.Collections.Generic;

#nullable disable

namespace FMP.Database.Database.Models
{
    public partial class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocationCoordinate { get; set; }
    }
}
