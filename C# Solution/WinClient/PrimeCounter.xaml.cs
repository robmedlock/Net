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
using System.Windows.Shapes;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for PrimeCounter.xaml
    /// </summary>
    public partial class PrimeCounter : Window
    {
        public PrimeCounter()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int limit;
            int result = int.TryParse(textBox.Text, out limit) ?
            await CalculatePrimesAsync(limit) : 0;
            label.Content = result;
        }

        public async Task<int> CalculatePrimesAsync(int limit)
        {
            Func<int> func = () => (
               from n in Enumerable.Range(2, limit).AsParallel()
               where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).
                                                 All(i => n % i > 0)
               select n).Count();
            int result = await Task.Run(func); //returns Task<int>
            return result;
        }

    }
}
