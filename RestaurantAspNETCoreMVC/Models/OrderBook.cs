using RestaurantAspNETCoreMVC.Migrations;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAspNETCoreMVC.Models
{
    public class OrderBook
       {
       
        public int Id { get; set; }
        public int Book_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Cost { get; set; }
        public string PaymentOption { get; set; }
    }
}
