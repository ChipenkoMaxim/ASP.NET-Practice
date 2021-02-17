using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportStore.WebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        public String Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}