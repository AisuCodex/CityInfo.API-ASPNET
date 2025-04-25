using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
  public class PointOfInterestForUpdateDto
  {
    [Required (ErrorMessage = "The Name field is required.")]
    [MaxLength(50)]
    public string Name {get; set;} = string.Empty;
    [Required (ErrorMessage = "Description field is required.")]
    [MaxLength(200)]
    public string? Description {get; set;}
  }
}