using ElevatorControlSystem.Interfaces;

namespace ElevatorControlSystem.Implementations
{
    public class Elevator : IElevator
    {
        public int Id { get; private set; }
        public int CurrentFloor { get; private set; }
        public List<int> Calls { get; private set; } = new List<int>();

        public Elevator(int id)
        {
            Id = id;
            CurrentFloor = 1; //Assume all elevators start at the first floor
        }

        public async Task MoveToFloorAsync(int floor)
        {
            if (CurrentFloor == floor) return;                      
            int floorsToMove = Math.Abs(CurrentFloor - floor);
            Console.WriteLine($"Elevator {Id} moving from floor {CurrentFloor} to floor {floor}.");
            await Task.Delay(floorsToMove * 10000); // Simulate time taken to move between floors
            CurrentFloor = floor;
            await Task.Delay(10000); // Simulate time taken for passengers to enter/leave the car.
        }

        public async Task ProcessRequestsAsync()
        {
            while (Calls.Count > 0)
            {
                // Process the requests in ascending order
                Calls.Sort();
                int currentFloor = CurrentFloor;
                bool goingUp = Calls[0] > currentFloor;

                foreach(var request in Calls.ToList())
                {
                    if((goingUp && request < currentFloor) || (!goingUp && request > currentFloor))
                    {
                        continue; // Skip requests that are in the opposite direction
                    }

                    // Log the request direction
                    if (request > currentFloor)
                    {
                        Console.WriteLine($"Elevator {Id} moving up to floor {request}.");
                    }
                    else if (request < currentFloor)
                    {
                        Console.WriteLine($"Elevator {Id} moving down to floor {request}.");
                    }

                    await MoveToFloorAsync(request);
                    Calls.Remove(request);
                }
            }
        }

        public void AddRequest(int floor)
        {
            if(!Calls.Contains(floor))
            {
                Calls.Add(floor);
            }   
        }
    }
}