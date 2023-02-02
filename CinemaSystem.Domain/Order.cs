using Newtonsoft.Json;

namespace CinemaSystem.Domain
{
    public class Order
    {
        [JsonProperty] private int orderNr { get; set; }
        [JsonProperty] private bool isStudentOrder { get; set; }
        [JsonProperty] private ICollection<MovieTicket> tickets = new List<MovieTicket>();

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
        }

        public int GetOrderNr()
        {
            return 0;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            this.tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            if (tickets == null || tickets.Count == 0)
            {
                return 0;
            }

            var price = 0d;
            var weekendOrder = tickets.First().movieScreening.inWeekend();
            var isSecondTicketFree = isStudentOrder || weekendOrder;
            var freeSecondTicket = false;

            foreach (var movieTicket in tickets)
            {
                // Check if ticket is free, if true skip to next ticket
                if (freeSecondTicket) continue;
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
            
            if (tickets.Count >= 6 && weekendOrder)
            {
                price *= 0.9;
            }
            
            return price;
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