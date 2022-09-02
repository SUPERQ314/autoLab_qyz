using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign
{
    public class GetTip
    {
        public string StepName { get; set; }
        public bool[] Tips { get; set; }
        public GetTip(string name, bool[] tips)
        {
            this.StepName = name;
            this.Tips = tips;
        }
        public GetTip(){

        }
    }
}
