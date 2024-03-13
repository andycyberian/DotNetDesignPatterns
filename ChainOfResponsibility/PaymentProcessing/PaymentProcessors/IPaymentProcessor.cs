using ChainOfResponsibility.PaymentProcessing.Models;

namespace ChainOfResponsibility.PaymentProcessing.PaymentProcessors;

public interface IPaymentProcessor
{
    void Finalize(Order order);
}
