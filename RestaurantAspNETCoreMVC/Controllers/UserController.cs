using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantAspNETCoreMVC.Migrations;
using RestaurantAspNETCoreMVC.Models;

namespace RestaurantAspNETCoreMVC.Controllers
{
    public class UserController : Controller
    {
        private myContext _context;
        private object SelectedBook;

        public UserController(myContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
           ViewBag.CheckSession = HttpContext.Session.GetString("user_session");
                return View();
 
        }
        [HttpGet]
        public IActionResult About()
        {
            ViewBag.CheckSession = HttpContext.Session.GetString("user_session");
            return View();

        }
        [HttpGet]
        public IActionResult Register()
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem { Value = "Monthly (15$)", Text = "Monthly (15$)" },
                new SelectListItem { Value = "Yearly (150$)", Text = "Yearly (150$)" },
            };
            ViewBag.Gender = Gender;
            return View();

        }
        [HttpPost]
        public IActionResult Register(Register reg)
        {

            if (reg.User_Cpassword == reg.User_Password)
            {
                _context.tbl_register.Add(reg);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = "Incorrect Password";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Register reg)
        {
          

           var row = _context.tbl_register.FirstOrDefault(x=> x.User_Email == reg.User_Email &&
            x.User_Password == reg.User_Password);
            
            if (row != null)
            {
                HttpContext.Session.SetString("user_session", row.User_Id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Incorrect username or password";
                return View();
             }
            
        }
        [HttpGet]
        public IActionResult Contact()
        {
            ViewBag.CheckSession = HttpContext.Session.GetString("user_session");
            List<SelectListItem> Branch = new()
            {
                new SelectListItem { Value = "Washington Street ", Text = "Washington Street " },
                new SelectListItem { Value = "Saint Marks Place", Text = "Saint Marks Place" },
                new SelectListItem { Value = "Allen Street", Text = "Allen Street" },
                 new SelectListItem { Value = "6th Avenue", Text = "6th Avenue" },
                new SelectListItem { Value = "Crosby Street", Text = "Crosby Street" },

            };
            ViewBag.Branch = Branch;
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact c)
        {
            _context.tbl_contact.Add(c);
            _context.SaveChanges();

            return RedirectToAction("AfterContact");
        }

        [HttpGet]
        public IActionResult Feedback()
        {
            ViewBag.CheckSession = HttpContext.Session.GetString("user_session");
            List<SelectListItem> Flavor = new()
            {
                new SelectListItem { Value = "Vanilla", Text = "Vanilla" },
                new SelectListItem { Value = "Chocolate", Text = "Chocolate" },
                new SelectListItem { Value = "Chocolate chip", Text = "Chocolate chip" },
                 new SelectListItem { Value = "Strawberry", Text = "Strawberry" },
                new SelectListItem { Value = "Black currant ", Text = "Black currant" },
                new SelectListItem { Value = "Cherry", Text = "Cherry" },
                 new SelectListItem { Value = "Butterscotch", Text = "Butterscotch" },
                new SelectListItem { Value = "Walnut", Text = "Walnut" },
                new SelectListItem { Value = "Vanilla and strawberry (two in one)", Text = "Vanilla and strawberry (two in one)" },
                 new SelectListItem { Value = "Pistachio", Text = "Pistachio" },
                new SelectListItem { Value = "Banana", Text = "Banana" },
                new SelectListItem { Value = "Banana Chocolate chip", Text = "Banana Chocolate chip" },
                 new SelectListItem { Value = "Chocolate almond", Text = "Chocolate almond" },
                new SelectListItem { Value = "Chocolate truffle", Text = "Chocolate truffle" },
                new SelectListItem { Value = "Kiwi fruit", Text = "Kiwi fruit" },
                 new SelectListItem { Value = "Pineapple", Text = "Pineapple" },
               // new SelectListItem { Value = "Fruit and nut", Text = "Fruit and nut" },
                //new SelectListItem { Value = "Cashew Caramel crunch", Text = "Cashew Caramel crunch" },

            };
            ViewBag.Flavor = Flavor;
            return View();
        }
        [HttpPost]
        public IActionResult Feedback(Feedback feed)
        {
            _context.tbl_feedback.Add(feed);
            _context.SaveChanges();

            return RedirectToAction("AfterLogin");
        }
        public IActionResult AfterLogin()
        {
            return View();
        }
        
        public IActionResult AfterContact()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user_session");
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult FamousFlavor()
        {
            ViewBag.CheckSession = HttpContext.Session.GetString("user_session");
            if (HttpContext.Session.GetString("user_session") == null)
            {
                return RedirectToAction("Login");
            }
            return View(_context.tbl_flavour.ToList());
        }
        [HttpGet]
        public IActionResult Books(string txtsearch)
        {
            List<Books> books = new List<Books>();
            if (string.IsNullOrEmpty(txtsearch))
            {
                ViewBag.CheckSession = HttpContext.Session.GetString("user_session");
                return View(_context.tbl_book.ToList());
                
            }
            else
            {
                var searchTerm = txtsearch + "%";

                books = _context.tbl_book.FromSqlInterpolated($@"select * from tbl_book where Book_Name LIKE {searchTerm}").ToList();

                return View(books);
            }
           
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
           var row = _context.tbl_book.Find(id);
            if (row == null)
            {
                return RedirectToAction("index");
            }
            return View(row);
        }
        [HttpPost]
        public IActionResult Order(int bookId)
        {
            var selectbook = _context.tbl_book.FirstOrDefault(b=>b.Book_Id == bookId);
            if (selectbook == null)
            {
                return RedirectToAction("index");
            }

            //var order = new OrderBook
            //{
            //    SelectedBook = selectedBook,
            //    Order_TotalCost = SelectedBook.
            //};

            //order.SelectedBook = _context.tbl_book.FirstOrDefault(b=>b.Book_Id == SelectedBook.Book_Id);
            //order.Order_TotalCost = order.SelectedBook.Book_Cost;
            return View();
        }

        [HttpGet]
        public IActionResult BuyBook(int id)
        {
            ViewBag.CheckSession = HttpContext.Session.GetString("user_session");
            var book = _context.tbl_book.Find(id);
            if (book == null)
            {
                return RedirectToAction("index");
            }

            var order = new BuyBook
            {
                Book_Id = book.Book_Id,
                Cost = book.Book_Cost   
            };
            List<SelectListItem> PaymentMethod = new()
            {
                new SelectListItem { Value = "credit and debit card", Text = "credit and debit card" },
                new SelectListItem { Value = "amazon pay", Text = "amazon pay" },
                new SelectListItem { Value = "Paypal", Text = "Paypal" },
                 new SelectListItem { Value = "visa", Text = "visa" },


            };
            ViewBag.payment = PaymentMethod;

            return View(order);
        }


        [HttpPost]
        public IActionResult BuyBook(BuyBook order)
        {
            // Save order details to database or process payment
            var newOrder = new BuyBook
            {
                Book_Id = order.Book_Id,
                Name = order.Name,
                Email = order.Email,
                ContactNumber = order.ContactNumber,
                Address = order.Address,
                Cost = order.Cost, // Ensure this is a string or change property type to decimal
                PaymentOption = order.PaymentOption
            };

            _context.tbl_buybook.Add(newOrder);
            _context.SaveChanges();
            return RedirectToAction("AfterBuyBook");
            //return RedirectToAction("OrderConfirmation", new { orderId = order.Id });
        }


        [HttpGet]
        public IActionResult AfterBuyBook()
        {
            ViewBag.CheckSession = HttpContext.Session.GetString("user_session");
            //var order = _context.tbl_buybook.Find(orderId);
            //if (order == null)
            //{
            //    return NotFound();
            //}

            // Optionally, show confirmation details
            return View();
        }
        [HttpGet]
        public IActionResult FaqShow()
        {
            ViewBag.CheckSession = HttpContext.Session.GetString("user_session");
            return View(_context.tbl_Faqs.ToList());
        }
        [HttpGet]
        public IActionResult FreeRecipeShow()
        {
            ViewBag.CheckSession = HttpContext.Session.GetString("user_session");
            return View(_context.tbl_recipe.ToList());
        }

    }
}
