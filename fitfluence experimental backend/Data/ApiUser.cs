using Microsoft.AspNetCore.Identity;

namespace fitfluence_experimental_backend.Data
{
    public class ApiUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }

    }
}
