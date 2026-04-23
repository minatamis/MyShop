using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyShop.Application.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public string Role { get; set; } = "User";
    }
}
