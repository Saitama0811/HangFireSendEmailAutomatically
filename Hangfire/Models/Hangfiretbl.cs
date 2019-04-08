using System;
using System.Collections.Generic;

namespace Hangfire.Models
{
    public partial class Hangfiretbl
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
