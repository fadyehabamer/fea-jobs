using JobPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Data.Configurations
{
    // IEntityTypeConfiguration<AppRole> is used to configure the entity type AppRole
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRoles");
            builder.HasKey(x => x.Id); // which is inherited from IdentityRole<Guid>
            builder.Property(x => x.Description).HasMaxLength(256);
        }
    }
}