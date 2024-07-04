using System.ComponentModel.DataAnnotations;

namespace RestaurantAspNETCoreMVC.Models
{
    public class Contact
    {
        [Key]
        public int Contact_Id { get; set; }
        public string Contact_Name { get; set; }
        public string Contact_Email { get; set; }
        public string Contact_Branch { get; set; }
        public string Contact_Message { get; set; }
    }
}
