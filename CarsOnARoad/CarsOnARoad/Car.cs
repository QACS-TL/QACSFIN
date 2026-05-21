using System.Security.Principal;

namespace CarsOnARoad
{
    public class Car:IComparable<Car>
    {
        public string Make { get;  }
        public string Model { get; set; }
        private int wheelCount = 4;
        public string Colour { get; set; }
        private int speed;

        public int Speed
        {
            get { return speed; }
            set { 
                speed = value > topSpeed ? topSpeed : value;
                speed = value < -10 ? -10 : value; 
            }
        }

        private int topSpeed;

        public int TopSpeed
        {
            get { return topSpeed; }
            set { 
                if (value < 0)
                {
                    throw new Exception("Blah!");
                }
                topSpeed = value; 
            }
        }


        public Car(string make="Generic Car", string model="Model X", string colour="Black", int topSpeed = 120, int speed = 50)
        {
            this.Make = make;
            this.Model = model;
            this.Colour = colour;
            this.TopSpeed = topSpeed;
            this.Speed = speed;
        }

        //public Car()//:this("Generic Car", "Model X", "Black")
        //{

        //}

        //Java Way
        //public int GetWheelCount()
        //{
        //    return wheelCount;
        //}

        //public void SetWheelCount(int value)
        //{
        //    if (value < 0)
        //    {
        //        value = 0;
        //    }
        //    wheelCount = value;
        //}

        public int WheelCount
        {
            get { return wheelCount;  }
            set { wheelCount = value < 0 ? 0 : value; }
        }

        public virtual void Accelerate(int amount)
        {
            speed += amount;
        }

        public void Brake(int amount)
        {
            speed -= amount;
        }

        public string Honk()
        {
            return "Beep beep!";
        }

        public override string ToString()
        {
            return $"{Colour} {Make} {Model} | {this.GetType().Name} | Top Speed: {TopSpeed} | Current Speed: {Speed}";
        }

        public int CompareTo(Car? other)
        {
            return (int)(this.TopSpeed - other.TopSpeed);
        }

        private static IComparer<Car> carSpeedComparer = null;

        public static IComparer<Car> CarSpeedComparer
        {
            get
            {
                if (carSpeedComparer == null)
                {
                    carSpeedComparer = new SpeedComparer();
                }
                return carSpeedComparer;
            }
        }

        private class SpeedComparer : IComparer<Car>
        {
            public int Compare(Car? x, Car? y)
            {
                return x.Speed.CompareTo(y.Speed);
            }
        }

        private static IComparer<Car> carColourComparer = null;

        public static IComparer<Car> CarColourComparer
        {
            get
            {
                if (carColourComparer == null)
                {
                    carColourComparer = new ColourComparer();
                }
                return carColourComparer;
            }
        }

        private class ColourComparer : IComparer<Car>
        {
            public int Compare(Car? x, Car? y)
            {
                return x.Colour.CompareTo(y.Colour);
            }
        }


        private static IComparer<Car> carModelComparer = null;

        public static IComparer<Car> CarModelComparer
        {
            get
            {
                if (carModelComparer == null)
                {
                    carModelComparer = new ModelComparer();
                }
                return carModelComparer;
            }
        }

        private class ModelComparer : IComparer<Car>
        {
            public int Compare(Car? x, Car? y)
            {
                return x.Model.CompareTo(y.Model);
            }
        }

        private static IComparer<Car> carMakeComparer = null;

        public static IComparer<Car> CarMakeComparer
        {
            get
            {
                if (carMakeComparer == null)
                {
                    carMakeComparer = new MakeComparer();
                }
                return carMakeComparer;
            }
        }

        private class MakeComparer : IComparer<Car>
        {
            public int Compare(Car? x, Car? y)
            {
                return x.Make.CompareTo(y.Make);
            }
        }
    }
}
