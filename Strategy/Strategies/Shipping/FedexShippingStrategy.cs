﻿using Strategy.Models;

namespace Strategy.Strategies.Shipping;

public class FedexShippingStrategy : IShippingStrategy
{
    public void Ship(Order order)
    {
        using (var client = new HttpClient())
        {
            /// TODO: Implement Fedex Shipping Integration

            Console.WriteLine("Order is shipped with Fedex");
        }
    }
}
