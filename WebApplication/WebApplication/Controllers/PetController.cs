using System.Web.Http;
using AutoMapper;
using WebApplication.BLL.DTO;
using WebApplication.BLL.Infrastructure.Exceptions;
using WebApplication.BLL.Interfaces;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/pets")]
    public class PetController : ApiController
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetController(IPetService petService, IMapper mapper)
        {
            _petService = petService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(Pet pet)
        {
            if(ModelState.IsValid)
            {
                var petDto = _mapper.Map<PetDto>(pet);
                _petService.Create(petDto);

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
                _petService.Delete(id);
                return Ok();
            }
            catch(EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}