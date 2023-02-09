using CinemaSystem.Domain.Strategy;

using CinemaSystem.Domain.Interfaces;

namespace CinemaSystem.Domain;

using Newtonsoft.Json;

public class Order
{
    [JsonProperty] private int orderNr { get; set; }
    [JsonProperty] private bool isStudentOrder { get; set; }
    [JsonProperty] private ICollection<MovieTicket> tickets;
    private IPriceCalculationBehaviour priceCalculationBehaviour;
    private IExportBehaviour exportBehaviour;

    public Order(int orderNr, bool isStudentOrder)
    {
        this.orderNr = orderNr;
        this.isStudentOrder = isStudentOrder;
        this.tickets = new List<MovieTicket>();
        if (isStudentOrder)
        {
            setPriceCalculationBehaviour(new StudentPriceCalculation());
        }
        else
        {
            setPriceCalculationBehaviour(new RegularPriceCalculation());
        }
    }
    
    public int GetOrderNr()
    {
        return orderNr;
    }

    public void setPriceCalculationBehaviour(IPriceCalculationBehaviour priceCalculationBehaviour)
    {
        this.priceCalculationBehaviour = priceCalculationBehaviour;
    }

    public void setExportBehaviour(IExportBehaviour exportBehaviour)
    {
        this.exportBehaviour = exportBehaviour;
    }
    
    public void AddSeatReservation(MovieTicket ticket)
    {
        this.tickets.Add(ticket);
    }

    public double CalculatePrice()
    {
        if (tickets.Count == 0 || priceCalculationBehaviour == null)
        {
            return -1;
        }

        var result = priceCalculationBehaviour.CalculatePrice(tickets);

        return Math.Round(result, 2);
    }

    public override string ToString()
    {
        var ticketString = tickets.Aggregate("\n", (current, ticket) => current + (ticket.ToString() + '\n'));

        return $"orderNr = {orderNr}, isStudentOrder = {isStudentOrder}, movieTickets : {ticketString}";
    }
    
    public void Export()
    {
        var result = exportBehaviour.Export(this);
        Console.WriteLine(result);
    }
}