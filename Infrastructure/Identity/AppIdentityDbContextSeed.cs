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
                    DisplayName = "Rahul Sahay",
                    Email = "rahul@sahay.com",
                    UserName = "rahul@sahay.com",
                    Address = new Address
                    {
                        FirstName = "Rahul",
                        LastName = "Sahay",
                        Street = "17th Street",
                        City = "Bangalore",
                        State = "Karnataka",
                        Zipcode = "560012"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}