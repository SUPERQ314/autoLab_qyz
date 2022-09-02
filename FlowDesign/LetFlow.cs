using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign
{
    public class LetFlow
    {
        public string StepName { get; set; }
        public int RestVol { get; set; }
        public LetFlow(string name,int vol)
        {
            this.StepName = name;
            this.RestVol=vol;
        }
        public LetFlow()
        {

        }
    }
}
