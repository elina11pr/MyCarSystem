using System;
using Microsoft.AspNetCore.SignalR.Client;
using MyCarSystem.Model;


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

                _connection.Closed += async (error) =>
                {
                    Console.WriteLine($"Connection closed. Reason: {error?.Message}");
                    await Task.Delay(new Random().Next(0, 5) * 1000);
                    await _connection.StartAsync();
                };
   
                _connection.On<Auto>("StartEngine", async (car) =>
                {
                    Console.WriteLine($"Starting engine for {car.Make} {car.Model}");
                    await car.StartEngineAsync();
                } );


                 _connection.On<Auto>($"StartEngineWithStop", async(car) =>
                  {
                     Console.WriteLine($"Starting engine with automatic stop for {car.Make}, {car.Model}");
                     await car.StartEngineAsync();
                     await Task.Delay(15000);
                        car.StopEngine();
                     Console.WriteLine($"Engine stopped automatically with {car.Make}, {car.Model}");
                 });

            await _connection.StartAsync();
            Console.WriteLine("Connected to server");

                
            }

            public async Task<string> RegisterCar(Auto newCar)
            {
                try
                {
                    if (_connection == null || _connection.State != HubConnectionState.Connected)
                    {
                        return "Connection is not established.";
                    }

                    var carInfo = await _connection.InvokeAsync<string>("RegisterCar", newCar);
                    return carInfo;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error registering car: {ex.Message}");
                    return "No Car";
                }
            }

            public async Task<string> TestConnection()
            {
                try
                {
                    if (_connection == null || _connection.State != HubConnectionState.Connected)
                    {
                        return "Connection is not established.";
                    }

                    var response = await _connection.InvokeAsync<string>("TestConnection");
                    return response;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error testing connection: {ex.Message}");
                    return "Error during TestConnection";
                }
            }
        }

    }