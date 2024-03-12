namespace State.Logic;

public class ClosedState : BookingState
{
    private string reasonClosed;

    public ClosedState(string reason)
    {
        reasonClosed = reason;
    }
    public override void EnterState(BookingContext booking)
    {
        booking.ShowState("Closed");
        booking.ShowMessage(reasonClosed);
    }

    public override void Cancel(BookingContext booking)
    {
        booking.ShowMessage("Invalid action for this state");
    }

    public override void DatePassed(BookingContext booking)
    {
        booking.ShowMessage("Invalid action for this state");
    }

    public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
    {
        booking.ShowMessage("Invalid action for this state");
    }

}
