using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index(string search)
        {
            var books = db.Books.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                books = books.Where(x => x.Title.Contains(search));
            }
            List<int> cart;
            if (Session["Cart"] == null)
                cart = new List<int>();
            else
                cart = (List<int>)Session["Cart"];
            Session["Cart"] = cart;
            ViewBag.Cart = cart;
            books = books.Where(x => x.BookCopies.Any(c => !c.BookRentals.Any(r => r.IsFinished)));
            return View(books.ToList());
        }

        public ActionResult AddToCart(int id)
        {
            List<int> cart;
            if (Session["Cart"] == null)
                cart = new List<int>();
            else
                cart = (List<int>)Session["Cart"];
            if (!cart.Contains(id))
                cart.Add(id);
            Session["Cart"] = cart;
            ViewBag.Cart = cart;
            return RedirectToAction(nameof(this.Index));
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
    }
}
