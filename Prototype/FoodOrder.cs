namespace Prototype;

public class FoodOrder : Prototype
{
    public string CustomerName { get; set; }
    public bool IsDelivery { get; set; }
    public string[] OrderContents { get; set; }
    public OrderInfo OrderInfo { get; set; }

    public FoodOrder(string customerName, bool isDelivery, string[] orderContents, OrderInfo orderInfo)
    {
        CustomerName = customerName;
        IsDelivery = isDelivery;
        OrderContents = orderContents;
        OrderInfo = orderInfo;
    }

    public override Prototype ShallowCopy()
    {
        return (Prototype)this.MemberwiseClone();
    }

    public override Prototype DeepCopy()
    {
        var clonedOrder = (FoodOrder)this.MemberwiseClone();
        clonedOrder.OrderInfo = new OrderInfo(this.OrderInfo.Id);
        return clonedOrder;
    }

    public override void Debug()
    {
        Console.WriteLine("------- Prototype food order -------");
        Console.WriteLine($"\nName {CustomerName} \nDelivery: {IsDelivery}");
        Console.WriteLine($"Order contents: {string.Join(", ", OrderContents)}\n");
        Console.WriteLine($"Id: {OrderInfo.Id}\n");
    }

}

public class PrototypeManager
{
    private Dictionary<string, Prototype> _prototypeLibrary = new();
    public Prototype this[string key]
    {
        get
        {
            return _prototypeLibrary[key];
        } 
        set
        {
            _prototypeLibrary[key] = value;
        }
    }
}
