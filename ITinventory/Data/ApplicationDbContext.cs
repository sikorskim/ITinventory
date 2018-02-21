using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITinventory.Models;

namespace ITinventory.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ITinventory.Models.Address> Address { get; set; }
        public DbSet<ITinventory.Models.Device> Device { get; set; }
        public DbSet<ITinventory.Models.DeviceModel> DeviceModel { get; set; }
        public DbSet<ITinventory.Models.DeviceModelParameter> DeviceModelParameter { get; set; }
        public DbSet<ITinventory.Models.DeviceParameter> DeviceParameter { get; set; }
        public DbSet<ITinventory.Models.DeviceType> DeviceType { get; set; }
        public DbSet<ITinventory.Models.Invoice> Invoice { get; set; }
        public DbSet<ITinventory.Models.License> License { get; set; }
        public DbSet<ITinventory.Models.LicenseDevice> LicenseDevice { get; set; }
        public DbSet<ITinventory.Models.LicenseType> LicenseType { get; set; }
        public DbSet<ITinventory.Models.Localization> Localization { get; set; }
        public DbSet<ITinventory.Models.Manufacturer> Manufacturer { get; set; }
        public DbSet<ITinventory.Models.Software> Software { get; set; }
        public DbSet<ITinventory.Models.SoftwareType> SoftwareType{ get; set; }
        public DbSet<ITinventory.Models.Status> Status { get; set; }
        public DbSet<ITinventory.Models.Supplier> Supplier { get; set; }
        public DbSet<ITinventory.Models.Company> Company { get; set; }
        public DbSet<ITinventory.Models.Department> Department { get; set; }
    }
}
