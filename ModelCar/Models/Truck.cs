using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyCarSystem.Model;

namespace MyCarSystem.Model
{
    public class Truck : Auto
    {
        public int LoadCapacity { get; set; }
        public bool HasTrailer { get; set; }
        public Truck(string make, string model, int year, string color, int maxSpeed, int loatCapacity, bool hasTrailer) : base(make, model, year, color, maxSpeed)
        {
            LoadCapacity = loatCapacity;
            HasTrailer = hasTrailer;
        }
        public void AttachTrailer()
        {
            if (HasTrailer)
            {
                Console.WriteLine($"Причеп {Make} {Model} підключено.");
            }
            else
            {
                Console.WriteLine($"У {Make} {Model} немає причепа.");
            }
        } 

        public void DetachTrailer()
        {
            if (HasTrailer)
            {
                Console.WriteLine($"Причеп {Make} {Model} відключено.");
            }
            else
            {
                Console.WriteLine($"У {Make} {Model} немає причепа.");
            }
        }
    }
}
