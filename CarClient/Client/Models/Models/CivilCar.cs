using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutoProject.Client.Models
{
    public class CivilCar : PassengerCar
    {
        public string LicensePlate { get; private set; }
        public bool IsElectric { get; private set; }

        public CivilCar(string make, string model, int year, string color, int maxSpeed, int numberOfSeats, bool hasAirConditionin, string lisensePlate, bool iselectric)
            : base(make, model, year, color, maxSpeed, numberOfSeats, hasAirConditionin)
        {
            LicensePlate = lisensePlate;
            IsElectric = iselectric;
        }

        public void Honk()
        {
            Console.WriteLine($"Сигнал {Make} {Model}!");
        }
    }
}
