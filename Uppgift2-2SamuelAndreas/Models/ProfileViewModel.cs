namespace Uppgift2_2SamuelAndreas.Models
{
    public class ProfileViewModel
    {

        public string Email { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }  
        public string PhoneNumber { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string PasswordHash { get; set; }
        // Lägg till fler egenskaper efter behov
        
    }
}
