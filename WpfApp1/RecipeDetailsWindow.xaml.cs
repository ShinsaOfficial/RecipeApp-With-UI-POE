using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp1
{
    public partial class RecipeDetailsWindow : Window
    {
        public Recipe NewRecipe { get; private set; }
        private ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        private ObservableCollection<string> steps = new ObservableCollection<string>();

        public RecipeDetailsWindow()
        {
            InitializeComponent();
            ingredientsListBox.ItemsSource = ingredients;
            stepsListBox.ItemsSource = steps;
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string name = ingredientNameTextBox.Text;
            double quantity = double.Parse(quantityTextBox.Text);
            string unit = unitTextBox.Text;
            double calories = double.Parse(caloriesTextBox.Text);
            string foodGroup = foodGroupTextBox.Text;

            Ingredient ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
            ingredients.Add(ingredient);

            ingredientNameTextBox.Clear();
            quantityTextBox.Clear();
            unitTextBox.Clear();
            caloriesTextBox.Clear();
            foodGroupTextBox.Clear();
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            steps.Add(stepTextBox.Text);
            stepTextBox.Clear();
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = recipeNameTextBox.Text;
            NewRecipe = new Recipe(recipeName);
            NewRecipe.CaloriesExceeded += HandleCaloriesExceeded;

            foreach (var ingredient in ingredients)
            {
                NewRecipe.AddIngredient(ingredient);
            }

            foreach (var step in steps)
            {
                NewRecipe.AddStep(step);
            }

            DialogResult = true;
            Close();
        }

        private void HandleCaloriesExceeded(string recipeName, double totalCalories)
        {
            MessageBox.Show($"Warning: The total calories of recipe '{recipeName}' exceed 300. Total calories: {totalCalories}");
        }
    }
}

