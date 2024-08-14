﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Interfaces
{
    public interface IReportGenerator
    {
        void GenerateReport(IEnumerable<IElevator> elevators);
    }
}
