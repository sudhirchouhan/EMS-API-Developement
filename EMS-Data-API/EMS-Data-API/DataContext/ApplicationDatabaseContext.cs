using EMS_Data_API.Models;
using EMS_Data_API.Models.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMS_Data_API.DataContext
{
    public class ApplicationDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  
        }
        public DbSet<ApplicationUser> tblUsers {  get; set; }
        public DbSet<BoothMaster> tblBoothMaster { get; set; }
        public DbSet<VidhansabhaMaster> tblVidhansabhaMaster { get; set; }
    }
}
