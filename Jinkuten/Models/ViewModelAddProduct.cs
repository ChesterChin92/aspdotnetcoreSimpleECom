using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jinkuten.Models
{
    public class ViewModelAddProduct : Product
    {
        public IFormFile ImageFile { get; set; }
    }
}
