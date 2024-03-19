using Prototype;

Console.WriteLine("Original order:");
var savedOrder = new FoodOrder("Andy", true, new string[] { "Pizza", "Fries", "Coke" }, new OrderInfo(2345));
savedOrder.Debug();

Console.WriteLine("Cloned order:");

var clonedOrder = (FoodOrder)savedOrder.DeepCopy();
clonedOrder.Debug();

Console.WriteLine("Order changes:");
savedOrder.CustomerName = "Bob";
savedOrder.OrderInfo.Id = 5555;
savedOrder.Debug();
clonedOrder.Debug();

var manager = new PrototypeManager();
manager["2/3/2020"] = new FoodOrder("Dave", false, new[] { "Kebab", "Beer" }, new OrderInfo(8912));
Console.WriteLine("Manager clone:");
var managerOrder = (FoodOrder)manager["2/3/2020"].DeepCopy();
managerOrder.Debug();
