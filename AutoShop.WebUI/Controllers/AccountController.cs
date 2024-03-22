using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Autoshop.Application;
using Autoshop.Domain;

namespace AutoShop.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthenticationService _authenticationService = new AuthenticationService();

        // GET: Display the login page
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Process the login form
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var customer = _authenticationService.ValidateLogin(username, password);
            if (customer != null)
            {
                SetupAuthSession(customer);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View();
        }

        // GET: Display the registration page
        public ActionResult Register()
        {
            return View();
        }

        // POST: Process the registration form
        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            var customer = _authenticationService.RegisterNewUser(username, password);
            if (customer != null)
            {
                SetupAuthSession(customer);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            return View();
        }

        // Log out the current user and clear session
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, "")
            {
                Expires = DateTime.Now.AddYears(-1)
            });

            return RedirectToAction("Login");
        }

        // Setup authentication session for the logged-in user
        private void SetupAuthSession(Customer customer)
        {
            var ticket = new FormsAuthenticationTicket(
                1, // Ticket version
                customer.Username,
                DateTime.Now,
                DateTime.Now.AddMinutes(20), // Expiration time
                true, // Persistent cookie for "Remember me" option
                customer.Role, // User data, typically roles
                "/");

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
        }
    }
}
