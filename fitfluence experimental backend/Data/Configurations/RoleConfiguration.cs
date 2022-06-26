using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitfluence_experimental_backend.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        // superadmin, full control over the platform
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        // Customer buying schedules or using the app
                        Name = "Customer",
                        NormalizedName = "CUSTOMER"
                    },
                    new IdentityRole
                    {
                        // Influencer or personal trainer selling
                        Name = "Partner",
                        NormalizedName = "PARTNER"
                    },
                    new IdentityRole
                    {
                        // able to do basic administration
                        Name = "Support",
                        NormalizedName = "SUPPORT"
                    }
                );
        }
    }
}
