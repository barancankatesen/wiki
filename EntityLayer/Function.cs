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
        public virtual List<Category> Categories { get; set; }


    }
}
