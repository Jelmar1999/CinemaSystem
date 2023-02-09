namespace CinemaSystem.Domain.States;

public class CompleteState : IState
{
    private Order order;

    public CompleteState(Order o)
    {
        order = o;
    }

    public void Create()
    {
        //Do Nothing
    }

    public void Pay()
    {
        //Do Nothing
    }

    public void Change()
    {
        //Do Nothing
    }

    public void Cancel()
    {
        //Do Nothing
    }
}