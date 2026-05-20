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
            Assert.Equal(0, c.Speed);
            Assert.Equal(4, c.WheelCount);
            Assert.Equal(120, c.TopSpeed);
            Assert.Equal("Black", c.Colour);
            Assert.Equal("Generic Car", c.Make);
            Assert.Equal("Model X", c.Model);
        }
    }
}
