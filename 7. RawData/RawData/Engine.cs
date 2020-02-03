using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    public class Engine
    {
        public Engine(double speed, double power)
        {
            this.EngineSpeed = speed;
            this.EnginePower = power;
        }
        
        public double EngineSpeed { get; set; }
        public double EnginePower { get; set; }

    }
}
