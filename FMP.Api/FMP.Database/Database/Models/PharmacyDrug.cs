using System;
using System.Collections.Generic;

#nullable disable

namespace FMP.Database.Database.Models
{
    public partial class PharmacyDrug
    {
        public int Id { get; set; }
        public int PharmacyId { get; set; }
        public int DrugId { get; set; }
    }
}
