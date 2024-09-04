using Microsoft.AspNetCore.Identity;

namespace Uppgift2_2SamuelAndreas.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string DisplayName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
