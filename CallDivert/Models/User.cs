using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CallDivert.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "WhatsApp Number")]
        public string WhatsappNumber { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
    }
}