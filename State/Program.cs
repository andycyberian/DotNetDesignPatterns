// See https://aka.ms/new-console-template for more information
using State.Logic;

Console.WriteLine("Hello, World!");


var booking = new BookingContext();

Console.WriteLine("Attendee name?");
var attendee = Console.ReadLine();

Console.WriteLine("Ticket count?");
var tickets = Int32.Parse(Console.ReadLine());

booking.SubmitDetails(attendee, tickets);

Console.WriteLine("Done");
Console.ReadLine();