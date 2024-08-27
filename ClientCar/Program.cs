using MyCarSystem.ClientCar;
using MyCarSystem.Model;
using System;

namespace ClientCar
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");
            var myCar = new CivilSedan("Toyota", "Camry", 2020, "Black", 240, "AB123CD", false, "Premium", true);

            var url = "http://localhost:7054/current-time";


            var client = new ClientHub(url);
            await client.ExecuteAsync();

            var result = await client.RegisterCar(myCar);

            Console.WriteLine($"Server Response: {result}");

            await client.TestConnection();
            Console.WriteLine("Start engine command send");
            Console.WriteLine("Start engine with stop command send");

            var testResult = await client.TestConnection();
            Console.WriteLine(testResult);

            Console.WriteLine("Press any key to exit..."); Console.ReadKey();
        }
    }
}