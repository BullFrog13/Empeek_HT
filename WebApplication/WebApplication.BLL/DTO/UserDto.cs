using System.Collections.Generic;

namespace WebApplication.BLL.DTO
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<PetDto> Pets { get; set; }
    }
}