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
        private readonly UserManager<ApplicationUser> _userManager; // Inject UserManager

        public HomeController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)

                {
                    ViewData["DisplayName"] = user.DisplayName;
                }
            }

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
                return NotFound(); // Om anv�ndaren inte hittas, returnera 404
            }

            // Skapa en ViewModel f�r att skicka anv�ndardata till vyn
            var profileViewModel = new ProfileViewModel
            {
                Email = user.Email,
                Id = user.Id,
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                
                //PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                TwoFactorEnabled = user.TwoFactorEnabled,
                EmailConfirmed = user.EmailConfirmed,


        // L�gg till fler egenskaper efter behov, t.ex. namn, registreringsdatum osv.
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
