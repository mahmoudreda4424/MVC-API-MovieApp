using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Services
{
    public class MonieApiService : DbContext
    {
        public MonieApiService (DbContextOptions<MonieApiService> options)
            : base(options)
        {
        }

        public DbSet<WebApp.Models.Movie> Movie { get; set; } = default!;
    }
}
