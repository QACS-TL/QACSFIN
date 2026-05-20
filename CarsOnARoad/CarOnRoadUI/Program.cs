using CarsOnARoad;
using System.Xml.Schema;

Car myCar = new Car();
Car myOtherCar = new Car();


myCar.make = "Ford";
myCar.model = "Fiesta";
myCar.colour = "Red";
myCar.wheelCount = 4;
myCar.topSpeed = 110;
myCar.speed = 0;
myCar.Accelerate(30);

myOtherCar.colour = "Blue";
myOtherCar.Accelerate(50);

Console.WriteLine($"I'm a {myCar.colour} {myCar.make} {myCar.model} and I'm travelling at {myCar.speed} mph");
Console.WriteLine($"I'm a {myOtherCar.colour} {myOtherCar.make} {myOtherCar.model} and I'm travelling at {myOtherCar.speed} mph");