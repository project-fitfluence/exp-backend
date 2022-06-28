using System.ComponentModel.DataAnnotations;

namespace fitfluence_experimental_backend.Models.Users
{
    public class ApiUserDto: LoginDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? ProfilePicture { get; set; }
    }
}
