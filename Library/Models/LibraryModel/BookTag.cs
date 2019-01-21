﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.LibraryModel
{
    public class BookTag
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Tag Tag { get; set; }
    }
}