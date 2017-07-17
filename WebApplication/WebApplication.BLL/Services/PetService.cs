using AutoMapper;
using WebApplication.BLL.DTO;
using WebApplication.BLL.Infrastructure.Exceptions;
using WebApplication.BLL.Interfaces;
using WebApplication.DAL.Entities;
using WebApplication.DAL.Interfaces;

namespace WebApplication.BLL.Services
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(PetDto petDto)
        {
            var pet = _mapper.Map<Pet>(petDto);
            _unitOfWork.Pets.Create(pet);

            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var pet = _unitOfWork.Pets.Get(id);

            if (pet == null)
            {
                throw new EntityNotFoundException($"Pet with id = {id} wasn't found", "Pet");
            }

            _unitOfWork.Pets.Delete(id);
            _unitOfWork.Save();
        }
    }
}