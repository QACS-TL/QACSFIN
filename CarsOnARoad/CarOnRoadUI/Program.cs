using CarsOnARoad;
using System.Xml.Schema;

Car myCar = new Car( model:"Corsa" );
Car myOtherCar = new Car() { Make = "VW", Model = "Beetle", Colour = "Silver" };


//myCar.make = "Ford";
//myCar.model = "Fiesta";
//myCar.colour = "Red";
myCar.WheelCount = -1;
//myCar.topSpeed = 110;
//myCar.speed = 0;
myCar.Accelerate(30);

//myOtherCar.colour = "Blue";
myOtherCar.Accelerate(50);

Console.WriteLine($"I'm a {myCar.Colour} {myCar.Make} {myCar.Model}, I have {myCar.WheelCount} wheels and I'm travelling at {myCar.speed} mph");
Console.WriteLine($"I'm a {myOtherCar.Colour} {myOtherCar.Make} {myOtherCar.Model}, I have {myOtherCar.WheelCount} wheels and I'm travelling at {myOtherCar.speed} mph");