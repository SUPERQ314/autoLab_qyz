using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign
{
    public class Aspiration
    {
        public string StepName { get; set; }
        public int EachVolume { get; set; }
        public Aspiration(string name, int x, int y, int col, int eachvolume)
        {
            this.StepName = name;
            this.EachVolume = eachvolume;
        }
        public Aspiration()
        {

        }
    }
}
