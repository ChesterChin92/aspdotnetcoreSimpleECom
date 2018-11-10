using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jinkuten.Models
{
    public class ViewModelAddFeedback
    {
        public IQueryable<Feedback> Feedback { get; set; }

        public Feedback fbk { get; set; }

        public long Id { get; set; }

        public long UserId { get; set; }
    }
}
