namespace FoodRecipeAppAPI.Data.Dtos.Recipes
{
    public class UpdateRecipeDto
    {
        public string Type { get; set; }
        public string OriginCountry { get; set; }
        public int TimeToPrepare { get; set; }
        public int PortionsCount { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
    }
}
