using MyCarSystem.ModelCar;
using System.Reflection;

public class MilitaryVehicle : Truck
{
    public bool IsArmored { get; set; }
    public string WeaponType { get; set; }

    public MilitaryVehicle(string make, string model, int year, string color, int maxSpeed, int loadCapacity, bool hasTrailer, bool isArmored, string weaponType)
        : base(make, model, year, color, maxSpeed, loadCapacity, hasTrailer)
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
