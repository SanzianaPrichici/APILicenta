using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APILicenta.Models;

namespace APILicenta.Data
{
    public class APILicentaContext : DbContext
    {
        public APILicentaContext (DbContextOptions<APILicentaContext> options)
            : base(options)
        {
        }

        public DbSet<APILicenta.Models.Client> Client { get; set; }

        public DbSet<APILicenta.Models.User> User { get; set; }
    }
}
