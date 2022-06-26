using System.ComponentModel.DataAnnotations;

namespace fitfluence_experimental_backend.Models.Users
{
    public class ApiUserDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? ProfilePicture { get; set; }
    }
}
