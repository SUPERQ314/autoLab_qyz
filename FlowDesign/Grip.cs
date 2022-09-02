using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign
{
    public class Grip
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }
        public Grip(string name,int x,int y,string type)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Type = type;
        }
        public Grip()
        {

        }
    }
}
