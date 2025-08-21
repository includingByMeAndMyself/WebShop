using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model;

public class Cart
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
    [NotMapped]
    public decimal TotalAmount { get; set; }
}