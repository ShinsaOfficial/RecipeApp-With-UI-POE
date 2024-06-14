using System.Collections.ObjectModel;
using System.Windows;
using RecipeProgramWPF;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
            recipeListView.ItemsSource = recipes;
        }

        private void EnterRecipeDetails_Click(object sender, RoutedEventArgs e)
        {
            RecipeDetailsWindow detailsWindow = new RecipeDetailsWindow();
            detailsWindow.Owner = this;
            detailsWindow.ShowDialog();

            if (detailsWindow.DialogResult == true)
            {
                recipes.Add(detailsWindow.NewRecipe);
            }
        }

        private void DisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.");
            }
            else
            {
                DisplayRecipesWindow displayWindow = new DisplayRecipesWindow(recipes);
                displayWindow.Owner = this;
                displayWindow.ShowDialog();
            }
        }

        private void SelectRecipesForMenu_Click(object sender, RoutedEventArgs e)
        {
            SelectRecipesWindow selectRecipesWindow = new SelectRecipesWindow(recipes);
            selectRecipesWindow.Owner = this;
            selectRecipesWindow.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
