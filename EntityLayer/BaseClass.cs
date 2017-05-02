using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class BaseClass
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
    }
}
