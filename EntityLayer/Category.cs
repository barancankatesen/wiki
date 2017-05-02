using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Category:BaseClass
    {
        public int CategoryID { get; set; }

        public virtual List<Function> Functions { get; set; }


    }
}
