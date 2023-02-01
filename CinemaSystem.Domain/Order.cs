using System.Collections.Generic;

namespace CinemaSystem.Domain
{
    public class Order
    {
        private int orderNr;
        private bool isStudentOrder;
        private ICollection<MovieTicket> tickets;

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
            return 0;
        }

        public void Export(TicketExportFormat exportFormat)
        {
        }
    }
}