using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Function:BaseClass
    {
        public int FunctionID { get; set; }
        public string Code { get; set; }
        public List<int> Categories { get; set; }


    }
}
