using Phidgets;
using System;
using System.Collections.Generic;

namespace PhidgetInteraction
{
    public class InterPhi
    {        
        private InterfaceKit ikit;        
        private List<Sensor> sensors;
        
        public InterPhi()
        {
            sensors = new List<Sensor>();
        }

        public void StartPhidget()
        {
            try
            {
                ikit = new InterfaceKit();
                ikit.Attach += (sender, e) =>
                {
                    Console.WriteLine("Analog {0} attached!",
                        e.Device.SerialNumber.ToString());
                };

                ikit.Detach += (sender, e) =>
                {
                    Console.WriteLine("Analog {0} dettached!",
                        e.Device.SerialNumber.ToString());
                };

                ikit.Error += (sender, e) =>
                {
                    Console.WriteLine("Error {0}!",
                        e.Description);
                };

                ikit.SensorChange += (sender, e) =>
                {
                    if (sensors == null)
                        return;
                    foreach(Sensor s in sensors)
                    {
                        if (s.ID == e.Index.ToString() && e.Value < s.Minim)
                        {
                            s.Activated = true;
                        }
                        else
                        {
                            s.Activated = false;
                        }
                    }
                };

                ikit.open();
            }
            catch(PhidgetException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Wait()
        {
            ikit.waitForAttachment();
        }

        public void AddSensor(Sensor s)
        {
            sensors.Add(s);
        }

        public List<Sensor> GetKeys()
        {
            return sensors;
        }

        public bool GetValue(string key)
        {
            foreach(Sensor s in sensors)
            {
                if (s.Value == key)
                {
                    return s.Activated;
                }
            }
            return false;
        }
    }
}
