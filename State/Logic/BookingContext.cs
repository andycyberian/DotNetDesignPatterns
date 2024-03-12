namespace State.Logic;

public class BookingContext
{
    public string Attendee { get; set; }
    public int TicketCount { get; set; }
    public int BookingID { get; set; }

    public string Message { get; set; }
    public string Error { get; set; }

    private BookingState currentState;

    public void TransitionToState(BookingState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public BookingContext()
    {
        TransitionToState(new NewState());
    }

    public void SubmitDetails(string attendee, int ticketCount)
    {
        currentState.EnterDetails(this, attendee, ticketCount);
    }

    public void Cancel()
    {
        currentState.Cancel(this);
    }

    public void DatePassed()
    {
        currentState.DatePassed(this);
    }

    public void ShowState(string stateName)
    {
        Console.WriteLine($"{stateName}\r\nTicket count: {TicketCount}\r\nAttendee: {Attendee}\r\nBooking id: {BookingID}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
