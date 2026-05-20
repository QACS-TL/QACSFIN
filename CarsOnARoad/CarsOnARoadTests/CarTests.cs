using CarsOnARoad;
namespace CarsOnARoadTests
{
    public class CarTests
    {
        [Fact]
        public void TestInitialConstruction()
        {
            // Arrange


            // Act

            Car c = new Car();

            // Assert
            Assert.NotNull(c);
            Assert.Equal(0, c.speed);
            Assert.Equal(4, c.wheelCount);
            Assert.Equal(120, c.topSpeed);
            Assert.Equal("Black", c.Colour);
            Assert.Equal("Generic Car", c.make);
            Assert.Equal("Model X", c.model);
        }
    }
}
