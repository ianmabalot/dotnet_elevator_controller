using ElevatorControlSystem.Interfaces;
using ElevatorControlSystem.Shared.Enums;

namespace ElevatorControlSystem.Implementations
{
    public class Elevator : IElevator
    {
        public int Id { get; private set; }
        public int CurrentFloor { get; set; }
        public ElevatorDirection? Direction { get; private set; }
        public bool IsIdle => Direction == null;

        public Elevator(int id)
        {
            Id = id;
            CurrentFloor = 1; // Start at floor 1
            Direction = null; // Idle
        }

        public void MoveToFloor(int floor)
        {
            if (floor == CurrentFloor)
            {
                Console.WriteLine($"Elevator {Id} is already at Floor {CurrentFloor}.");
                return;
            }

            Direction = floor > CurrentFloor ? ElevatorDirection.Up : ElevatorDirection.Down;

            // Simulate elevator movement
            Console.WriteLine($"Elevator {Id} moving from Floor {CurrentFloor} to Floor {floor}.");
            Task.Delay(2000).Wait(); // Simulate time delay for moving

            CurrentFloor = floor;

            Console.WriteLine($"Elevator {Id} reached Floor {CurrentFloor}.");
            // After reaching the target floor, check if there's more work
            Direction = null; // Assume it's idle until a new request comes
        }
    }
}
