using MotorPool.Services.Drivers.Models;

namespace MotorPool.Services.Driver.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Driver()
    {
        DriverDTO dto = new DriverDTO
                        {
                            FirstName = null, LastName = null
                        };
        Assert.Pass();
    }
}