using System;
using System.Collections.Generic;

namespace TestoweAPI.Models.EF
{
    public partial class Author
    {
        public Author()
        {
            Movie = new HashSet<Movie>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
