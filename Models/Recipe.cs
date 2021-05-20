using System.ComponentModel.DataAnnotations;

namespace allspice.Models
{
  public class Recipe
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
  }
}