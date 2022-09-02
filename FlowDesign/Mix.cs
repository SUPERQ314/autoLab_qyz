using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign
{
    public class Mix
    {
        public string StepName { get; set;}
        public string Strength { get; set; }
        public Mix(string name, string strength)
        {
            this.StepName = name;
            this.Strength = strength;
        }
        public Mix()
        {

        }
    }
}
