namespace WebApplication.Models
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User User { get; set; }
    }
}