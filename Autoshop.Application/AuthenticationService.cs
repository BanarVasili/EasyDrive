using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Autoshop.Domain;
using Autoshop.Infrastructure;

namespace Autoshop.Application
{
    public class AuthenticationService
    {
        private readonly JewelryStoreContext _storeContext = new JewelryStoreContext();

        // Authenticates a user based on username and password.
        public Customer ValidateLogin(string userName, string password)
        {
            var account = _storeContext.Customers.FirstOrDefault(acc => acc.Username == userName);
            if (account != null && PasswordMatches(password, account.PasswordHash))
            {
                return account;
            }
            return null;
        }
        
        // Checks if the user has the required role.
        public bool UserHasRole(Customer account, string requiredRole)
        {
            return account.Role == requiredRole;
        }

        // Registers a new user with a username and password.
        public Customer RegisterNewUser(string userName, string password)
        {
            byte[] passwordHash = GeneratePasswordHash(password);

            var newUser = new Customer
            {
                Username = userName,
                PasswordHash = passwordHash,
                Role = "User"
            };
            
            _storeContext.Customers.Add(newUser);
            _storeContext.SaveChanges();
            
            return newUser;
        }
        
        // Generates a hash from a password using SHA256.
        private byte[] GeneratePasswordHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        // Compares the provided password with the stored hash.
        private bool PasswordMatches(string password, byte[] storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var computedHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }
    }
}
