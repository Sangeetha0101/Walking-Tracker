using AutoMapper;
using IndiaWalks.Data;
using IndiaWalks.Models.Domain;
using IndiaWalks.Models.DTO;
using IndiaWalks.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IndiaWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionController : ControllerBase
    {
        private readonly IndiaWalksDBContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper autoMapper;
        private readonly ILogger<RegionController> logger1;

        public RegionController(IndiaWalksDBContext dbContext, IRegionRepository regionRepository, IMapper autoMapper,ILogger<RegionController> logger1)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.autoMapper = autoMapper;
            this.logger1 = logger1;
        }

        [HttpGet]
        //[Authorize(Roles="Reader")]
        public async Task <IActionResult> GetAll()
        {

            logger1.LogInformation("GetAll Region action method was invoked");
            
            var regionsDomain = await regionRepository.GetAllAsync();
            logger1.LogInformation($"Finisged GetAll Region Request with Data:{JsonSerializer.Serialize(regionsDomain)}");
            
           

            return Ok(autoMapper.Map<List<RegionDTO>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetRegionByIdAsync([FromRoute] Guid id)
        {
            var region = await regionRepository.GetRegionByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }

        

            return Ok(autoMapper.Map<RegionDTO>( region));
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> CreateRegion([FromBody] AddRegionDTORequest addregionDTOrequest)
        {
            if (ModelState.IsValid)
            {
                // Mapping AddRegionDTORequest to Domain Model (Region)
                var domainRegion = autoMapper.Map<Region>(addregionDTOrequest);

                // Use domain model to create a new region
                domainRegion = await regionRepository.CreateAsync(domainRegion);


                // Map Domain Model (Region) to DTO for the response
                var regionDto = autoMapper.Map<RegionDTO>(domainRegion);

                // Return 201 Created response with the location of the new resource
                return CreatedAtAction(nameof(GetRegionByIdAsync), new { id = regionDto.Id }, regionDto);
            }
            else
                return BadRequest(ModelState);    
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateRegionDto updateRegionDto)
        {
            //Map Dto to domain model
            var domainRegion = autoMapper.Map<Region>(updateRegionDto);
            //Check if ID exists
               domainRegion = await regionRepository.UpdateAsync(id, domainRegion);

            if (domainRegion == null)
            {
                return NotFound();
            }

            //converting domain to dto

            return Ok(autoMapper.Map<RegionDTO>(domainRegion));
         }
       

            [HttpDelete]
            [Route("{id:guid}")]
            [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
            {
                var regionDomainModel = await regionRepository.DeleteAsync(id);

                
                if (regionDomainModel == null)
                {
                    return NotFound();
                }

            // Create a DTO to return as response
            

             return Ok(autoMapper.Map<RegionDTO>(regionDomainModel));
            }

        }

    }

