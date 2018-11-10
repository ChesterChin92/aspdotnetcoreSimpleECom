using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jinkuten.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string Description { get; set; }

        public DateTime ProductPublishedDate { get; set; }

        public string ImageName { get; set; }

        public long AspNetUsersId { get; set; }
        
    }
}
