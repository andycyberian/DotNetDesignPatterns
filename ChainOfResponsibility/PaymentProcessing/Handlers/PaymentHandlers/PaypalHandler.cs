using ChainOfResponsibility.PaymentProcessing.Models;
using ChainOfResponsibility.PaymentProcessing.PaymentProcessors;

namespace ChainOfResponsibility.PaymentProcessing.Handlers.PaymentHandlers;

public class PaypalHandler : IReceiver<Order>
{
    private PaypalPaymentProcessor PaypalPaymentProcessor { get; }
        = new PaypalPaymentProcessor();

    public void Handle(Order order)
    {
        if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Paypal))
        {
            PaypalPaymentProcessor.Finalize(order);
        }
    }
}
