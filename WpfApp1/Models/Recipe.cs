using System.Collections.Generic;
using WpfApp1;

public class Recipe
{
    public string Name { get; set; }
    public double TotalCalories => CalculateTotalCalories();
    public List<Ingredient> Ingredients { get; } = new List<Ingredient>();
    public List<string> Steps { get; } = new List<string>();

    public event Action<string, double> CaloriesExceeded;

    public Recipe(string name)
    {
        Name = name;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
        if (TotalCalories > 300)
        {
            CaloriesExceeded?.Invoke(Name, TotalCalories);
        }
    }

    public void AddStep(string step)
    {
        Steps.Add(step);
    }

    private double CalculateTotalCalories()
    {
        double total = 0;
        foreach (var ingredient in Ingredients)
        {
            total += ingredient.Calories;
        }
        return total;
    }
}
