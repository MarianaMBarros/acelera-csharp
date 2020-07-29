using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class UserProfileService : IProfileService
    {
        private readonly CodenationContext _dbContext;

        public UserProfileService(CodenationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var request = context.ValidatedRequest as ValidatedTokenRequest;
            if (request != null)
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.Email == request.UserName);
                context.IssuedClaims.AddRange(GetUserClaims(user));
            }

        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }

        public static Claim[] GetUserClaims(User user)
        {
            var role = user.Email == "tegglestone9@blog.com" ? "Admin" : "User";
            return new[]
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
            };
        }

    }
}