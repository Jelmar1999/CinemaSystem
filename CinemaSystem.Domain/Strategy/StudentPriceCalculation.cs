namespace CinemaSystem.Domain.Strategy;

public class StudentPriceCalculation : IPriceCalculationBehaviour
{
    public double CalculatePrice(ICollection<MovieTicket> tickets)
    {
        var price = 0d;
        var freeSecondTicket = false;

        foreach (var movieTicket in tickets)
        {
            // Check if ticket is free, if true skip to next ticket
            if (freeSecondTicket)
            {
                freeSecondTicket = false;
                continue;
            }

            price += movieTicket.GetPrice();
            if (movieTicket.IsPremiumTicket())
            {
                price += 2;
            }
            
            freeSecondTicket = true;
        }

        return price;
    }
}