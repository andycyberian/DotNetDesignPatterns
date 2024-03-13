using ChainOfResponsibility.PaymentProcessing.Handlers;
using ChainOfResponsibility.PaymentProcessing.Handlers.PaymentHandlers;
using ChainOfResponsibility.PaymentProcessing.Models;
using ChainOfResponsibility.UserProcessing;
using ChainOfResponsibility.UserProcessing.Models;
using System.Globalization;

Console.WriteLine("User processing");
Console.WriteLine("===============");
Console.WriteLine();

UserProcessing();

Console.WriteLine();
Console.WriteLine("==================");
Console.WriteLine("Payment processing");
Console.WriteLine("==================");


PaymentProcessing();

static void UserProcessing()
{
    var user = new User("Filip Ekberg",
                    "870101XXXX",
                    new RegionInfo("SE"),
                    new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));

    var processor = new UserProcessor();

    var result = processor.Register(user);
    Console.WriteLine(result);
    var norge = new User("Filip Ekberg",
                    "870101XXXX",
                    new RegionInfo("NO"),
                    new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));

    result = processor.Register(norge);
    Console.WriteLine(result);
}

static void PaymentProcessing()
{
    var order = new Order();
    order.LineItems.Add(new Item("ATOMOSV", "Atomos Ninja V", 499), 2);
    order.LineItems.Add(new Item("EOSR", "Canon EOS R", 1799), 1);

    order.SelectedPayments.Add(new Payment
    {
        PaymentProvider = PaymentProvider.Paypal,
        Amount = 1000
    });

    order.SelectedPayments.Add(new Payment
    {
        PaymentProvider = PaymentProvider.Invoice,
        Amount = 1797
    });

    Console.WriteLine(order.AmountDue);
    Console.WriteLine(order.ShippingStatus);


    var handler = new PaymentHandler(
        new PaypalHandler(),
        new InvoiceHandler(),
        new CreditCardHandler()
    );

    handler.Handle(order);

    Console.WriteLine(order.AmountDue);
    Console.WriteLine(order.ShippingStatus);
}