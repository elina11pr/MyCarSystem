using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutoProject.Client.Models
{
    public class MilitalyVechile : Truck
    {
        public bool IsArmored { get; private set; }
        public string WeaponType { get; private set; }

        public MilitalyVechile(string make, string model, int year, string color, int maxSpeed, int loatCapacity, bool hasTrailer, bool isArmored, string weaponType)
            : base(make, model, year, color, maxSpeed, loatCapacity, hasTrailer)
        {
            IsArmored = isArmored;
            WeaponType = weaponType;
        }

        public void EngageWeapon()
        {
            if (!string.IsNullOrEmpty(WeaponType))
            {
                Console.WriteLine($"Озброєння {WeaponType} активовано на {Make} {Model}");
            }

        }
    }
}
