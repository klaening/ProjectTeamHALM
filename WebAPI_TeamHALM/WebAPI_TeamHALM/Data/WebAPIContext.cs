using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI_TeamHALM_Domain.Models.Departments> Departments { get; set; }
    }
}
