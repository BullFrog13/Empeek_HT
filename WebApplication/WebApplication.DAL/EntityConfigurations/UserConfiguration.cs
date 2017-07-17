using System.Data.Entity.ModelConfiguration;
using WebApplication.DAL.Entities;

namespace WebApplication.DAL.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(x => x.Pets);
        }
    }
}
