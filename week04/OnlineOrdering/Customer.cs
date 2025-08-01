public class Customer
{
    private string _customerName;
    private Address _address;

    public Customer(string customerName, Address address)
    {
        _customerName = customerName;
        _address = address;
    }

    public bool LivesInUsa()
    {
        return _address.IsInUsa();
    }

    public string GetCustomerName()
    {
        return _customerName;
    }

    public string GetShippingAddress()
    {
        return _address.GetAddress();
    }
}