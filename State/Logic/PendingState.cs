namespace State.Logic;

public class PendingState : BookingState
{
    CancellationTokenSource cancelToken;

    public override void EnterState(BookingContext booking)
    {
        cancelToken = new CancellationTokenSource();

        booking.ShowState("Pending");

        StaticFunctions.ProcessBooking(booking, ProcessingComplete, cancelToken);
    }

    public override void Cancel(BookingContext booking)
    {
        cancelToken.Cancel();
    }

    public override void DatePassed(BookingContext booking)
    {

    }

    public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
    {

    }


    public void ProcessingComplete(BookingContext booking, ProcessingResult result)
    {
        switch (result)
        {
            case ProcessingResult.Sucess:
                booking.TransitionToState(new BookedState());
                break;
            case ProcessingResult.Fail:
                booking.TransitionToState(new NewState());
                break;
            case ProcessingResult.Cancel:
                booking.TransitionToState(new ClosedState("Processing Canceled"));
                break;
        }
    }
}
