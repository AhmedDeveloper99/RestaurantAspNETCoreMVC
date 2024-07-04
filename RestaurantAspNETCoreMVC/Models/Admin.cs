﻿using System.ComponentModel.DataAnnotations;

namespace RestaurantAspNETCoreMVC.Models
{
    public class Admin
    {
        [Key]
        public int Admin_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Admin_Email { get; set; }
        public string Admin_Password { get; set; }
        public string Admin_Image { get; set; }
    }
}
