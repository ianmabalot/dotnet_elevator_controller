using ElevatorControlSystem.Interfaces;
using ElevatorControlSystem.Controllers;

namespace ElevatorControlSystem.Implementations
{
    public class CallButton : ICallButton
    {
        public int Floor { get; private set; }
        private ElevatorController _controller;
        public CallButton(int floor, ElevatorController controller)
        {
            Floor = floor;
            _controller = controller;
        }

        public void Press()
        {
            Console.WriteLine($"Call button pressed on floor {Floor}.");
            _controller.RequestElevator(Floor);
        }

        public void RequestElevator()
        {
            _controller.RequestElevator(Floor);
        }
    }
}