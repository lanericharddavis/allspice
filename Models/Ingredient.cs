using System.ComponentModel.DataAnnotations;

namespace allspice.Models
{
  public class Ingredient
  {
    public string Id { get; set; }
    public string CreatorId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Amount { get; set; }
    public string Notes { get; set; }
  }
}