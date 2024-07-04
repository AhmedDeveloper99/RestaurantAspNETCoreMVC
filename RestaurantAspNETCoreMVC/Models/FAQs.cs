using System.ComponentModel.DataAnnotations;

namespace RestaurantAspNETCoreMVC.Models
{
    public class FAQs
    {
        [Key]
        public int Faq_Id { get; set; }
        public string Faq_Question { get; set; }
        public string Faq_Answer { get; set; }
    }
}
