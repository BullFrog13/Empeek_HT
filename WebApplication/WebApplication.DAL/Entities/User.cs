using System.Collections.Generic;

namespace WebApplication.DAL.Entities
{
    public class User : BaseType
    {
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}