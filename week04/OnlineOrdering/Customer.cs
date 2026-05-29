public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string customerName, Address customerAddress)
    {
        _name = customerName;
        _address = customerAddress;
    }

    public bool LivesInUSA()
    {
        return _address.IsUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }
}