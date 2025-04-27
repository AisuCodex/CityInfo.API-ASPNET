using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Models;
using CityInfo.API.Services;
using AutoMapper;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace CityInfo.API.Controllers
{
  [ApiController]
  [Authorize (Policy = "AllowedCities")]
  // [Authorize]
  [Produces("application/json")]
  [Route("api/v{version:apiVersion}/cities")]
  [ApiVersion("1")]
  [ApiVersion("2")]
  public class CitiesController : ControllerBase
  {
    private readonly ICityInfoRepository _cityInfoRepository;
    private readonly IMapper _mapper;
    const int maxPageSize = 20;

    public CitiesController(ICityInfoRepository cityInfoRepository,
    IMapper mapper)   
    {
     _cityInfoRepository = cityInfoRepository ?? 
      throw new ArgumentNullException(nameof(cityInfoRepository));
      _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities(
      string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
    {
      if(pageSize > maxPageSize)
      {
        pageSize = maxPageSize;
      }
      var (cityEntities, paginationMetaData) = await _cityInfoRepository
      .GetCitiesAsync(name, searchQuery,pageNumber, pageSize); 
      
       Response.Headers.Add("X-Pagination",
        JsonSerializer.Serialize(paginationMetaData));


      return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cityEntities));
    }

    /// <summary>
    /// Get a city by id
    /// </summary>
    /// <param name="id">The id of the city to get</param>
    /// <param name="includePointsOfInterest">Whether or not to include points of interest</param>
    /// <returns>A city Without Points of Interest</returns>
    /// <response code="200">Returns the requested city</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCity(
      int id, bool includePointsOfInterest = false)
    { 
      var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
      if(city == null)
      {
        return NotFound();
      }
      if(includePointsOfInterest)
      {
        return Ok(_mapper.Map<CityDto>(city));
      }
      return Ok(_mapper.Map<CityWithoutPointOfInterestDto>(city));
    }
  }
}