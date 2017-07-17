using WebApplication.BLL.DTO;

namespace WebApplication.BLL.Interfaces
{
    public interface IPetService
    {
        void Create(PetDto petDto);

        void Delete(int id);
    }
}