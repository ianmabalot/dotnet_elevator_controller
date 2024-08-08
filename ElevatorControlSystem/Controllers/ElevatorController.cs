using ElevatorControlSystem.Interfaces;
using ElevatorControlSystem.Implementations;

namespace ElevatorControlSystem.Controllers
{
    public class ElevatorController
    {
        private List<IElevator> _elevators = new List<IElevator>();
        private Random _rand = new Random();

        public ElevatorController(int numberOfElevators)
        {            
            for (int i = 1; i <= numberOfElevators; i++) 
            {
                _elevators.Add(new Elevator(i));
            }
        }

        public void RequestElevator(int floor)
        {
            Console.WriteLine($"Request received from floor {floor}.");
            var nearestElevator = _elevators.OrderBy(e => Math.Abs(e.CurrentFloor - floor)).First();
            nearestElevator.AddRequest(floor);
            _ = nearestElevator.ProcessRequestsAsync(); // Fire and forget
        }

        public async Task SimulateAsync() 
        {
            // Generate random calls for elevator system
            for (int i = 0; i < 20; i++)
            {
                int floor = _rand.Next(1, 11);
                IElevator elevator = _elevators[_rand.Next(_elevators.Count)];
                elevator.AddRequest(floor);
                
                // Log the received call
                if (floor > elevator.CurrentFloor) {
                    Console.WriteLine($"Request added: Elevator {elevator.Id} has an 'up' call to floor {floor}.");
                } else if (floor < elevator.CurrentFloor) {
                    Console.WriteLine($"Request added: Elevator {elevator.Id} has a 'down' call to floor {floor}.");
                } else {
                    Console.WriteLine($"Request added: Elevator {elevator.Id} already on floor {floor}.");
                }
            }
            
            // Process requests asynchronously
            var tasks = _elevators.Select(elevator => elevator.ProcessRequestsAsync()).ToList();
            await Task.WhenAll(tasks);

            // Display final positions of elevators
            foreach(var elevator in _elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id} is at floor {elevator.CurrentFloor}.");
            }
        }
    }
}