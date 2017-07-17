using System.Data.Entity.ModelConfiguration;
using WebApplication.DAL.Entities;

namespace WebApplication.DAL.EntityConfigurations
{
    public class PetConfiguration : EntityTypeConfiguration<Pet>
    {
        public PetConfiguration()
        {
            HasRequired(x => x.User);
        }
    }
}