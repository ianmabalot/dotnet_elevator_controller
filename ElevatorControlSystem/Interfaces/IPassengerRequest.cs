using ElevatorControlSystem.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Interfaces
{
    public interface IPassengerRequest
    {
        int StartFloor { get; }
        int EndFloor { get; }
        ElevatorDirection Direction { get; }
    }
}
