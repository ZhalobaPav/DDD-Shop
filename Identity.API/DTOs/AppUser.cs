using Microsoft.AspNetCore.Identity;

namespace Identity.API.DTOs
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
