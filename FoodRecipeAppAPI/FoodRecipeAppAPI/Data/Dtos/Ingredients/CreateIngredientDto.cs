namespace FoodRecipeAppAPI.Data.Dtos.Ingredients
{
    public class CreateIngredientDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
    }
}
