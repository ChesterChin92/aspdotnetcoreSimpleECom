using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jinkuten.Models
{
    public class WishList
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public long AspNetUsersId { get; set; }
    }
}
