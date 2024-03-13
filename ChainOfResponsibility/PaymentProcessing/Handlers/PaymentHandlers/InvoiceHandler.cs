using ChainOfResponsibility.PaymentProcessing.Models;
using ChainOfResponsibility.PaymentProcessing.PaymentProcessors;

namespace ChainOfResponsibility.PaymentProcessing.Handlers.PaymentHandlers;

public class InvoiceHandler : IReceiver<Order>
{
    public InvoicePaymentProcessor InvoicePaymentProcessor { get; }
        = new InvoicePaymentProcessor();

    public void Handle(Order order)
    {
        if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice))
        {
            InvoicePaymentProcessor.Finalize(order);
        }
    }
}
