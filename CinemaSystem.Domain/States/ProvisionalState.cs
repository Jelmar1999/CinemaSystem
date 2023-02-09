namespace CinemaSystem.Domain.States;

public class ProvisionalState : IState
{
    private Order order;

    public ProvisionalState(Order o)
    {
        order = o;
    }

    public void Create()
    {
        //Do Nothing
    }

    public void Pay()
    {
        //If Ticket has not been paid for 12 hours until show start, cancel order
        order.ChangeState(new CompleteState(order));
    }

    public void Change()
    {
        //Do Nothing
    }

    public void Cancel()
    {
        //Cancel order and remove reservation of seats
    }
}