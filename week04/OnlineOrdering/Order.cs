public class Order
{
    private Customer _customer;
    private List<Product> _productsList = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _productsList.Add(product);
    }

    public int GetTotalCost()
    {
        int productTotal = 0;

        foreach (Product product in _productsList)
        {
            productTotal += product.GetProductTotalCost();
        }

        int shippingCost = 0;

        if (_customer.LivesInUsa())
        {
            shippingCost = 5;
        }

        else
        {
            shippingCost = 35;
        }

        int totalPrice = productTotal + shippingCost;
        return totalPrice;
    }

    public string PackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in _productsList)
        {
            packingLabel += $"Product: {product.GetProductName()} - ID: {product.GetProductId()}\n";
        }

        return packingLabel;
    }

    public string ShippingLabel()
    {
        return $"{_customer.GetCustomerName()} - Address: {_customer.GetShippingAddress()}";
    }
}