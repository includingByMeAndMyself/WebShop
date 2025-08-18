using System.ComponentModel.DataAnnotations;

namespace Api.Model;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Descritopr { get; set; }
    public string SpecialTag { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
}