using ElevatorControlSystem.Interfaces;
using ElevatorControlSystem.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Implementations
{
    public class PassengerRequest : IPassengerRequest
    {
        public int StartFloor { get; private set; }
        public int EndFloor { get; private set; }
        public ElevatorDirection Direction { get; private set; }

        public PassengerRequest(int startFloor, int endFloor)
        {
            StartFloor = startFloor;
            EndFloor = endFloor;
            Direction = startFloor < endFloor ? ElevatorDirection.Up : ElevatorDirection.Down;
        }
    }
}
