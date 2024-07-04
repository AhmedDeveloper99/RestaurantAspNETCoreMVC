using System.ComponentModel.DataAnnotations;

namespace RestaurantAspNETCoreMVC.Models
{
    public class Feedback
    {
        [Key]
        public int Feedback_Id { get; set; }
        public string Feedback_Name { get; set; }
        public string Feedback_Email { get; set; }
        public string Feedback_IceCream { get; set; }
        public string Feedback_Message { get; set; }
    }
}
