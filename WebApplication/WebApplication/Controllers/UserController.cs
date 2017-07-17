using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using WebApplication.BLL.DTO;
using WebApplication.BLL.Infrastructure.Exceptions;
using WebApplication.BLL.Interfaces;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController()
        {
        }

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var userDtos = _userService.GetAll();
            var userViewModels = _mapper.Map<IEnumerable<User>>(userDtos);

            return Json(userViewModels);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var userDto = _userService.GetAll().FirstOrDefault(x => x.Id == id);
            var user = _mapper.Map<User>(userDto);

            return Json(user);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<UserDto>(user);
                _userService.Create(userDto);

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/pets")]
        public IHttpActionResult GetPets(int id)
        {
            try
            {
                var userPetDtos = _userService.GetUserPets(id);
                var userPets = _mapper.Map<IEnumerable<Pet>>(userPetDtos);

                return Json(userPets);
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}