using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{
    public partial class PieChartWindow : Window
    {
        public PieChartWindow(List<Recipe> selectedRecipes)
        {
            InitializeComponent();
            InitializePieChart(selectedRecipes);
        }

        private void InitializePieChart(List<Recipe> selectedRecipes)
        {
            var foodGroupCounts = new Dictionary<string, double>();

            // Calculate food group counts based on selected recipes
            foreach (var recipe in selectedRecipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (foodGroupCounts.ContainsKey(ingredient.FoodGroup))
                    {
                        foodGroupCounts[ingredient.FoodGroup] += ingredient.Calories;
                    }
                    else
                    {
                        foodGroupCounts[ingredient.FoodGroup] = ingredient.Calories;
                    }
                }
            }

            // Create series collection for the pie chart
            SeriesCollection seriesCollection = new SeriesCollection();

            foreach (var kvp in foodGroupCounts)
            {
                seriesCollection.Add(new PieSeries
                {
                    Title = kvp.Key,
                    Values = new ChartValues<double> { kvp.Value },
                    DataLabels = true
                });
            }

            // Set the series collection to the PieChart
            pieChart.Series = seriesCollection;
        }
    }
}

