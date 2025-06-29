using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccess.Concrete
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1435;initial catalog=MultiShopCargoDb;TrustServerCertificate=true;User=sa;Password=123456789Aa*");
        }

        DbSet<CargoDetail> CargoDetails { get; set; }
        DbSet<CargoCustomer> CargoCustomers { get; set; }
        DbSet<CargoCompany> CargoCompanies { get; set; }
        DbSet<CargoOperation> CargoOperations { get; set; }
    }
}
