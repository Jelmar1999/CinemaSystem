namespace CinemaSystem.Domain.States;

public class CreateState : IState
{
    private Order order;
    public CreateState(Order o)
    {
        order = o;
    }

    public void Create()
    {
        //Create Order
        //Contains amount of tickets
        //Contains optionally a parking-ticket
        order.ChangeState(new PayState(order));
    }

    public void Pay()
    {
       //Do Nothing
    }

    public void Change()
    {
        //You can still change the order at this stage
        order.ChangeState(new PayState(order));
    }

    public void Cancel()
    {
        //Cancel order and remove reservation of seats
    }
}