using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeijerProject.Models
{
    public class Product
    {
        public required int Id { get; set; }
        public required string ImageUrl { get; set; }
        public required string Summary { get; set; }
        public required string Title { get; set; }
    }
}
