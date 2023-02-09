// See https://aka.ms/new-console-template for more information

using CinemaSystem.Domain;
using CinemaSystem.Domain.Strategy;

Console.WriteLine("Hello, World!");
var movie = new Movie("Johan en het DotnetFramework");
var screening = new MovieScreening(movie, DateTime.Today, 12);
var ticket = new MovieTicket(screening, true, 12, 23);
var order = new Order(324, true);
order.AddSeatReservation(ticket);
Console.WriteLine("Price = " + order.CalculatePrice());
order.setExportBehaviour(new PlaintextExport());
order.Export();
order.setExportBehaviour(new JSONExport());
order.Export();

