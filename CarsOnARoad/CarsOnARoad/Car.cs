namespace CarsOnARoad
{
    public class Car
    {
        public string Make { get; } 
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
                    value = 0;
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
        
        public override string ToString()
        {
            return $"{Colour} {Make} {Model} | Top Speed: {TopSpeed} | Current Speed: {Speed}";
        }


    }
}
