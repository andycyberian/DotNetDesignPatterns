﻿namespace State.Logic;

public class BookedState : BookingState
{
    public override void EnterState(BookingContext booking)
    {
        booking.ShowState("Booked");
        booking.ShowMessage("Enjoy the Event");
    }

    public override void Cancel(BookingContext booking)
    {
        booking.TransitionToState(new ClosedState("Booking canceled: Expect a refund"));
    }

    public override void DatePassed(BookingContext booking)
    {
        booking.TransitionToState(new ClosedState("We hope you enjoyed the event!"));
    }

    public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
    {

    }

}
