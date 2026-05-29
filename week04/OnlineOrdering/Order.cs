using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = 0;

        foreach (Product product in _products)
        {
            totalCost = totalCost + product.GetCost();
        }

        if (_customer.LivesInUSA())
        {
            totalCost = totalCost + 5;
        }
        else
        {
            totalCost = totalCost + 35;
        }

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";

        foreach (Product product in _products)
        {
            label = label + $"- {product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}