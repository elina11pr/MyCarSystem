using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using MyCarSystem.ModelCar;


namespace MyCarSystem.CarServer
{
    public class CarHub : Hub
    {
        private Auto _registeredCar;

        public Task<string> RegisterCar(Auto car)
        {
            try
            {
                Console.WriteLine("RegisterCar method invoked.");

                if (car == null)
                {
                    Console.WriteLine("Car parameter is null.");
                    return Task.FromResult("Error: Car parameter is null.");
                }

                Console.WriteLine($"Car Details: Make - {car.Make}, Model - {car.Model}");

                _registeredCar = car;
                Console.WriteLine("Car registered successfully.");

                return Task.FromResult($"Car {car.Make} {car.Model} registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RegisterCar: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return Task.FromResult("Error registering car.");
            }
        }

        public async Task StartDriving()
        {
            if (_registeredCar == null)
            {
                await Clients.Caller.SendAsync("Error", "No car registered.");
                return;
            }

            try
            {
                await _registeredCar.StartEngineAsync();
            }
            catch (EngineStoppedException ex)
            {
                await Clients.Caller.SendAsync("EngineStopped", ex.Message);
            }
        }

        public Task StopDriving()
        {
            if (_registeredCar == null)
            {
                return Clients.Caller.SendAsync("Error", "No car registered.");
            }

            _registeredCar.StopEngine();
            return Clients.Caller.SendAsync("CarStopped", "Car has stopped.");
        }

        public Task<string> TestConnection()
        {
            Console.WriteLine("It works! (Server)");
            return Task.FromResult("It works! (Client)");
        }
    }

}
