using System;
using System.Collections.Generic;

namespace TestoweAPI.Models.EF
{
    public partial class Reviews
    {
        public int ReviewId { get; set; }
        public int MovieId { get; set; }
        public string Review { get; set; }
        public int Rate { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
