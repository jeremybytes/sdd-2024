using Moq;

namespace HouseControl.Library.Test;

[TestFixture]
public class ScheduleHelperTests
{
    [TearDown]
    public void Teardown()
    {

    }

    [Test]
    public void MondayItemInFuture_OnRollDay_IsUnchanged()
    {
        // Arrange

        // Act

        // Assert
        Assert.Inconclusive();
    }

    [Test]
    public void MondayItemInFuture_OnRollWeekdayDay_IsUnchanged()
    {
        // Arrange

        // Act

        // Assert
        Assert.Inconclusive();
    }

    [Test]
    public void SaturdayItemInFuture_OnRollDay_IsUnchanged()
    {
        // Arrange

        // Act

        // Assert
        Assert.Inconclusive();
    }

    [Test]
    public void SaturdayItemInFuture_OnRollWeekendDay_IsUnchanged()
    {
        // Arrange

        // Act

        // Assert
        Assert.Inconclusive();
    }

    [Test]
    public void MondayItemInPast_OnRollDay_IsTomorrow()
    {
        // Arrange

        // Act

        // Assert
        Assert.Inconclusive();
    }
}
