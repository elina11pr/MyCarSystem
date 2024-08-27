using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarSystem.Model;

namespace MyCarSystem.ClientCar.Services
{
    public class CarClientService
    {
        private Auto _registerCar;

        public async Task StartDriving(Auto car)
        {
            if (car == null)
            {
                Console.WriteLine("Car is null. Cannot start driving.");
                return;
            }

            try
            {
                Console.WriteLine($"Starting driving for {car.Make} {car.Model}");
                await car.StartEngineAsync();
                Console.WriteLine($"Driving {car.Make} {car.Model}");
            }
            catch (EngineStoppedException ex)
            {
                Console.WriteLine($"Error while driving: {ex.Message}");
            }
        }



    }
}
