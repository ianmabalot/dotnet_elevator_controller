using ElevatorControlSystem.Interfaces;

namespace ElevatorControlSystem.Implementations
{
    public class ReportGenerator : IReportGenerator
    {
        public void GenerateReport(IEnumerable<IElevator> elevators)
        {
            Console.Clear();
            foreach (var elevator in elevators)
            {
                var direction = elevator.IsIdle ? "Idle" : elevator.Direction.ToString();
                Console.WriteLine($"Elevator {elevator.Id} is at Floor {elevator.CurrentFloor} and is {direction}");
            }
            Console.WriteLine();
        }
    }
}
