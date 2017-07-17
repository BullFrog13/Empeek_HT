using System.ComponentModel.DataAnnotations;

namespace WebApplication.DAL.Entities
{
    public abstract class BaseType
    {
        [Key]
        public int Id { get; set; }
    }
}