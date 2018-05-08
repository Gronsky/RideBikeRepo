using System;
using System.ComponentModel.DataAnnotations;

namespace RideBike.Infrastructure.Models
{
    public class UserViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public Nullable<long> TeamId { get; set; }
        public long RoleId { get; set; }

        public string Team { get; set; }
        public string Image { get; set; }

        public string Role { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}