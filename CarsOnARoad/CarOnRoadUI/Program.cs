using CarsOnARoad;
namespace CarsOnRoad
{
    class Program
    {
        static Road road = new Road();
        static void DisplayRoad()
        {
            Console.WriteLine("\n--- Current Road ---");

            for (int i = 0; i < road.carsOnRoad.Count; i++)
            {
                string plate = road.carsOnRoad[i];
                Console.WriteLine($"Position {i + 1}: {plate} ({road.cars[plate]})");
            }
        }

        static void AttemptOvertake()
        {
            DisplayRoad();

            Console.Write("\nEnter car registration: ");
            string plate = Console.ReadLine().Trim();

            if (!road.carsOnRoad.Contains(plate))
            {
                Console.WriteLine("Car not found.");
                return;
            }

            int index = road.carsOnRoad.IndexOf(plate);

            if (index == 0)
            {
                Console.WriteLine("Car is already at the front.");
                return;
            }

            string frontPlate = road.carsOnRoad[index - 1];
            Car car = road.cars[plate];
            Car frontCar = road.cars[frontPlate];

            Console.WriteLine("\nAttempting overtake...");

            Console.WriteLine(road.AttemptOvertake(plate, index, frontPlate, car, frontCar));

            DisplayRoad();
        }

        static void AddCar()
        {
            Console.WriteLine("\n--- Add New Car ---");

            Console.Write("Enter registration plate: ");
            string plate = Console.ReadLine().Trim();

            if (road.cars.ContainsKey(plate))
            {
                Console.WriteLine("This registration already exists.");
                return;
            }

            Console.Write("Enter make: ");
            string make = Console.ReadLine();

            Console.Write("Enter model: ");
            string model = Console.ReadLine();

            Console.Write("Enter colour: ");
            string colour = Console.ReadLine();

            try
            {
                Console.Write("Enter top speed: ");
                int topSpeed = int.Parse(Console.ReadLine());

                Console.Write("Enter current speed: ");
                int currentSpeed = int.Parse(Console.ReadLine());

                if (currentSpeed > topSpeed)
                {
                    Console.WriteLine("Current speed cannot be greater than top speed.");
                    return;
                }

                Car newCar = new Car(make, model, colour, topSpeed, currentSpeed);

                

                road.cars[plate] = newCar;
                road.carsOnRoad.Add(plate);

                Console.WriteLine($"Car {plate} added successfully at the end of the queue.");
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter numeric values for speeds.");
            }
        }


        static void Menu()
        {
            Car newCar = new Car("Toyota", "Corolla", "Red", 180, 60);
            Console.WriteLine(newCar.ToString());
            Car another = new Car("Toyota", "Corolla", "Red", 180, 60);
            if (newCar.Equals(another))
            {
                Console.WriteLine("They are the same car");
            }

            Convertible cc = new Convertible(colour:"Gold", model: "TT", speed: 50, top: TopType.Soft);
            Console.WriteLine($"Convertible: {cc.Model}, Colour: {cc.Colour}");
            Console.WriteLine(cc.RetractTop());

            Car ccc = new Convertible(colour: "Gold", model: "TT", speed: 50, top: TopType.Soft);
            ((Convertible)ccc).RetractTop();
            ccc.Accelerate(15);
            Console.WriteLine(ccc.Speed);

            while (true)
            {
                Console.WriteLine("\n==== Car Road Simulation ====");
                Console.WriteLine("1. View road");
                Console.WriteLine("2. Attempt overtake");
                Console.WriteLine("3. Add new car");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                    DisplayRoad();
                else if (choice == "2")
                    AttemptOvertake();
                    //Console.WriteLine("Under Construction");
                else if (choice == "3")
                    AddCar();
                    //Console.WriteLine("Under Construction");
                else if (choice == "4")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                    Console.WriteLine("Invalid choice.");
            }
        }

        public static void Main()
        {
            Menu();
        }
        
    }
}
