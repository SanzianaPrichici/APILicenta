using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILicenta.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
        public string Parola { get; set; }
        public Client Cli { get; set; }
    }
}
