using CarsOnARoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsOnARoad
{
    public class Road
    {
        // Dictionary storing cars
        public Dictionary<string, Car> cars = new Dictionary<string, Car>
        {
            { "AB12CDE", new Car("Ford", "Focus", "Blue", 180, 70) },
            { "XY34ZRT", new Car("BMW", "320i", "Green", 200, 90 ) },
            { "LM56OPQ", new Car("Toyota", "Corolla", "Silver", 160, 60) },
            { "GH78JKL", new Car("Audi", "A4", "Black", 220, 100 ) }
        };

        // Road order
        public List<string> carsOnRoad = new List<string>
        {
            "AB12CDE", "XY34ZRT", "LM56OPQ", "GH78JKL"
        };

        public string AttemptOvertake(string plate, int index, string frontPlate, Car car, Car frontCar)
        {
            if (car.TopSpeed > frontCar.Speed)
            {
                // Swap
                carsOnRoad[index - 1] = plate;
                carsOnRoad[index] = frontPlate;

                return $"{plate} overtook {frontPlate}";
            }
            else
            {
                return "Overtake failed (insufficient speed)";
            }
        }

    }
}
