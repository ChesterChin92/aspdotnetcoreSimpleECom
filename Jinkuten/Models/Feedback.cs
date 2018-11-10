using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Jinkuten.Models
{
    public class Feedback
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public long AspNetUserId { get; set; }

        public string FeedbackMessage { get; set; }
    }
}
