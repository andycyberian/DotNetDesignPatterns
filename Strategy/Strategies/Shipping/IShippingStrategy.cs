using Strategy.Models;

namespace Strategy.Strategies.Shipping;

public interface IShippingStrategy
{
    void Ship(Order order);
}
