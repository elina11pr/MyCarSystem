using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarSystem.ModelCar;

namespace MyCarSystem.ModelCar
{
    public class CivilSedan : Auto
    {
        public string LicensePlate { get; set; }
        public bool IsElectric { get; set; }
        public string InfotainmentSystem { get; set; }
        public bool HasSunroof { get; set; }

        public CivilSedan(string make, string model, int year, string color, int maxSpeed, string licensePlate, bool isElectric, string infotainmentSystem, bool hasSunroof)
            : base(make, model, year, color, maxSpeed)
        {
            LicensePlate = licensePlate;
            IsElectric = isElectric;
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
