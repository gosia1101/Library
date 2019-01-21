using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.LibraryModel
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Isbn { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookTag> BookTags { get; set; }
        public virtual ICollection<UserFavourite> UserFavourites { get; set; }
        public virtual ICollection<BookCopy> BookCopies { get; set; }

    }
}