using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

// using System.Text.Json;

namespace CinemaSystem.Domain
{
    public class Order
    {
        [JsonProperty]
        private int orderNr { get; set; }
        [JsonProperty]
        private bool isStudentOrder { get; set; }
        [JsonProperty]
        private ICollection<MovieTicket> tickets { get; set; }

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