using System.ComponentModel.DataAnnotations;

namespace RestaurantAspNETCoreMVC.Models
{
    public class Books
    {
        [Key]
        public int Book_Id { get; set; }
        public string Book_Name { get; set; }
        public string Book_Image { get; set; }
        public string Book_Description { get; set; }
        public string? Book_Cost { get; set; }
    }
}
