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

using System.Data;
using System.Collections;
using System.Reflection;

namespace FilterWPF
{
    public partial class MainWindow : Window
    {
        ListCollectionView CollectionViewList;
        DataTable DataTableFiltered;

        private readonly TimeSpan filterDelay = TimeSpan.FromMilliseconds(350);
        private DelayAction delayedAction;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = LoadDataGrid().DefaultView;
            dataGrid1.Columns[0].Visibility = System.Windows.Visibility.Hidden;
            SetStatusColumn();
        }

        private DataTable LoadDataGrid()
        {
            DataTable dt = new DataTable();
            DataTableFiltered = new DataTable();

            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Column1", typeof(string));
            dt.Columns.Add("Column2", typeof(string));
            dt.Columns.Add("Column3", typeof(string));
            dt.Columns.Add("Column4", typeof(string));
            dt.Columns.Add("Column5", typeof(string));

            dt.Rows.Add("True", "corresponds", "keyword", "vector", "calculate", "proposed");
            dt.Rows.Add("Null", "frequency", "local parameter", "weights", "binary", "relevance");
            dt.Rows.Add("True", "matching", "limitations", "dimension", "infinity", "expected");
            dt.Rows.Add("False", "information retrieval", "space", "high-dimensional problems", "inference", "implicit");
            dt.Rows.Add("True", "beliefs", "observed", "probabilities", "posterior probability", "global parameter");

            DataTableFiltered.Columns.Add("Status", typeof(string));
            DataTableFiltered.Columns.Add("Column1", typeof(string));
            DataTableFiltered.Columns.Add("Column2", typeof(string));
            DataTableFiltered.Columns.Add("Column3", typeof(string));
            DataTableFiltered.Columns.Add("Column4", typeof(string));
            DataTableFiltered.Columns.Add("Column5", typeof(string));

            List<string> list1 = new List<string>() { "True", "corresponds", "keyword", "vector", "calculate", "proposed" };
            List<string> list2 = new List<string>() { "Null", "frequency", "local parameter", "weights", "binary", "relevance" };
            List<string> list3 = new List<string>() { "True", "matching", "limitations", "dimension", "infinity", "expected" };
            List<string> list4 = new List<string>() { "False", "information retrieval", "space", "high-dimensional problems", "inference", "implicit" };
            List<string> list5 = new List<string>() { "True", "beliefs", "observed", "probabilities", "posterior probability", "global parameter" };

            List<List<string>> alist = new List<List<string>>() { list1, list2, list3, list4, list5 };

            IList results = (IList)alist;

            CollectionViewList = new ListCollectionView(results);

            return dt;
        }

        public bool ContainsIt(object value)
        {
            if (DataTableFiltered.Columns.Count > 1)
            {
                //There is more than 1 column in DataGrid
                List<string> DataGridRowList = (List<string>)value;
                foreach (object item in DataGridRowList)
                {
                    if (item != null)
                    {
                        if (item.ToString().ToLower().Contains(textBox1.Text.ToLower())) return true;
                    }
                }
            }
            else
            {
                //There is a single column in the DataGrid
                if (value.ToString().ToLower().Contains(textBox1.Text.ToLower())) return true;
            }
            return false;
        }

        public void FilterIt()
        {
            int count = 0;
            DataTableFiltered.Clear();
            dataGrid1.ItemsSource = null;

            foreach (List<string> row in CollectionViewList)
            {
                DataTableFiltered.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
                count++;
            }

            dataGrid1.ItemsSource = DataTableFiltered.DefaultView;
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (CollectionViewList.CanFilter)
                {
                    CollectionViewList.Filter = new Predicate<object>(ContainsIt);

                    if (delayedAction == null)
                    {
                        delayedAction = DelayAction.Initialize(() => FilterIt());
                    }
                    delayedAction.Wait(filterDelay);                    
                }
                else
                {
                    CollectionViewList.Filter = null;
                }
            }
            else
            {
                CollectionViewList.Filter = null;
                FilterIt();
            }
        }

        public void SetStatusColumn()
        {
            DataGridTemplateColumn statusColumn = new DataGridTemplateColumn { CanUserReorder = false, Width = 85, CanUserSort = false }; ;
            statusColumn.Header = "Status";
            statusColumn.CellTemplateSelector = new DataTemplateSelectorBase();
            dataGrid1.Columns.Insert(0, statusColumn);
        }

    }
}
