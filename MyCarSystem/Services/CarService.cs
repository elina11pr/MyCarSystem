using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarSystem.Model;


namespace ServerCar.Services
{
    public class CarService
    {
        private Auto _registerCar;
        public void RegisterCar(Auto car)
        {
            _registerCar = car;
        }

        public Auto GetRegisterCar()
        {
            return _registerCar;
        }
        public async Task StartEngineAsync()
        {
            await _registerCar.StartEngineAsync();
        }

        public void StopEngine()
        {
            _registerCar.StopEngine();
        }
    }
}
