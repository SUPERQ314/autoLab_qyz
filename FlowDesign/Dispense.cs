using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign
{
    public class Dispense
    {
        public string StepName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Col { get; set; }
        public int Vol { get; set; }
        public Dispense(string name,int x, int y, int col, int vol)
        {
            this.StepName = name;
            this.X = x;
            this.Y = y;
            this.Col = col;
            this.Vol = vol;
        }
        public Dispense()
        {

        }
    }
}
