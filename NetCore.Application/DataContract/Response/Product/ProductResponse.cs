namespace NetCore.Application.DataContract.Response.Product;

public sealed class ProductResponse
{
    public string? Id { get; set; }
    public string? Description { get; set; }
    public string? SelValue { get; set; }
    public int Stock { get; set; }
}