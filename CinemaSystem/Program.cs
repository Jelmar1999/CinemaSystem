// See https://aka.ms/new-console-template for more information

using CinemaSystem.Domain;

Console.WriteLine("Hello, World!");

var order = new Order(324, true);
order.Export(TicketExportFormat.PLAINTEXT);