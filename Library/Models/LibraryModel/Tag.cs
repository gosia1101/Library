using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.LibraryModel
{
    public class Tag
    {
        public int Id { get; set; }
       
        public string Title { get; set; }

        public virtual ICollection<BookTag> BookTags { get; set; }

    }
}