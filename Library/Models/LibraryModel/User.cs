using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.LibraryModel
{
    public class User
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<UserFavourite> UserFavourites { get; set; }
        public virtual ICollection<Penalty> Penalties { get; set; }
        public virtual ICollection<BookRental> BookRentals { get; set; }
    }
}