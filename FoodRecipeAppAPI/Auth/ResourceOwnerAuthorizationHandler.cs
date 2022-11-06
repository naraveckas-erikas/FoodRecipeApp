using FoodRecipeAppAPI.Auth.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace FoodRecipeAppAPI.Auth
{
    public class ResourceOwnerAuthorizationHandler : AuthorizationHandler<ResourceOwnerRequirement, IUserOwnedResource>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOwnerRequirement requirement, IUserOwnedResource resource)
        {
            if (context.User.IsInRole(AppRoles.Admin) || context.User.FindFirst(JwtRegisteredClaimNames.Sub).Value == resource.UserId)
            {
                context.Succeed(requirement);
            }

            return  Task.CompletedTask;
        }
    }

    public record ResourceOwnerRequirement: IAuthorizationRequirement;
}
