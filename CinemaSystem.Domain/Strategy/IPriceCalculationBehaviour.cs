namespace CinemaSystem.Domain.Strategy;

public interface IPriceCalculationBehaviour
{
    double CalculatePrice(ICollection<MovieTicket> tickets);
}