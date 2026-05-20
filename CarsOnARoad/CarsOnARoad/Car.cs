namespace CarsOnARoad
{
    public class Car
    {
        public string Make { get; set; } 
        public string Model { get; set; }
        private int wheelCount = 4;
        public string Colour;
        public int speed = 0;
        public int topSpeed = 120;

        public Car(string make="Generic Car", string model="Model X", string colour="Black")
        {
            this.Make = make;
            this.Model = model;
            this.Colour = colour;
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

        public void Accelerate(int amount)
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


    }
}
