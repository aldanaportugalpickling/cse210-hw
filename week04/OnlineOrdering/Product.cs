public class Product
{
    private string _productName;
    private int _productId;
    private int _price;
    private int _quantityProduct;

    public Product(string productName, int productId, int price, int quantityProduct)
    {
        _productName = productName;
        _productId = productId;
        _price = price;
        _quantityProduct = quantityProduct;
    }

    public int GetProductTotalCost()
    {
        int productTotalCost = _price * _quantityProduct;
        return productTotalCost;
    }

    public string GetProductName()
    {
        return _productName;
    }

    public int GetProductId()
    {
        return _productId;
    }
}