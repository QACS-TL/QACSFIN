using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsOnARoad
{
    public enum TopType
    {
        Soft,
        Hard,
        Retractable
    }


    public class Convertible : Car
    {
        private int topSpeedWhenRoofIsDown = 60;
        public Convertible(string make = "BMW", string model = "Cabriolet", string colour = "Yellow", int topSpeed = 110, int speed = 50, TopType top = TopType.Soft) : base(make, model, colour, topSpeed, speed)
        {
            this.Top = top;
            this.IsTopUp = true;
        }

        public TopType Top { get; set; }
        public bool IsTopUp { get; set; }

        public string RetractTop()
        {
            this.IsTopUp = false;
            if (Top == TopType.Soft)
            {
                return "Soft top retracted.";
            }
            else if (Top == TopType.Hard)
            {
                return "Hard top retracted.";
            }
            else if (Top == TopType.Retractable)
            {
                return "Retractable top retracted.";
            }
            else
            {
                return "Unknown top type.";
            }
            
        }

        public string ExtendTop()
        {
            return $"Top is back in place";
            this.IsTopUp = true;
        }

        public override void Accelerate(int amount)
        {
            if (this.IsTopUp)
                Speed += amount;
            else
            {
                if (Speed + amount > topSpeedWhenRoofIsDown)
                    return;
                Speed += amount;
            }
        }

    }
}
