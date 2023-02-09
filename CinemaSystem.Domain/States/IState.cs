namespace CinemaSystem.Domain.States;

public interface IState
{
    void Create();
    void Pay();
    void Change();
    void Cancel();
}