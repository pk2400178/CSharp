﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTest
{
    class TestMotorcycle : Motorcycle
    {
        public override double GetTopSpeed()
        {
            return 100.0;
        }
    }
}
