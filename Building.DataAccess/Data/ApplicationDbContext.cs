
using System.Data;
using Building.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;




namespace Building.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<FlatType> FlatTypes { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<ExpenditureDetail> ExpenditureDetails { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<MonthEntry> MonthEntries { get; set; }

        public DbSet<TypeIdentifier> TypeIdentifiers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);// for identityDBcontext If we don't call base.OnModelCreating(modelBuilder), all that setup is skipped. Setting up primary keys for tables like IdentityUserLogin, IdentityRole, etc.

                                                   //Defining relationships between identity tables(e.g., user ↔ roles)

                                                   //Mapping to default table names like AspNetUsers, AspNetRoles, etc.
        
            
            // Define one-to-many relationship
            modelBuilder.Entity<Expenditure>()
            .HasMany(e => e.ExpenditureDetails)
            .WithOne(d => d.Expenditure)
            .HasForeignKey(d => d.ExpenditureId);

            modelBuilder.Entity<Floor>().HasData(
            new Floor { FloorId = 1, FloorName = "1" },
            new Floor { FloorId = 2, FloorName = "2" },
            new Floor { FloorId = 3, FloorName = "3" }

            );
            modelBuilder.Entity<FlatType>().HasData(
            new FlatType { FlatTypeId = 1, FlatTypeName = "Flat" },
            new FlatType { FlatTypeId = 2, FlatTypeName = "Commercial" },
            new FlatType { FlatTypeId = 3, FlatTypeName = "Shop" }

            );

            modelBuilder.Entity<Flat>().HasData(
            new Flat { FlatId = 1, FlatName = "101-A", FlatSize = "1200", FlatRent = 10000, FloorId = 1, FlatTypeId = 1 },
            new Flat { FlatId = 2, FlatName = "101-B", FlatSize = "1400", FlatRent = 20000, FloorId = 1, FlatTypeId = 1 },
            new Flat { FlatId = 3, FlatName = "103-C", FlatSize = "1600", FlatRent = 25000, FloorId = 1, FlatTypeId = 1 }

            );
            modelBuilder.Entity<Location>().HasData(
            new Location { LocationId = 1, LocationName = "Dhaka_A", Description = "10 rooms" },
            new Location { LocationId = 2, LocationName = "Dhaka_B", Description = "12 rooms" },
            new Location { LocationId = 3, LocationName = "Dhaka_C", Description = "4 rooms"}

);
        }


    }
}
