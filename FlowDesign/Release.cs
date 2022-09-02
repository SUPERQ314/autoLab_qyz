using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign
{
    public class Release
    {
        public string StepName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }
        public Release(int x, int y,string type)
        {
            this.X = x;
            this.Y = y;
            this.Type = type;
        }
        public Release()
        {

        }
    }
}
