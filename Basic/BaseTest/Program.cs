using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMotorcycle moto = new TestMotorcycle();

            moto.StartEngine();
            //moto.AddGas(15);
            var drive = moto.Drive(5, 20);
            double speed = moto.GetTopSpeed();
            Console.WriteLine("My top speed is {0}", speed);
            Console.ReadKey();
        }
    }
}
