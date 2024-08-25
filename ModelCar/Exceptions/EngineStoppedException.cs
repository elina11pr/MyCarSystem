using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarSystem.ModelCar;


namespace MyCarSystem.ModelCar
{

    public class EngineStoppedException : Exception
    {
        public EngineStoppedException(string message) : base(message)
        {
        }
    }


}
