using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Myket_Shop.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }


        public List<Order> Orders { get; set; }
    }
}
