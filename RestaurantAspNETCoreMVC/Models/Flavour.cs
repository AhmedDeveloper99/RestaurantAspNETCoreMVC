using System.ComponentModel.DataAnnotations;

namespace RestaurantAspNETCoreMVC.Models
{
    public class Flavour
    {
        [Key]
        public int Flavour_Id { get; set; }
        public string Flavour_Name { get; set; }
        public string Flavour_Image { get; set; }
        public string Flavour_Desc { get; set; }
    }
}
