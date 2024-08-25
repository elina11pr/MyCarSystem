using System;
using Microsoft.AspNetCore.SignalR.Client;
using MyCarSystem.ModelCar;


namespace MyCarSystem.ClientCar
{
    public class ClientHub
    {
        private readonly string _url;
        private HubConnection _connection;

        public ClientHub(string url)
        {
            _url = url;
        }
        public async Task ExecuteAsync()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(_url)
                .Build();

            await _connection.StartAsync();

        }

        public async Task<string> RegisterCar(CivilSedan newCar)
        {
            try
            {
                if (_connection != null)
                {
                    var carInfo = await _connection.InvokeAsync<string>("RegisterCar", newCar);
                    return carInfo;
                }
                else
                {
                    return "Connection is not established.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering car: {ex.Message}");
                return "No Car";
            }
        }
    }
}