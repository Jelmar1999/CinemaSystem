using Newtonsoft.Json;

namespace CinemaSystem.Domain
{
    public class Order
    {
        [JsonProperty] private int orderNr { get; set; }
        [JsonProperty] private bool isStudentOrder { get; set; }
        [JsonProperty] private ICollection<MovieTicket> tickets { get; set; }

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

            double price = 0;
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
                if (IsSecondTicketFree(movieTicket))
                {
                    freeSecondTicket = true;
                }
            }

            price *= (double)(100 - GetSaleAmount()) / 100;

            return price;
        }

        private int GetSaleAmount()
        {
            var sale = 0;

            if (tickets.Count >= 6 && tickets.First().movieScreening.inWeekend())
            {
                sale += 10;
            }

            return sale;
        }

        private bool IsSecondTicketFree(MovieTicket ticket)
        {
            return isStudentOrder || ticket.movieScreening.inWeekend();
        }

        public override string ToString()
        {
            return $"orderNr = {this.orderNr}, isStudentOrder = {this.isStudentOrder}, movieTickets = {this.tickets}";
        }

        public void Export(TicketExportFormat exportFormat)
        {
            if (exportFormat == TicketExportFormat.JSON)
            {
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(this, Formatting.Indented);
                Console.WriteLine(output);
            }
            else if (exportFormat == TicketExportFormat.PLAINTEXT)
            {
                string output = this.ToString();
                Console.WriteLine(output);
            }
        }
    }
}