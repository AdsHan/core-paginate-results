namespace PRE.Pagination.API.Data.Entities;

public class ProductModel
{

    // EF Construtor
    public ProductModel()
    {
    }

    public ProductModel(string title, string description, double price, int quantity)
    {
        Title = title;
        Description = description;
        Price = price;
        Quantity = quantity;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

}
