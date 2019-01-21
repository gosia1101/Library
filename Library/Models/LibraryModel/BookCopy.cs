using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.LibraryModel
{
    public class BookCopy
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public virtual ICollection<BookRental> BookRentals { get; set; }
    }
}