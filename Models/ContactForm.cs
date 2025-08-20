using System;
using System.ComponentModel.DataAnnotations;

namespace pr2.Models
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(1000)]
        public string Message { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
