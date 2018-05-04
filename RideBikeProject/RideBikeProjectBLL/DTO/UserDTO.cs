using RideBikeProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideBikeProjectBLL.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Nullable<long> ImageId { get; set; }
        public Nullable<long> TeamId { get; set; }
        public long RoleId { get; set; }

        public string Team { get; set; }
        public string Image { get; set; }

        public string Role { get; set; } = "User";
        public string Name => $"{FirstName} {LastName}";
        public int Age => GetAge(BirthDate);

        private static int GetAge(DateTime birthday)
        {
            DateTime reference = DateTime.Today;
            int age = reference.Year - birthday.Year;
            if (reference < birthday.AddYears(age)) age--;

            return age;
        }
    }
}
