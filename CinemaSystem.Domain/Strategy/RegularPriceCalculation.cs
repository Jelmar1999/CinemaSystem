namespace CinemaSystem.Domain.Strategy;

public class RegularPriceCalculation : IPriceCalculationBehaviour
{
    public double CalculatePrice(ICollection<MovieTicket> tickets)
    {
        var price = 0d;
        var weekendOrder = tickets.First().movieScreening.inWeekend();
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
                price += 3;
            }

            // Check if next ticket is free
            freeSecondTicket = !weekendOrder;
        }

        if (tickets.Count >= 6 && weekendOrder)
        {
            price *= 0.9;
        }

        return price;
    }
}