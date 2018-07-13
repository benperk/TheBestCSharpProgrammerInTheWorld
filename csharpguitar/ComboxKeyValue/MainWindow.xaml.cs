using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComboBox
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<ComboBoxPairs> cbp = new List<ComboBoxPairs>();

            cbp.Add(new ComboBoxPairs("Janurary", 1));
            cbp.Add(new ComboBoxPairs("February", 2));
            cbp.Add(new ComboBoxPairs("March", 3));

            comboBox1.DisplayMemberPath = "monthName";
            comboBox1.SelectedValuePath = "monthNumber";
            comboBox1.ItemsSource = cbp;
            comboBox1.SelectionChanged -= new SelectionChangedEventHandler(comboBox1_SelectionChanged);
            comboBox1.Text = "Janurary";
            comboBox1.SelectionChanged += new SelectionChangedEventHandler(comboBox1_SelectionChanged);

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxPairs cbp = (ComboBoxPairs)comboBox1.SelectedItem;

            string monthName = cbp.monthName;
            int monthNumber = cbp.monthNumber;

            MessageBox.Show(monthName, "KEY - comboBox1_SelectionChanged", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show(monthNumber.ToString(), "VALUE - comboBox1_SelectionChanged", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
