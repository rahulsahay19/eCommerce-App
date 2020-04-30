using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Test Account",
                    Email = "test@test.com",
                    UserName = "test@test.com",
                    Address = new Address
                    {
                        FirstName = "Test",
                        LastName = "Account",
                        Street = "17th Street",
                        City = "Ranchi",
                        State = "Jharkhand",
                        Zipcode = "834000"
                    }
                };

                await userManager.CreateAsync(user, "Password@1");
            }
        }
    }
}