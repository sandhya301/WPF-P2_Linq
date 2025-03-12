using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P2_WpfAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
    private void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> numbers = new List<int>();

                foreach (var item in InputTextBox.Text.Split(','))
                {
                    if (int.TryParse(item.Trim(), out int num))
                    {
                        numbers.Add(num);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid input. Please enter only numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                var greaterThan50 = numbers.Where(n => n > 50).ToList();
                var sortedNumbers = numbers.OrderBy(n => n).ToList();
                var squaredNumbers = numbers.Select(n => n * n).ToList();


                FilteredBox.Text = string.Join(", ", greaterThan50);
                SortedBox.Text = string.Join(", ", sortedNumbers);
                SquaredBox.Text = string.Join(", ", squaredNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


