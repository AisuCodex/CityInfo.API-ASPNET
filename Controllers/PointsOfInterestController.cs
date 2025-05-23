using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace CityInfo.API.Controllers
{
  [Route("api/v{version:apiVersion}/cities/{cityId}/pointsofinterest")]
  [ApiController]
  [Authorize (Policy = "AllowedCities")]
  [Produces("application/json")]
  [ApiVersion("2")]


  public class PointsOfInterestController : ControllerBase
  {

    private readonly ILogger<PointsOfInterestController> _logger;
    private readonly IMailService _mailService;
    private readonly ICityInfoRepository _cityInfoRepository;
    private readonly IMapper _mapper;
    
    

    public PointsOfInterestController(ILogger<PointsOfInterestController> logger,
      IMailService mailService,
       ICityInfoRepository cityInfoRepository,
       IMapper mapper)
    {
      _logger = logger ??
       throw new ArgumentNullException(nameof(logger));
      _mailService = mailService ??
       throw new ArgumentNullException(nameof(mailService));
      _cityInfoRepository = cityInfoRepository ??
       throw new ArgumentNullException(nameof(cityInfoRepository));
      _mapper = mapper ??
       throw new ArgumentNullException(nameof(mapper));
    }


    //GET ACTION
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(
      int cityId)
    {
      //Authorization
      var cityName = User.Claims.FirstOrDefault(c => c.Type == "city")?.Value;
      
      if(!await _cityInfoRepository.CityNameMatchesCityId(cityName, cityId))
      {
        return Forbid();
      }

      if(!await _cityInfoRepository.CityExistsAsync(cityId))
      {
        _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of interest.");
        return NotFound();
      }
      var pointsOfInterestForCity = await _cityInfoRepository
      .GetPointOfInterestsForCityAsync(cityId);

      return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity));
    }
    

    //GET ACTION
    [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
    public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointOfInterestId)
    {
      if(!await _cityInfoRepository.CityExistsAsync(cityId))
      {
        return NotFound();
      }
      var pointOfInterest =await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
      if(pointOfInterest == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
    }
    


    //POST ACTION
    [HttpPost]
    public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(int cityId, PointsOfInterestForCreationDto pointOfInterest)
    {
      if(!await _cityInfoRepository.CityExistsAsync(cityId))
      {
        return NotFound();
      }

      var finalPointOfInterest = _mapper.Map<Entities.PointOfInterest>(pointOfInterest);
      
      await _cityInfoRepository.AddPointOfInterestForCityAsync(cityId, finalPointOfInterest);

      await _cityInfoRepository.SaveChangesAsync();

      var createdPointOfInterestToReturn = _mapper.Map<Models.PointOfInterestDto>(finalPointOfInterest);

      return CreatedAtRoute("GetPointOfInterest", new
      {
        cityId = cityId,
        pointOfInterestId = createdPointOfInterestToReturn.Id
      }, createdPointOfInterestToReturn);
    }



    //PUT ACTION
    [HttpPut("{pointOfInterestId}")]
    public async Task<ActionResult> UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
    {
      if(!await _cityInfoRepository.CityExistsAsync(cityId))
      {
        return NotFound();
      }
      var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
      if(pointOfInterestEntity == null)
      {
        return NotFound();
      }
      _mapper.Map(pointOfInterest, pointOfInterestEntity);
      await _cityInfoRepository.SaveChangesAsync();
      return NoContent();
    }


    //PATCH ACTION
    [HttpPatch("{pointOfInterestId}")]
    public async Task<ActionResult> PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
    JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
    {
      if(!await _cityInfoRepository.CityExistsAsync(cityId))
      {
        return NotFound();
      }
      var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
      if(pointOfInterestEntity == null)
      {
        return NotFound();
      }
      var pointOfInterestToPatch = _mapper.Map<PointOfInterestForUpdateDto>(pointOfInterestEntity);
      patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
      if(!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if(!TryValidateModel(pointOfInterestToPatch))
      {
        return ValidationProblem(ModelState);
      }
      _mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);
      await _cityInfoRepository.SaveChangesAsync();
      return NoContent();
    }


    //DELETE ACTION
    [HttpDelete("{pointOfInterestId}")]
    public async Task<ActionResult> DeletePointOfInterest(int cityId, int pointOfInterestId)
    {
      if(!await _cityInfoRepository.CityExistsAsync(cityId))
      {
        return NotFound();
      }
      var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
      if(pointOfInterestEntity == null)
      {
        return NotFound();
      }
      _cityInfoRepository.DeletePointOfInterest(pointOfInterestEntity);
      await _cityInfoRepository.SaveChangesAsync();
      _mailService.Send("Point of interest deleted.", $"Point of interest {pointOfInterestEntity.Name} with id {pointOfInterestEntity.Id} was deleted.");
      return NoContent();
    }
  }
 }
