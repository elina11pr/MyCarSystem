using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarSystem.ModelCar;


namespace MyCarSystem.ModelCar
{
    public class Auto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int MaxSpeed { get; set; }
        public bool IsEngineRunning { get; set; } = false;

        public Auto(string make, string model, int year, string color, int maxSpeed)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            MaxSpeed = maxSpeed;
        }

        public async Task StartEngineAsync()
        {
            if (!IsEngineRunning)
            {
                IsEngineRunning = true;
                Console.WriteLine($"Двигун {Make} {Model} запущено.");
                await Task.Delay(15000);
                StopEngine();
                throw new EngineStoppedException($"{Make} {Model} автоматично зупинився через 15 секунд.");
            }
        }

        public void StopEngine()
        {
            if (IsEngineRunning)
            {
                IsEngineRunning = false;
                Console.WriteLine($"Двигун {Make} {Model} зупинено.");
            }
        }
    }

}
