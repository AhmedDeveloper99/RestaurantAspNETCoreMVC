using System.ComponentModel.DataAnnotations;

namespace RestaurantAspNETCoreMVC.Models
{
    public class Recipe
    {
        [Key]
        public int Recipe_Id { get; set; }
        public string Recipe_Title { get; set; }
        public string Recipe_Description { get; set; }
    }

}