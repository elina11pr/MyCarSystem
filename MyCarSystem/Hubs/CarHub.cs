using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using MyCarSystem.Model;


namespace MyCarSystem.CarServer
{
    public class CarHub : Hub
    {
        private Auto _registeredCar;
          
        public async Task<string> RegisterCar(Auto car)
        {
            try
            {
                Console.WriteLine("RegisterCar method invoked.");

                if (car == null)
                {
                    Console.WriteLine("Car parameter is null.");
                    return "Error: Car parameter is null.";
                }

                Console.WriteLine($"Car Details: Make - {car.Make}, Model - {car.Model}");

                _registeredCar = car;
                Console.WriteLine("Car registered successfully.");

                await StartDriving(); 

                return $"Car {car.Make} {car.Model} registered successfully.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RegisterCar: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return "Error registering car.";
            }
        }

        public async Task StartEngineOnClient()
        {
            if (_registeredCar == null)
            {
                Console.WriteLine("No car registered.");
                return;
            }

            
            await Clients.All.SendAsync("StartEngine", _registeredCar);
        }

        public async Task StartEngineOnClientWithStop()
        {
            if (_registeredCar == null)
            {
                Console.WriteLine("No car registered.");
                return;
            }

            
            await Clients.All.SendAsync("StartEngineWithStop", _registeredCar);
        }

        private async Task StartDriving()
        {
            if (_registeredCar == null)
            {
                Console.WriteLine("Car start");
            }

            try
            {
                await _registeredCar.StartEngineAsync();
            }
            catch (EngineStoppedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void  StopDriving()
        {
            if (_registeredCar == null)
            {
                Console.WriteLine("No car registered.");
                return;
            }

            _registeredCar.StopEngine();
            
            
        }

        public Task<string> TestConnection()
        {
            Console.WriteLine("It works! (Server)");
            return Task.FromResult("It works! (Client)");
        }
    }


}
