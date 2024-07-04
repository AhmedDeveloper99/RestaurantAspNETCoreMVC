using System.ComponentModel.DataAnnotations;

namespace RestaurantAspNETCoreMVC.Models
{
    public class Register
    {
        [Key]
        public int User_Id { get; set; }
        [Required(ErrorMessage ="*")]
        public string User_Name { get; set; }
        [Required(ErrorMessage = "*")]
        public string User_Email { get; set; }
        [Required(ErrorMessage = "*")]
        public string User_Number { get; set; }
        [Required(ErrorMessage = "*")]
        public string User_Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Compare("User_Password")]
        public string User_Cpassword { get; set; }
        [Required(ErrorMessage = "*")]
        public string User_Membership { get; set; }
    }
}
