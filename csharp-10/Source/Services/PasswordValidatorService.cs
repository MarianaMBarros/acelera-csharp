using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Codenation.Challenge.Services
{
    public class PasswordValidatorService : IResourceOwnerPasswordValidator
    {
        private readonly CodenationContext _dbContext;

        public PasswordValidatorService(CodenationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.Email == context.UserName && c.Password == context.Password);
            if (user == null)
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant, "Invalid username or password");
            else
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), "custom", UserProfileService.GetUserClaims(user));
            }
        }
    }
}