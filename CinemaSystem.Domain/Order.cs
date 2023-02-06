using Newtonsoft.Json;

namespace CinemaSystem.Domain
{
    public class Order
    {
        [JsonProperty] private int orderNr { get; set; }
        [JsonProperty] private bool isStudentOrder { get; set; }
        [JsonProperty] private ICollection<MovieTicket> tickets;

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
            this.tickets = new List<MovieTicket>();
        }

        public int GetOrderNr()
        {
            return orderNr;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            this.tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            if (tickets.Count == 0)
            {
                return -1;
            }

            var price = 0d;
            var weekendOrder = tickets.First().movieScreening.inWeekend();
            var isSecondTicketFree = isStudentOrder || !weekendOrder;
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
                    price += isStudentOrder ? 2 : 3;
                }
                
                // Check if next ticket is free
                if (isSecondTicketFree)
                {
                    freeSecondTicket = true;
                }
            }
            
            if (tickets.Count >= 6 && weekendOrder && !isStudentOrder)
            {
                price *= 0.9;
            }
            
            return Math.Round(price,2);
        }

        public override string ToString()
        {
            string ticketString = "\n";
            foreach (var ticket in tickets)
            {
                ticketString += ticket.ToString()+ '\n';
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
}