using MyCarSystem.ClientCar;
using MyCarSystem.ModelCar;
using System;

namespace ClientCar
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");
            var myCar = new CivilSedan("Toyota", "Camry", 2020, "Black", 240, 5, true, "AB123CD", false, "Premium", true);

            var url = "http://localhost:7054/current-time";

            var client = new ClientHub(url);
            await client.ExecuteAsync();

            var result = await client.RegisterCar(myCar);

            Console.WriteLine($"Server Response: {result}");
            var testResult = await client.TestConnection();
            Console.WriteLine(testResult);

            Console.WriteLine("Press any key to exit..."); Console.ReadKey();
        }
    }
}