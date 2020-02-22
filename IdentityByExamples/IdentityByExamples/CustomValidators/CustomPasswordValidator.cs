using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IdentityByExamples.CustomValidators
{
    public class CustomPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            var username = await manager.GetUserNameAsync(user);
            if (username.ToLower().Equals(password.ToLower()))
                return IdentityResult.Failed(new IdentityError { Description = "Username and Password can't be the same.", Code = "SameUserPass" });

            if (password.ToLower().Contains("password"))
                return IdentityResult.Failed(new IdentityError { Description = "The word password is not allowed for the Password.", Code = "PasswordContainsPassword" });

            return IdentityResult.Success;
        }
    }
}
