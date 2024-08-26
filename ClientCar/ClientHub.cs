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

                _connection.Closed += async (error) =>
                {
                    Console.WriteLine($"Connection closed. Reason: {error?.Message}");
                    await Task.Delay(new Random().Next(0, 5) * 1000);
                    await _connection.StartAsync();
                };

                _connection.On<string>("EngineStopped", (message) =>
                {
                    Console.WriteLine($"Engine stopped: {message}");
                });

                _connection.On<string>("CarStopped", (message) =>
                {
                    Console.WriteLine($"Car stopped: {message}");
                });

                await _connection.StartAsync();
                Console.WriteLine("Connected to the server.");
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