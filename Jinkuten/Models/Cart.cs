using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jinkuten.Models
{
    public class Cart
    {
        public long Id { get; set; }

        public long AspNetUsersId { get; set; }

        public long ProductId { get; set; }
    }
}
