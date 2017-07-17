using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApplication.BLL.DTO;
using WebApplication.BLL.Infrastructure.Exceptions;
using WebApplication.BLL.Interfaces;
using WebApplication.DAL.Entities;
using WebApplication.DAL.Interfaces;

namespace WebApplication.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _unitOfWork.Users.Create(user);

            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var user = _unitOfWork.Users.Get(id);

            if (user == null)
            {
                throw new EntityNotFoundException($"User with id = {id} wasn't found", "User");
            }

            _unitOfWork.Users.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _unitOfWork.Users.GetAll().ToList();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return userDtos;
        }

        public IEnumerable<PetDto> GetUserPets(int id)
        {
            var user = _unitOfWork.Users.Get(id);

            if(user == null)
            {
                throw new EntityNotFoundException($"User with id = {id} wasn't found", "User");
            }

            var userPets = _unitOfWork.Pets.Find(x => x.User.Id == id);
            var userPetDtos = _mapper.Map<IEnumerable<PetDto>>(userPets);

            return userPetDtos;
        }
    }
}