public class Product
{
    private string _name;
    private string _id;
    private decimal _price;
    private int _quantity;

    public Product(string productName, string productId, decimal unitPrice, int productQuantity)
    {
        _name = productName;
        _id = productId;
        _price = unitPrice;
        _quantity = productQuantity;
    }

    public decimal GetCost()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _id;
    }
}