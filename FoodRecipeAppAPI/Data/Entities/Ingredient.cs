namespace FoodRecipeAppAPI.Data.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public Recipe Recipe { get; set; }
    }
}
