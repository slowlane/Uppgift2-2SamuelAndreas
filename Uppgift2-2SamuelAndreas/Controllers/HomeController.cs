using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Uppgift2_2SamuelAndreas.Models;

namespace Uppgift2_2SamuelAndreas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager; // Inject UserManager

        public HomeController(UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(); // Om användaren inte hittas, returnera 404
            }

            // Skapa en ViewModel för att skicka användardata till vyn
            var profileViewModel = new ProfileViewModel
            {
                Email = user.Email,
                Id = user.Id,
                UserName = user.UserName,
                
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                TwoFactorEnabled = user.TwoFactorEnabled,
                EmailConfirmed = user.EmailConfirmed,


        // Lägg till fler egenskaper efter behov, t.ex. namn, registreringsdatum osv.
    };

            return View(profileViewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }



}
