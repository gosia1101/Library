using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.LibraryModel
{
    public class BookRental
    {
        public int Id { get; set; }
        public DateTime DateRental { get; set; }
        public DateTime DateReturn { get; set; }
        public int BookCopyId { get; set; }
        public virtual BookCopy BookCopy { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int EmployeeId { get; set; }
        public bool IsFinished { get; set; }
        public virtual Employee Employee { get; set; }
    }
}