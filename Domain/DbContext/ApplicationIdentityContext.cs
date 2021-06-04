using Domain.EntityConfiguration;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain.DbContext
{
    public class ApplicationIdentityContext : IdentityDbContext<CustomIdentityUser>
    {
        public ApplicationIdentityContext()
        {

        }
        public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=MMS_Portal;uid=sa;pwd=123456;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new IdentityUserConfiguration());
        }
    }
}
