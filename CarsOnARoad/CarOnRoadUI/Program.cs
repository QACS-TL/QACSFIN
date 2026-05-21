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
            string plate;
            int index;
            bool isValidCar = SelectCar(out plate, out index);
            if (!isValidCar)
            {
                return;
            }

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

        private static bool SelectCar(out string plate, out int index)
        {
            DisplayRoad();

            Console.Write("\nEnter car registration: ");
            plate = Console.ReadLine().Trim();
            if (!road.carsOnRoad.Contains(plate))
            {
                Console.WriteLine("Car not found.");
                index = -1;
                return false;
            }

            index = road.carsOnRoad.IndexOf(plate);
            return true;
        }

        static void AccelerateAllCars()
        {
            Console.WriteLine("\n--- Accelerating All Cars ---");
            foreach (string plate in road.carsOnRoad)
            {
                Car car = road.cars[plate];
                car.Accelerate(10);
                Console.WriteLine($"{plate} accelerated to {car.Speed} km/h.");
            }
        }

        static void ToggleTop()
        {
            string plate;
            int index;
            bool isValidCar = SelectCar(out plate, out index);
            if (!isValidCar)
            {
                return;
            }
            Console.WriteLine("\n--- Retract/Extend Convertible Top ---");
            Car car = road.cars[plate];
            Convertible cc = car as Convertible;
            if (cc != null && cc.IsTopUp )
            {
                Console.WriteLine($"{plate} ({cc.Model}): {cc.RetractTop()}");
            }
            else if (cc != null)
            {
                Console.WriteLine($"{plate} ({cc.Model}): {cc.ExtendTop()}");
            }
            else
            {
                Console.WriteLine($"{plate} is not a convertible.");
            }
        }

        enum SortCriterion
        {
            ByMake = 1,
            ByModel = 2,
            BySpeed = 3,
            ByColour = 4,
            ByTopSpeed = 5
        }

        static void SortCars()
        {
            Console.WriteLine("How would you like to sort the cars?");
            Console.WriteLine("1. By Make");
            Console.WriteLine("2. By Model");
            Console.WriteLine("3. By Speed");
            Console.WriteLine("4. By Colour");
            Console.WriteLine("5. By Top Speed");
            int sortCriterion = (int)Enum.Parse(typeof(SortCriterion), Console.ReadLine().Trim());

            switch (sortCriterion)
            {
                case (int)SortCriterion.ByMake:
                    road.carsOnRoad.Sort((a, b) => Car.CarMakeComparer.Compare(road.cars[a], road.cars[b]));
                    break;
                case (int)SortCriterion.ByModel:
                    road.carsOnRoad.Sort((a, b) => Car.CarModelComparer.Compare(road.cars[a], road.cars[b]));
                    break;
                case (int)SortCriterion.BySpeed:
                    road.carsOnRoad.Sort((a, b) => Car.CarSpeedComparer.Compare(road.cars[a], road.cars[b]));
                    break;
                case (int)SortCriterion.ByColour:
                    road.carsOnRoad.Sort((a, b) => Car.CarColourComparer.Compare(road.cars[a], road.cars[b]));
                    break;
                case (int)SortCriterion.ByTopSpeed:
                    road.carsOnRoad.Sort((a, b) => road.cars[a].CompareTo(road.cars[b]));
                    break;
                default:
                    Console.WriteLine("Invalid sort criterion. Sorting by make.");
                    road.carsOnRoad.Sort((a, b) => Car.CarMakeComparer.Compare(road.cars[a], road.cars[b]));
                    break;
            }
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

            Console.WriteLine("Is the car a convertible? (yes/no)");
            string isConvertible = Console.ReadLine().Trim().ToLower();

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

                Car newCar = null;
                if (isConvertible == "yes")
                {
                    Console.WriteLine("Enter top type (Soft/Hard/Retractable): ");
                    string topTypeInput = Console.ReadLine().Trim();
                    TopType topType;
                    if (!Enum.TryParse(topTypeInput, true, out topType))
                    {
                        Console.WriteLine("Invalid top type. Defaulting to Soft.");
                        topType = TopType.Soft;
                    }
                    newCar = new Convertible(make, model, colour, topSpeed, currentSpeed, topType);
                }
                else
                    newCar = new Car(make, model, colour, topSpeed, currentSpeed);

                

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
                Console.WriteLine("4. Accelerate all cars");
                Console.WriteLine("5. Toggle top");
                Console.WriteLine("6. Sort cars");
                Console.WriteLine("7. Exit");

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
                    AccelerateAllCars();
                else if (choice == "5")
                    ToggleTop();
                else if (choice == "6")
                    SortCars();
                //Console.WriteLine("Under Construction");
                else if (choice == "7")
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
