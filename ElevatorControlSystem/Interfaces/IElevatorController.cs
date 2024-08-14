using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Interfaces
{
    public interface IElevatorController
    {
        void AddRequest(IPassengerRequest request);
        IEnumerable<IElevator> GetElevators();
    }
}
