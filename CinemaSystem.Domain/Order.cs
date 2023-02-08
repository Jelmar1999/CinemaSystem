using CinemaSystem.Domain.Strategy;

namespace CinemaSystem.Domain;

using Newtonsoft.Json;

public class Order
{
    [JsonProperty] private int orderNr { get; set; }
    [JsonProperty] private bool isStudentOrder { get; set; }
    [JsonProperty] private ICollection<MovieTicket> tickets;
    private IPriceCalculationBehaviour? priceCalculationBehaviour;

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
        string ticketString = "\n";
        foreach (var ticket in tickets)
        {
            ticketString += ticket.ToString() + '\n';
        }

        return $"orderNr = {this.orderNr}, isStudentOrder = {this.isStudentOrder}, movieTickets : {ticketString}";
    }

    public void Export(TicketExportFormat exportFormat)
    {
        switch (exportFormat)
        {
            case TicketExportFormat.JSON:
            {
                var output = JsonConvert.SerializeObject(this, Formatting.Indented);
                Console.WriteLine(output);
                break;
            }
            case TicketExportFormat.PLAINTEXT:
            {
                var output = ToString();
                Console.WriteLine(output);
                break;
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(exportFormat), exportFormat, null);
        }
    }
}