namespace CarsOnARoad
{
    public class Car
    {
        public string make = "Generic Car";
        public string model = "Model X";
        public int wheelCount = 4;
        public string colour = "Black";
        public int speed = 0;
        public int topSpeed = 120;

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
