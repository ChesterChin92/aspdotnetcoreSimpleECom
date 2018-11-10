using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jinkuten.Models
{
    public class ViewModelProduct
    {
        public long Id { get; set; }

        public Product product { get; set; }

        public IQueryable<Product> products { get; set; }
    }
}
