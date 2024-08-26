using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarSystem.ModelCar;

namespace MyCarSystem.ModelCar
{
    public class PassengerCar : Auto
    {
        public int NumberOfSeats { get; set; }
        public bool HasAirConditionin { get; set; }

        public PassengerCar(string make, string model, int year, string color, int maxSpeed, int numberOfSeats, bool hasAirConditionin)
            : base(make, model, year, color, maxSpeed)
        {
            NumberOfSeats = numberOfSeats;
            HasAirConditionin = hasAirConditionin;
        }

        public void OpenTrunk()
        {
            Console.WriteLine($"Багажник {Make} {Model} відкрито.");
        }

        public void CloseTrunk()
        {
            Console.WriteLine($"Багажник {Make} {Model} закрито.");
        }
    }
}
