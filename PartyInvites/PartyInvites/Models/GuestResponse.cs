using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Please enter your email addres")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Please enter a valid email address")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "Please select attend")]
        public Boolean? WillAttend { get; set; }
    }
}