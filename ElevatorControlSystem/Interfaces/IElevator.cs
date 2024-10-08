﻿using ElevatorControlSystem.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Interfaces
{
    public interface IElevator
    {
        int Id { get; }
        int CurrentFloor { get; }
        ElevatorDirection? Direction { get; }
        bool IsIdle { get; }
        void MoveToFloor(int floor);
    }
}
