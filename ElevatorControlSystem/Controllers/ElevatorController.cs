using ElevatorControlSystem.Interfaces;
using ElevatorControlSystem.Implementations;
using ElevatorControlSystem.Shared.Enums;

namespace ElevatorControlSystem.Controllers
{
    public class ElevatorController : IElevatorController
    {
        private readonly List<IElevator> _elevators;
        private readonly List<IPassengerRequest> _requests;
        private static readonly Random Random = new Random();

        public ElevatorController()
        {
            _elevators = Enumerable.Range(1, 4).Select(id => new Elevator(id) as IElevator).ToList();
            _requests = new List<IPassengerRequest>();
        }

        public void AddRequest(IPassengerRequest request)
        {
            _requests.Add(request);
            Console.WriteLine($"Request added: StartFloor {request.StartFloor}, EndFloor {request.EndFloor}, Direction {request.Direction}");
            ProcessRequests();
        }

        private void ProcessRequests()
        {
            // Process each request in the queue
            while (_requests.Any())
            {
                var request = _requests.First();
                var bestElevator = GetBestElevatorForRequest(request);

                if (bestElevator != null)
                {
                    // Move the elevator to the start floor
                    bestElevator.MoveToFloor(request.StartFloor);
                    // Then move to the end floor
                    bestElevator.MoveToFloor(request.EndFloor);
                    // Remove the request from the queue
                    _requests.Remove(request);
                }
            }
        }

        private IElevator GetBestElevatorForRequest(IPassengerRequest request)
        {
            // Find elevators that are either idle or moving in the correct direction
            var availableElevators = _elevators
                .Where(e => e.IsIdle ||
                            (e.Direction == request.Direction &&
                             (e.CurrentFloor < request.StartFloor && e.Direction == ElevatorDirection.Up ||
                              e.CurrentFloor > request.StartFloor && e.Direction == ElevatorDirection.Down)));

            // If no available elevators are found, select the nearest one regardless of its current state
            if (!availableElevators.Any())
            {
                availableElevators = _elevators;
            }

            return availableElevators
                .OrderBy(e => Math.Abs(e.CurrentFloor - request.StartFloor)) // Nearest elevator
                .FirstOrDefault();
        }

        public IEnumerable<IElevator> GetElevators() => _elevators;
    }
}