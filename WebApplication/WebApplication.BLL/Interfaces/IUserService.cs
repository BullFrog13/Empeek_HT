using System.Collections.Generic;
using WebApplication.BLL.DTO;

namespace WebApplication.BLL.Interfaces
{
    public interface IUserService
    {
        void Create(UserDto userDto);

        void Delete(int id);

        IEnumerable<UserDto> GetAll();

        IEnumerable<PetDto> GetUserPets(int id);
    }
}