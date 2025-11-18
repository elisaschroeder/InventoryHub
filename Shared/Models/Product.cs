using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Product
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Product name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Product name must be between 1 and 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1,000,000")]
    public decimal Price { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative")]
    public int Stock { get; set; }
}
