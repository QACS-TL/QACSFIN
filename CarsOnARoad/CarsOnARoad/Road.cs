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
            { "XY34ZRT", new Convertible("BMW", "320i", "Green", 200, 90, TopType.Hard ) },
            { "LM56OPQ", new Car("Toyota", "Corolla", "Silver", 80, 60) },
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
                if (car is Convertible)
                {
                    Convertible cc = (Convertible)car;
                    cc.ExtendTop();
                }

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
