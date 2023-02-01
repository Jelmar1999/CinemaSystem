using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CinemaSystem.Domain
{
    public class Order
    {
        private int orderNr;
        private bool isStudentOrder;
        private ICollection<MovieTicket> tickets = null;

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
            if (exportFormat == TicketExportFormat.JSON)
            {
                // string json = Newtonsoft.Json.JsonConvert.SerializeObject(this);
                // Console.WriteLine("JSONIFIED: " + json);
                string json = JsonSerializer.Serialize<Order>(this);
                Console.WriteLine("JASOOOOOOON: " + json);
            }
            else if (exportFormat == TicketExportFormat.PLAINTEXT)
            {
                
            }
        }
    }
}