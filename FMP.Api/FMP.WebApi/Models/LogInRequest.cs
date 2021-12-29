using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMP.WebApi.Models
{
    public class LogInRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
