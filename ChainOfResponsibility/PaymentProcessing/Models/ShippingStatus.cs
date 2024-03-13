namespace ChainOfResponsibility.PaymentProcessing.Models;

public enum ShippingStatus
{
    WaitingForPayment,
    ReadyForShippment,
    Shipped
}
