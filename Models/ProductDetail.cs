using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeijerProject.Models
{
    public class ProductDetail : Product
    {
        public required string Price { get; set; }
    }
}
