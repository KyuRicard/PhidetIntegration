using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhidgetInteraction
{
    public class Sensor
    {
        private string id;
        private string value;
        private int min;
        private bool activated = false;

        public Sensor(string id, string value, int min)
        {
            this.id = id;
            this.value = value;
            this.min = min;
        }

        public int Minim
        {
            get { return min; }
            set { min = value; }
        }

        public bool Activated
        {
            get { return activated; }
            set { activated = value; }
        }

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public int RawValue
        {
            get; set;
        }
    }
}
