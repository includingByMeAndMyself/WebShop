namespace Api.Model;

public class PaymentResponse
{
    public bool IsSuccess { get; set; }
    public string IntentId { get; set; }
    public string Secret { get; set; }
    public string ErrorMessage { get; set; }
}