using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model;

public class CartItem
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Guid CartId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}