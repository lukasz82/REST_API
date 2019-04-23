using System;
using System.Collections.Generic;

namespace TestoweAPI.Models.EF
{
    public partial class Movie
    {
        public Movie()
        {
            Reservation = new HashSet<Reservation>();
            Reviews = new HashSet<Reviews>();
        }

        public int MovieId { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string MovieDescription { get; set; }
        public DateTime ProductionDate { get; set; }
        public string Title { get; set; }

        public virtual Author Author { get; set; }
        public virtual Genres Genre { get; set; }
        public virtual RentMovie RentMovie { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
