using CinemaSystem.Domain;

namespace CinemaSystem.Test;

[TestFixture]
public class OrderUnitTests
{
    private Order order;
    private Movie movie;
    private MovieScreening screening;
    private MovieTicket ticket;
    [SetUp] 
    public void Setup()
    {
        movie = new Movie("Johan en het DotnetFramework");
        screening = new MovieScreening(movie, DateTime.Today, 12);
        ticket = new MovieTicket(screening, true, 12, 23);
        order = new Order(324, true);
        order.AddSeatReservation(ticket);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}