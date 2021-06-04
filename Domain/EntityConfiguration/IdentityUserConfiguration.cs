using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfiguration
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<CustomIdentityUser>
    {
        public void Configure(EntityTypeBuilder<CustomIdentityUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(200);
        }
    }
}
