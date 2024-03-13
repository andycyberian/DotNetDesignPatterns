using ChainOfResponsibility.PaymentProcessing.Models;
using ChainOfResponsibility.PaymentProcessing.PaymentProcessors;

namespace ChainOfResponsibility.PaymentProcessing.Handlers.PaymentHandlers;

public class CreditCardHandler : IReceiver<Order>
{
    public CreditCardPaymentProcessor CreditCardPaymentProcessor { get; }
        = new CreditCardPaymentProcessor();

    public void Handle(Order order)
    {
        if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.CreditCard))
        {
            CreditCardPaymentProcessor.Finalize(order);
        }
    }
}
