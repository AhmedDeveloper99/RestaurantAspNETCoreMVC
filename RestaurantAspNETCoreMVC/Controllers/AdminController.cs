using Microsoft.AspNetCore.Mvc;
using RestaurantAspNETCoreMVC.Models;

namespace RestaurantAspNETCoreMVC.Controllers
{
    public class AdminController : Controller
    {
        private myContext _context;
        private IWebHostEnvironment _env;
        public AdminController(myContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var row = HttpContext.Session.GetString("user_sessions");
            if (row == null)
            {
                return RedirectToAction("login");
            }
            return View();
        }
        public IActionResult Login()
        {
            var restriction = HttpContext.Session.GetString("user_sessions");
            if (restriction != null)
            {
                return RedirectToAction("index");   
            }
            return View();
        }
        [HttpGet]
        public IActionResult Profile()
        {
            var restriction = HttpContext.Session.GetString("user_sessions");
            var data = _context.tbl_admin.Where(a => a.Admin_Id == int.Parse(restriction)).ToList();      
            return View(data);
        }
        [HttpPost]
        public IActionResult Profile(Admin admin)
        {
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
      
        public IActionResult ChangeProfile(IFormFile Admin_Image, Admin admin)
        {

            string Image_path = Path.Combine(_env.WebRootPath, "Admin_images", Admin_Image.FileName);

            FileStream fs = new FileStream(Image_path, FileMode.Create);
            Admin_Image.CopyTo(fs);

            admin.Admin_Image = Admin_Image.FileName;
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
        [HttpPost]
        public IActionResult Login(string adminname, string adminpassword)
        {
         var data =  _context.tbl_admin.FirstOrDefault(a=>a.Admin_Name == adminname);
            if (data != null && data.Admin_Password == adminpassword)
            {
                HttpContext.Session.SetString("user_sessions",data.Admin_Id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Login Failed";
                return View();
            }
         
        }

        [HttpGet]
        public IActionResult FamousFlavor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FamousFlavor(IFormFile Flavour_Image, Flavour flv)
        {
            string Image_path = Path.Combine(_env.WebRootPath, "famous_flavorIMG", Flavour_Image.FileName);

            FileStream fs = new FileStream(Image_path, FileMode.Create);
            Flavour_Image.CopyTo(fs);

            flv.Flavour_Image = Flavour_Image.FileName;



            _context.tbl_flavour.Add(flv);
            _context.SaveChanges();

            return RedirectToAction("FamousFlavorFetch");
        }
        [HttpGet]
        public IActionResult FamousFlavorFetch()
        {
            return View(_context.tbl_flavour.ToList());
        }
        [HttpGet]
        public IActionResult FamousFlavorEdit(int id)
        {
            return View(_context.tbl_flavour.Find(id));
        }
        [HttpPost]
        public IActionResult FamousFlavorEdit(Flavour flv)
        {
            _context.tbl_flavour.Update(flv);
            _context.SaveChanges();
            return RedirectToAction("FamousFlavorFetch");
        }

        public IActionResult FamousFlavorEditImage(IFormFile Flavour_Image, Flavour flv)
        {
            string Image_path = Path.Combine(_env.WebRootPath, "famous_flavorIMG", Flavour_Image.FileName);

            FileStream fs = new FileStream(Image_path, FileMode.Create);
            Flavour_Image.CopyTo(fs);

            flv.Flavour_Image = Flavour_Image.FileName;


            _context.tbl_flavour.Update(flv);
            _context.SaveChanges();
            return RedirectToAction("FamousFlavorFetch");
        }

        [HttpGet]
        public IActionResult FamousFlavorDelete(int id)
        {
            return View(_context.tbl_flavour.Find(id));
        }
        [HttpPost, ActionName("FamousFlavorDelete")]
        public IActionResult FamousFlavorDeleteConfirm(int id)
        {
            var delete = _context.tbl_flavour.Find(id);
            _context.tbl_flavour.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("FamousFlavorFetch");
        }
        [HttpGet]
        public IActionResult FamousFlavorDetails(int id)
        {
            return View(_context.tbl_flavour.Find(id));
        }
        [HttpGet]
        public IActionResult BooksAdded()
        {
            return View();

        }
        [HttpPost]
        public IActionResult BooksAdded(Books book, IFormFile Book_Image)
        {
            string Image_path = Path.Combine(_env.WebRootPath, "Books_Image", Book_Image.FileName);

            FileStream fs = new FileStream(Image_path, FileMode.Create);
            Book_Image.CopyTo(fs);

            book.Book_Image = Book_Image.FileName;

            _context.tbl_book.Add(book);
            _context.SaveChanges();
            return RedirectToAction("BooksFecth");
        }
        [HttpGet]
        public IActionResult BooksFecth()
        {
            var book =_context.tbl_book.ToList();
            return View(book);
        }
        [HttpGet]
        public IActionResult BooksEdit(int id)
        {
            var book = _context.tbl_book.Find(id);
            return View(book);
        }
            [HttpPost]
             public IActionResult BooksEdit(Books book)
             {
                _context.tbl_book.Update(book);
                _context.SaveChanges();
            return RedirectToAction("BooksFecth");
        }
        public IActionResult BooksEditImage(IFormFile Book_Image, Books book)
        {

            string Image_path = Path.Combine(_env.WebRootPath, "Books_Image", Book_Image.FileName);

            FileStream fs = new FileStream(Image_path, FileMode.Create);
            Book_Image.CopyTo(fs);

            book.Book_Image = Book_Image.FileName;
            _context.tbl_book.Update(book);
            _context.SaveChanges();
            return RedirectToAction("BooksFecth");
        }
        [HttpGet]
        public IActionResult BooksDetails(int id)
        {
            var book = _context.tbl_book.Find(id);
            return View(book);
        }
        [HttpGet]
        public IActionResult BooksDelete(int id)
        {
            var book = _context.tbl_book.Find(id);
            return View(book);
        }
        [HttpPost, ActionName("BooksDelete")]
         public IActionResult BooksDeleteConfirm(int id)
         {
         var book = _context.tbl_book.Find(id);
         _context.tbl_book.Remove(book);
         _context.SaveChanges();
         return RedirectToAction("BooksFecth");
         }
        [HttpGet]
        public IActionResult Orders()
        {
            return View(_context.tbl_buybook.ToList());
        }
        [HttpGet]
        public IActionResult OrdersEdit(int id)
        {
            return View(_context.tbl_buybook.Find(id));
        }
        [HttpPost]
        public IActionResult OrdersEdit(BuyBook buy)
        {
            _context.tbl_buybook.Update(buy);
            _context.SaveChanges();
            return RedirectToAction("Orders");
        }
        [HttpGet]
        public IActionResult OrderDetails(int id)
        {
            return View(_context.tbl_buybook.Find(id));
        }
        [HttpGet]
        public IActionResult OrderDelete(int id)
        {
            return View(_context.tbl_buybook.Find(id));
        }
        [HttpPost , ActionName("OrderDelete")]
        public IActionResult OrderDeleteConfirm(int id)
        {
           var ids = _context.tbl_buybook.Find(id);
            _context.tbl_buybook.Remove(ids);
            _context.SaveChanges();
            return RedirectToAction("Orders");
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View(_context.tbl_contact.ToList());
        }
        [HttpGet]
        public IActionResult ContactDetails(int id)
        {
            return View(_context.tbl_contact.Find(id));
        }
        [HttpGet]
        public IActionResult ContactDelete(int id)
        {
            return View(_context.tbl_contact.Find(id));
        }
        [HttpPost , ActionName("ContactDelete")]
        public IActionResult ContactDeleteConfirm(int id)
        {
            var row = _context.tbl_contact.Find(id);
            _context.tbl_contact.Remove(row);
            _context.SaveChanges();
            return RedirectToAction("Contact");
        }
        [HttpGet]
        public IActionResult Feedback()
        {
            return View(_context.tbl_feedback.ToList());
        }
        [HttpGet]
        public IActionResult FeedbackDetails(int id)
        {
            return View(_context.tbl_feedback.Find(id));
        }
        [HttpGet]
        public IActionResult FeedbackDelete(int id)
        {
            return View(_context.tbl_feedback.Find(id));
            
        }
        [HttpPost, ActionName("FeedbackDelete")]
        public IActionResult FeedbackDeleteConfirm(int id)
        {
         _context.tbl_feedback.Remove(_context.tbl_feedback.Find(id));
            _context.SaveChanges();
        return RedirectToAction("Feedback");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(_context.tbl_register.ToList());
        }
        [HttpGet]
        public IActionResult FAQitemsAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FAQitemsAdd(FAQs faq)
        {
            _context.tbl_Faqs.Add(faq);
            _context.SaveChanges();
            return RedirectToAction("FAQitems");
        }
        [HttpGet]
        public IActionResult FAQitems()
        {
            return View(_context.tbl_Faqs.ToList());
        }
        [HttpGet]
        public IActionResult FAQitemsDetails(int id)
        {
            return View(_context.tbl_Faqs.Find(id));
        }
        [HttpGet]
        public IActionResult FAQitemsEdit(int id)
        {
            return View(_context.tbl_Faqs.Find(id));
        }
        [HttpPost]
        public IActionResult FAQitemsEdit(FAQs faq)
        {
            _context.tbl_Faqs.Update(faq);
            _context.SaveChanges();
            return RedirectToAction("FAQitems");
        }
        [HttpGet]
        public IActionResult FAQitemsDelete(int id)
        {
            return View(_context.tbl_Faqs.Find(id));
        }
        [HttpPost, ActionName("FAQitemsDelete")]
        public IActionResult FAQitemsDeleteConfirm(int id)
        {
            var row =_context.tbl_Faqs.Find(id);
            _context.tbl_Faqs.Remove(row);
            _context.SaveChanges();
            return RedirectToAction("FAQitems");
        }
        [HttpGet]
        public IActionResult RecipeAdded()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecipeAdded(Recipe recipe)
        {
            _context.tbl_recipe.Add(recipe);
            _context.SaveChanges();
            return RedirectToAction("Recipe");
        }
        [HttpGet]
        public IActionResult Recipe()
        {
            return View(_context.tbl_recipe.ToList());
        }
        [HttpGet]
        public IActionResult RecipeDetails(int id)
        {
            return View(_context.tbl_recipe.Find(id));
        }
        [HttpGet]
        public IActionResult RecipeDelete(int id)
        {
            return View(_context.tbl_recipe.Find(id));
        }
        [HttpPost, ActionName("RecipeDelete")]
        public IActionResult RecipeDeleteConfirm(int id)
        {
            var row = _context.tbl_recipe.Find(id);
            _context.tbl_recipe.Remove(row);
            _context.SaveChanges();
            return RedirectToAction("Recipe");
        }
        [HttpGet]
        public IActionResult RecipeEdit(int id)
        {
            return View(_context.tbl_recipe.Find(id));
        }
        [HttpPost]
        public IActionResult RecipeEdit(Recipe rcp)
        {
            _context.tbl_recipe.Update(rcp);
            _context.SaveChanges();
            return RedirectToAction("Recipe");
        }
        public IActionResult logout()
        {
            HttpContext.Session.Remove("user_sessions");
            return RedirectToAction("login"); 
        }

    }
}
