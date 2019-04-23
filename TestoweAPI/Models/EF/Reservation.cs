using System;
using System.Collections.Generic;

namespace TestoweAPI.Models.EF
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public bool IsReserved { get; set; }
        public int MovieId { get; set; }
        public DateTime ReservedDate { get; set; }
        public int ReservedDays { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
