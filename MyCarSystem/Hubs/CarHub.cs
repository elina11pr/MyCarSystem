using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using MyCarSystem.ModelCar;


namespace MyCarSystem.CarServer
{
    public class CarHub : Hub
    {
        private Auto _registeredCar;

        public async Task RegisterCar(CivilSedan car)
        {
            _registeredCar = car;
            Console.WriteLine("Pis");
            await Clients.Caller.SendAsync("CarRegistered", $"Car {car.Make} {car.Model} registered successfully.");
        }

        public async Task StartDriving()
        {
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
            _registeredCar.StopEngine();
            return Clients.Caller.SendAsync("CarStopped", "Car has stopped.");
        }

    }
}
