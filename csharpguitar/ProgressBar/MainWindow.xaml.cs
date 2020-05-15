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

using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace ProgressBar
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            buttonStart.IsEnabled = false;
            int SecondsToComplete = 30; //Program specific value

            System.Windows.Controls.ProgressBar progress = new System.Windows.Controls.ProgressBar();
            progress.IsIndeterminate = false;
            progress.Orientation = System.Windows.Controls.Orientation.Horizontal;
            progress.Width = 419;
            progress.Height = 20;

            Duration duration = new Duration(TimeSpan.FromSeconds((SecondsToComplete * 1.35)));
            DoubleAnimation doubleAnimatiion = new DoubleAnimation(200, duration);
            StatusBar1.Items.Add(progress);

            try
            {
                TaskScheduler uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                Action MainThreadDoWork = new Action(() =>
                {
                    //add thread safe code here.
                    //Confirm thread will not use GUI thread
                    System.Threading.Thread.Sleep(20000);
                });

                Action ExecuteProgressBar = new Action(() =>
                {
                    progress.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, doubleAnimatiion);
                });

                Action FinalThreadDoWOrk = new Action(() =>
                {
                    buttonStart.IsEnabled = true;
                    StatusBar1.Items.Remove(progress);
                });

                Task MainThreadDoWorkTask = Task.Factory.StartNew(() => MainThreadDoWork());

                Task ExecuteProgressBarTask = new Task(ExecuteProgressBar);
                ExecuteProgressBarTask.RunSynchronously();

                MainThreadDoWorkTask.ContinueWith(t => FinalThreadDoWOrk(), uiThread);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
