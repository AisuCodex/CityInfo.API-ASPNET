using CityInfo.API.Entities;
using CityInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
  public class CityInfoRepository : ICityInfoRepository
  {
    private readonly CityInfoContext _context;

    public CityInfoRepository(CityInfoContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<City>> GetCitiesAsync()
    {
      return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
    }
    
    public async Task<bool> CityNameMatchesCityId(string? cityName, int cityId)
    {
      return await _context.Cities.AnyAsync(c => c.Id == cityId && c.Name == cityName);
    }

    //search filter
    public async Task<(IEnumerable<City>, PaginationMetaData)> GetCitiesAsync(
      String? name, String? searchQuery, int pageNumber, int pageSize)
    {
      //collection to start from
      var collection = _context.Cities as IQueryable<City>;
      if (!string.IsNullOrEmpty(name))
      {
        name = name.Trim();
        collection = collection.Where(c => c.Name == name);
      }
      if (!string.IsNullOrEmpty(searchQuery))
      {
        searchQuery = searchQuery.Trim();
        collection = collection.Where(a => a.Name.Contains(searchQuery)
        || a.Description != null && a.Description.Contains(searchQuery));
      }

      var totalItemCount = await collection.CountAsync();

      var paginationMetaData = new PaginationMetaData(
        totalItemCount, pageSize, pageNumber);

      var collectionToReturn = await collection.OrderBy(c => c.Id) 
      .Skip(pageSize * (pageNumber - 1))
      .Take(pageSize)
      .ToListAsync();

      return (collectionToReturn, paginationMetaData);
    }
    



    public async Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest)
    {
      if (includePointsOfInterest)
      {
        return await _context.Cities.Include(c => c.PointsOfInterest).Where(c => c.Id == cityId).FirstOrDefaultAsync();
      }
      return await _context.Cities.Where(c => c.Id == cityId).FirstOrDefaultAsync();
    }
    
    public async Task<bool> CityExistsAsync(int cityId)
    {
      return await _context.Cities.AnyAsync(c => c.Id == cityId);
    }

    public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(
      int cityId, 
      int pointOfInterestId)
    {
     return await _context.PointsOfInterest
      .Where(p => p.CityId == cityId && p.Id == pointOfInterestId)
      .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<PointOfInterest>> GetPointOfInterestsForCityAsync(int cityId)
    {
      return await _context.PointsOfInterest
        .Where(p => p.CityId == cityId)
        .ToListAsync();
    }
    public async Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest)
    {
      var city = await GetCityAsync(cityId, false);
      if(city != null)
      {
        city.PointsOfInterest.Add(pointOfInterest);
      }
    }
        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
    {
      _context.PointsOfInterest.Remove(pointOfInterest);
    }
    public async Task<bool> SaveChangesAsync()
    {
      return (await _context.SaveChangesAsync() >= 0);
    }
    

  }
}