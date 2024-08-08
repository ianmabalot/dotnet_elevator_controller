using ElevatorControlSystem.Controllers;
// See https://aka.ms/new-console-template for more information

var elevatorControlSystem = new ElevatorController(4);
await elevatorControlSystem.SimulateAsync();                                                    

Console.ReadKey();