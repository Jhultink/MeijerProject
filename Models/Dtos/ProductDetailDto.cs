using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeijerProject.Models.Dtos
{
    public class ProductDetailDto : ProductDto
    {
        public required string Price { get; set; }
    }
}
