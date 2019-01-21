using Library.Models;
using Library.Models.LibraryModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index(string search)
        {
            var cart = (List<int>)Session["Cart"];
            if (cart == null || !cart.Any())
            {
                return View("EmptyCart");
            }
            var books = db.Books.AsQueryable();
            books = books.Where(x => cart.Contains(x.Id));
                            
            return View(books.ToList());
        }

        public ActionResult DeleteFromCart(int id)
        {
            List<int> cart;
            if (Session["Cart"] == null)
                cart = new List<int>();
            
            else
                cart = (List<int>)Session["Cart"];
            if (cart.Contains(id))
                cart.Remove(id);
            Session["Cart"] = cart;
            ViewBag.Cart = cart;
            return RedirectToAction(nameof(this.Index));
        }

        public ActionResult Rent()
        {
            //wyciagnac id usera
            //pojechac po petli z carta
            //stworzyc nowe BookRental
            //dodac do bazy
            var cart = (List<int>)Session["Cart"];
            if (cart == null || !cart.Any())
            {
                return View("EmptyCart");
            }
            string ADusername = User.Identity.Name.ToString();
            string guid=User.Identity.GetUserId();

            var books = db.Books.AsQueryable();
            var libUser = db.Users.AsQueryable().FirstOrDefault(x => x.Guid == guid);
            var dateRental = DateTime.Now;
            var dateReturn = dateRental.AddMonths(3);
            foreach (var cartBook in cart)
            {
                var copy = books.Where(x => x.Id == cartBook).Select(book => book.BookCopies.FirstOrDefault(bookCopy => !bookCopy.BookRentals.Any(r => r.IsFinished))).FirstOrDefault();
                var bookRental = new BookRental
                {
                    BookCopyId = copy.Id,
                    
                    UserId = libUser.Id,
                    DateRental = dateRental,
                    DateReturn=dateReturn,
                    EmployeeId=1,
                    IsFinished=true,
                };
            }

            return RedirectToAction(nameof(this.Index));
        }
    }
}