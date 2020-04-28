using Microsoft.EntityFrameworkCore;
using RegionAPI.ModelConfigs;
using RegionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegionAPI
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
           : base(options)
        {

        }

        public DbSet<MyModel> MyModels { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
