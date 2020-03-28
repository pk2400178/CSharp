using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTest
{
    abstract class Motorcycle
    {
        // Anyone can call this.
        public void StartEngine() 
        {

        }
        // Only derived classes can call this.
        protected void AddGas(int gallons) 
        { 

        }
        // Derived classes can override the base class implementation.
        public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

        // Derived classes can override the base class implementation.
        public virtual int Drive(TimeSpan time, int speed) { /* Method statements here */ return 0; }

        // Derived classes must implement this.
        public abstract double GetTopSpeed();
    }
}
