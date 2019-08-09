using GigHubApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHubApp.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(au => au.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(au => au.Followees)
                .WithRequired(au => au.Follower)
                .WillCascadeOnDelete(false);

            HasMany(au => au.Followers)
                .WithRequired(au => au.Followee)
                .WillCascadeOnDelete(false);

            HasMany(au => au.UserNotifications)
                .WithRequired(au => au.User)
                .WillCascadeOnDelete(false);
        }
    }
}