using CinemaSystem.Domain;

namespace CinemaSystem.Test;

[TestFixture]
public class OrderUnitTests
{
    private static IEnumerable<TestCaseData> CalculatePriceTestCaseData()
    {
        //Arrange
        var movie = new Movie("Johan en het DotnetFramework");

        var weekdayScreening = new MovieScreening(movie, new DateTime(2023, 2, 2), 10); // Thursday
        var regularWeekdayTicket = new MovieTicket(weekdayScreening, false, 1, 1);
        var premiumWeekdayTicket = new MovieTicket(weekdayScreening, true, 1, 2);
        var weekdayTickets = new[] { regularWeekdayTicket, premiumWeekdayTicket };

        var weekendScreening = new MovieScreening(movie, new DateTime(2023, 2, 4), 14); // Saturday
        var regularWeekendTicket = new MovieTicket(weekendScreening, false, 1, 1);
        var premiumWeekendTicket = new MovieTicket(weekendScreening, true, 1, 2);
        var weekendTickets = new[] { regularWeekendTicket, premiumWeekendTicket };

        var groupTicket1 = new MovieTicket(weekendScreening, false, 1, 1);
        var groupTicket2 = new MovieTicket(weekendScreening, true, 1, 2);
        var groupTicket3 = new MovieTicket(weekendScreening, true, 1, 3);
        var groupTicket4 = new MovieTicket(weekendScreening, false, 1, 4);
        var groupTicket5 = new MovieTicket(weekendScreening, false, 1, 5);
        var groupTicket6 = new MovieTicket(weekendScreening, false, 1, 6);
        var groupTicket7 = new MovieTicket(weekendScreening, false, 1, 7);
        var groupTickets = new[]
            { groupTicket1, groupTicket2, groupTicket3, groupTicket4, groupTicket5, groupTicket6, groupTicket7 };


        yield return new TestCaseData(weekdayTickets, false).Returns(10d).SetName("Weekday normal order");
        yield return new TestCaseData(weekdayTickets, true).Returns(10d).SetName("Weekend student order");
        yield return new TestCaseData(groupTickets, false).Returns(93.60d).SetName("Weekend normal group-order");
        yield return new TestCaseData(weekendTickets, false).Returns(31d).SetName("Weekend normal order");
    }

    [TestCaseSource(nameof(CalculatePriceTestCaseData))]
    public double CalculatePrice_Correct(ICollection<MovieTicket> tickets, bool student)
    {
        //Arrange
        var order = new Order(1, student);
        foreach (var movieTicket in tickets)
        {
            order.AddSeatReservation(movieTicket);
        }

        //Act
        var result = order.CalculatePrice();

        //Assert
        return result;
    }
}