namespace FoodRecipeAppAPI.Data.Dtos.Ingredients
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
    }
}
