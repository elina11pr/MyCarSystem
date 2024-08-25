using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAutoProject.Client.Exceptions;


namespace MyAutoProject.Client.Models
{
    public class Auto
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string Color { get; private set; }
        public int MaxSpeed { get; private set; }
        public bool IsEngineRunning { get; private set; } = false;

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

        public void StartEngine()
        {
            if (!IsEngineRunning)
            {
                IsEngineRunning = true;
                Console.WriteLine($"Двигун {Make} {Model} запущено.");
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
