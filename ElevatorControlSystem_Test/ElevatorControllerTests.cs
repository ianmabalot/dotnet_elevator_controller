using ElevatorControlSystem.Controllers;
using ElevatorControlSystem.Implementations;
using ElevatorControlSystem.Interfaces;
using ElevatorControlSystem.Shared.Enums;
using Moq;

namespace ElevatorControlSystem_Test
{
    public class ElevatorControllerTests
    {

        [Fact]
        public void Should_Add_Request_And_Allocate_Elevator()
        {
            // Arrange
            var elevatorController = new ElevatorController();

            var elevator1 = new Mock<IElevator>();
            var elevator2 = new Mock<IElevator>();
            var elevator3 = new Mock<IElevator>();
            var elevator4 = new Mock<IElevator>();

            // Set up elevator mock responses
            elevator1.Setup(e => e.CurrentFloor).Returns(1);
            elevator2.Setup(e => e.CurrentFloor).Returns(5);
            elevator3.Setup(e => e.CurrentFloor).Returns(10);
            elevator4.Setup(e => e.CurrentFloor).Returns(3);

            elevator1.Setup(e => e.IsIdle).Returns(true);
            elevator2.Setup(e => e.IsIdle).Returns(true);
            elevator3.Setup(e => e.IsIdle).Returns(true);
            elevator4.Setup(e => e.IsIdle).Returns(true);

            // Add mock elevators to controller
            var elevators = new List<IElevator> { elevator1.Object, elevator2.Object, elevator3.Object, elevator4.Object };
            foreach (var elevator in elevators)
            {
                // Manually inject elevators to the controller
                elevatorController.GetType().GetField("_elevators", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .SetValue(elevatorController, elevators);
            }

            var request = new Mock<IPassengerRequest>();
            request.Setup(r => r.StartFloor).Returns(2);
            request.Setup(r => r.EndFloor).Returns(6);
            request.Setup(r => r.Direction).Returns(ElevatorDirection.Up);

            // Act
            elevatorController.AddRequest(request.Object);

            // Check the result
            elevator1.Verify(e => e.MoveToFloor(2), Times.Once); // Move to start floor
            elevator1.Verify(e => e.MoveToFloor(6), Times.Once); // Move to end floor
        }
    }
}