using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarSystem.Model;


namespace MyCarSystem.Model
{

    public class EngineStoppedException : Exception
    {
        public EngineStoppedException(string message) : base(message)
        {
        }
    }


}
