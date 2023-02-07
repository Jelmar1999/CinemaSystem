namespace CinemaSystem.Test;

using Domain;

[TestFixture]
public class OrderUnitTests
{
    private static IEnumerable<TestCaseData> CalculatePriceTestCaseData()
    {
        //Arrange
        var movie = new Movie("Johan en het DotnetFramework");

        var weekdayScreening = new MovieScreening(movie, new DateTime(2023, 2, 2), 10); // Thursday
        var weekendScreening = new MovieScreening(movie, new DateTime(2023, 2, 4), 14); // Saturday

        var ticket1 = new MovieTicket(weekdayScreening, false, 1, 1);
        var ticket2 = new MovieTicket(weekdayScreening, false, 1, 2);
        var ticket3 = new MovieTicket(weekdayScreening, false, 1, 3);

        var premiumTicket1 = new MovieTicket(weekdayScreening, true, 2, 1);
        var premiumTicket2 = new MovieTicket(weekdayScreening, true, 2, 2);

        var weekendTicket1 = new MovieTicket(weekendScreening, false, 1, 1);
        var weekendTicket2 = new MovieTicket(weekendScreening, false, 1, 2);
        var weekendTicket3 = new MovieTicket(weekendScreening, false, 1, 3);
        var weekendTicket4 = new MovieTicket(weekendScreening, false, 1, 4);
        var weekendTicket5 = new MovieTicket(weekendScreening, false, 1, 5);

        var premiumWeekendTicket1 = new MovieTicket(weekendScreening, true, 2, 1);
        var premiumWeekendTicket2 = new MovieTicket(weekendScreening, true, 2, 2);

        var noTickets = Array.Empty<MovieTicket>();
        var singleTicket = new[] { ticket1 };
        var weekdayTickets = new[] { ticket1, ticket2, ticket3 };
        var weekendTickets = new[] { weekendTicket1, weekendTicket2 };
        var premiumTickets = new[] { premiumTicket1, premiumTicket2 };
        var premiumWeekendTickets = new[] { premiumWeekendTicket1, premiumWeekendTicket2 };
        var groupTickets = new[]
        {
            weekendTicket1, weekendTicket2, weekendTicket3, weekendTicket4, weekendTicket5,
            premiumWeekendTicket1, premiumWeekendTicket2
        };

        yield return new TestCaseData(noTickets, false).Returns(-1d).SetName("1. No tickets");
        yield return new TestCaseData(singleTicket, false).Returns(10d).SetName("2. Single ticket");
        yield return new TestCaseData(weekdayTickets, false).Returns(20d).SetName("3. Weekday");
        yield return new TestCaseData(weekendTickets, false).Returns(28d).SetName("4. Weekend");
        yield return new TestCaseData(weekdayTickets, true).Returns(20d).SetName("5. Weekday student");
        yield return new TestCaseData(weekendTickets, true).Returns(14d).SetName("6. Weekend student");
        yield return new TestCaseData(premiumTickets, false).Returns(13d).SetName("7. Premium weekday");
        yield return new TestCaseData(premiumWeekendTickets, false).Returns(34d).SetName("8. Premium weekend");
        yield return new TestCaseData(groupTickets, false).Returns(93.60d).SetName("9. Weekend large group");
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