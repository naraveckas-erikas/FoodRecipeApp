namespace FoodRecipeAppAPI.Auth.Models
{
    public static class AppRoles
    {
        public const string Admin = nameof(Admin);
        public const string User = nameof(User);

        public static readonly IReadOnlyCollection<string> All = new[] { Admin, User };
    }
}
