using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign
{
    public class Move
    {
        public string StepName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Column { get; set; }
        public Move(string name,int x, int y, int column)
        {
            this.StepName = name;
            this.X = x;
            this.Y = y;
            this.Column = column;
        }
        public Move()
        {

        }
    }
}
