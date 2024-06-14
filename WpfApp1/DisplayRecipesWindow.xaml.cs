using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1;

namespace RecipeProgramWPF
{
    public partial class DisplayRecipesWindow : Window
    {
        public DisplayRecipesWindow(ObservableCollection<Recipe> recipes)
        {
            InitializeComponent();
            recipeListView.ItemsSource = recipes;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
