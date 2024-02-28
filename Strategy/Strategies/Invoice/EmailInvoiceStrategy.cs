﻿using Strategy.Models;
using System.Net;
using System.Net.Mail;

namespace Strategy.Strategies.Invoice;

public class EmailInvoiceStrategy : InvoiceStrategy
{
    public override void Generate(Order order)
    {
        using (SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587))
        {
            NetworkCredential credentials = new NetworkCredential("USERNAME", "PASSWORD");
            client.Credentials = credentials;

            MailMessage mail = new MailMessage("YOUR EMAIL", "YOUR EMAIL")
            {
                Subject = "We've created an invoice for your order",
                Body = GenerateTextInvoice(order)
            };

            client.Send(mail);

            Console.WriteLine("Invoice for order sent over e-mail");
        }
    }
}
