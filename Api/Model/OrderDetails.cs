using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model;

public class OrderDetails
{
    [Key]
    public Guid OrderDetailId { get; set; }
    [Required]
    public Guid OrderHeaderId { get; set; }
    [Required]
    public Guid ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public string ItemName { get; set; }
    [Required]
    public decimal Price { get; set; }
}