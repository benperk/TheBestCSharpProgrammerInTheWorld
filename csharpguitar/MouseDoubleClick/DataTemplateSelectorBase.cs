using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace FilterWPF
{
    public class DataTemplateSelectorBase : DataTemplateSelector
    {
        protected MainWindow GetMainWindow(DependencyObject inContainer)
        {
            DependencyObject c = inContainer;
            while (true)
            {
                DependencyObject p = VisualTreeHelper.GetParent(c);

                if (c is MainWindow)
                {
                    return c as MainWindow;
                }
                else
                {
                    c = p;
                }
            }
        }

        public override DataTemplate SelectTemplate(object inItem, DependencyObject inContainer)
        {
            DataRowView row = inItem as DataRowView;

            if (row != null)
            {
                if (row.DataView.Table.Columns.Contains("Status"))
                {
                    MainWindow w = GetMainWindow(inContainer);
                    return (DataTemplate)w.FindResource("StatusImage");
                }
            }
            return null;
        }

    }
}
