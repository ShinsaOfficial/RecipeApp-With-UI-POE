using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class SelectRecipesWindow : Window
    {
        private ObservableCollection<Recipe> recipes;

        public SelectRecipesWindow(ObservableCollection<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            recipeSelectionListView.ItemsSource = recipes;
        }

        private void GenerateMenu_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecipes = recipeSelectionListView.SelectedItems.Cast<Recipe>().ToList();

            if (selectedRecipes.Count == 0)
            {
                MessageBox.Show("No recipes selected.");
                return;
            }

            PieChartWindow pieChartWindow = new PieChartWindow(selectedRecipes);
            pieChartWindow.Owner = this;
            pieChartWindow.ShowDialog();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
