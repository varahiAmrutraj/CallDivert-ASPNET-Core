using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallDivert.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public TimeSpan FromTime { get; set; }

        [Required]
        public TimeSpan ToTime { get; set; }

        // Navigation property to establish the relationship with the User entity
        public User User { get; set; }
    }
}
