using Microsoft.EntityFrameworkCore;

namespace RestaurantAspNETCoreMVC.Models
{
    public class myContext : DbContext
    {
        public myContext(DbContextOptions<myContext> options) :base(options)
        {
            
        }

        public DbSet<Register> tbl_register { get; set; }
        public DbSet<Feedback> tbl_feedback { get; set; }
        public DbSet<Contact> tbl_contact { get; set; }
        public DbSet<Flavour> tbl_flavour { get; set; }
        public DbSet<Books> tbl_book { get; set; }
        public DbSet<OrderBook> tbl_order { get; set; }
        public DbSet<BuyBook> tbl_buybook { get; set; }
        public DbSet<FAQs> tbl_Faqs { get; set; }
        public DbSet<Recipe> tbl_recipe { get; set; }
        public DbSet<Admin> tbl_admin { get; set; }
    }
}
