using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RideBikeWEB.Models
{
    public class UserModel
    {
        public long Id { get; set; }

     //   [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

     //   [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

    //    [Required(ErrorMessage = "Please enter your email address.")]
      //  [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        //      [DataType(DataType.Date)]
        //     [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public Nullable<long> ImageId { get; set; }
        public Nullable<long> TeamId { get; set; }
        public long RoleId { get; set; }

        public string Name { get; }
        public int Age { get; }
    }
}