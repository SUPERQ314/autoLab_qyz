using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign
{
    public class DiscardTip
    {
        public String StepName { get; set; }
        public int Num { get; set; }
        public DiscardTip(string name,int num)
        {
            this.StepName = name;
            this.Num = num;
        }
        public DiscardTip()
        {

        }
    }
}
