using ElevatorControlSystem.Controllers;
using ElevatorControlSystem.Implementations;

Random Random = new Random();

var elevatorController = new ElevatorController();
var reportGenerator = new ReportGenerator();

// Add some random passenger requests
for (int i = 0; i < 20; i++) // Increase the number of requests
{
    int startFloor = Random.Next(1, 11);
    int endFloor = Random.Next(1, 11);
    if (startFloor != endFloor)
    {
        elevatorController.AddRequest(new PassengerRequest(startFloor, endFloor));
    }
}

Task.Run(async () =>
{
    while (true)
    {
        reportGenerator.GenerateReport(elevatorController.GetElevators());
        await Task.Delay(10000); // Report every 10 seconds
    }
});

Console.WriteLine("Elevator system is running. Press Enter to exit.");
Console.ReadLine();