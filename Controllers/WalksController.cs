using AutoMapper;
using IndiaWalks.Models.Domain;
using IndiaWalks.Models.DTO;
using IndiaWalks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IndiaWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IwalkRepository walkRepository;

        public WalksController(IMapper mapper, IwalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpPost]

        public async Task<IActionResult> CreateAsync([FromBody] AddWalkDTORequest addWalkDtoRequest)
        {
            //// Validate request
            //if (addWalkDtoRequest == null)
            //{
            //    return BadRequest("Invalid request data.");
            //}

            // Map the DTO to Domain Model
            var walkDomain = mapper.Map<Walk>(addWalkDtoRequest);

            // Save to the database
            await walkRepository.CreateAsync(walkDomain);
            //map domain to dto
            return Ok(mapper.Map<WalkDTO>(walkDomain));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery]int pageNumber = 1, [FromQuery]int PageSize=100)
        {
            var walksdomainModel = await walkRepository.GetAllAsync();
            throw new Exception("This is a New exception");

            return Ok(mapper.Map<List<WalkDTO>>(walksdomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel=await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //Map domainmodel to DTO
           return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateById([FromRoute] Guid id,UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            var walkDomainModel=mapper.Map<Walk>(updateWalkRequestDTO);

            walkDomainModel = await walkRepository.UpdateByIdAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }
              return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }
        //Delete
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deleteDomainModel = await walkRepository.DeleteAsync(id);
            if (deleteDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(deleteDomainModel));
        }
    }
}

