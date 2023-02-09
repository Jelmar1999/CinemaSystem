namespace CinemaSystem.Domain.States;

public class PayState : IState
{
    private Order order;
    public PayState(Order o)
    {
        order = o;
    }

    public void Create()
    {
        //Do Noting
    }

    public void Pay()
    {
        //Pay for ticket
        //If order has not been paid 24 hours until show starts, Change state to ProvisionalState
        order.ChangeState(new CompleteState(order));
        order.ChangeState(new ProvisionalState(order));
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