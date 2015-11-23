﻿using PhidgetInteraction;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            InterPhi phi = new InterPhi();
            phi.AddSensor(new Sensor("0", "A", 850));
            phi.AddSensor(new Sensor("1", "D", 850));
            phi.AddSensor(new Sensor("2", "SPACE", 500));
            phi.StartPhidget();
               
            System.Console.ReadLine();
        }
    }
}
