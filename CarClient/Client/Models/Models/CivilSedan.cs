using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutoProject.Client.Models
{
    public class CivilSedan : CivilCar
    {
        public string InfotainmentSystem { get; private set; }
        public bool HasSunroof { get; private set; }
        public CivilSedan(string make, string model, int year, string color, int maxSpeed, int numberOfSeats, bool hasAirConditioning, string licensePlate, bool isElectric, string infotainmentSystem, bool hasSunroof)
             : base(make, model, year, color, maxSpeed, numberOfSeats, hasAirConditioning, licensePlate, isElectric)
        {
            InfotainmentSystem = infotainmentSystem;
            HasSunroof = hasSunroof;
        }
        public void OpenSunroof()
        {
            if (HasSunroof)
            {
                Console.WriteLine($"Люк {Make} {Model} відкрито.");
            }
            else
            {
                Console.WriteLine($"У {Make} {Model} немає люка.");
            }
        }
    }
}
