namespace WebApplication.DAL.Entities
{
    public class Pet : BaseType
    {
        public string Name { get; set; }

        public virtual User User { get; set; }
    }
}