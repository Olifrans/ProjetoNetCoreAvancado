namespace NetCore.Application.DataContract.Request.Product;

public sealed class CreateProductRequest
{
    public string? Description { get; set; }
    public string? SelValue { get; set; }
    public int Stock { get; set; }
}