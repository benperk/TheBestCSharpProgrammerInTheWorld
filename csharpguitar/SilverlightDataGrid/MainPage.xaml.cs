using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightApplication2
{
    public class Company
    {
        public String Name { get; set; }
        public String Size { get; set; }
        public String Address { get; set; }
        public String Industry { get; set; }
        public Boolean? IsMajor { get; set; }
        public Boolean IsBuying { get; set; }

        public Company(String name, String size, String address,
            String industry, Boolean? isMajor, Boolean isBuying)
        {
            this.Name = name;
            this.Size = size;
            this.Address = address;
            this.Industry = industry;
            this.IsMajor = isMajor;
            this.IsBuying = isBuying;
        }

        public static List<Company> GetCompanyList()
        {
            return new List<Company>(new Company[5] {
                new Company("Company 1", "< 100", 
                    "Company 1 Street", "Software", false, true), 
                new Company("Company 2", "> 1000", 
                    "Company 2 Avenue", "Automotive", false, false),
                new Company("Company 3", "< 100 > 50", 
                    "Company 3 Boulevard", "IT Services", null, false),
                new Company("Company 4", "> 20000", 
                    "Company 4 Parkway", "Transportation", true, true),
                new Company("Company 5", "<10", 
                    "Company 5 Place", "Entertainment", true, true)
            });
        }
    }

    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            DataGrid dataGrid = ((DataGrid)(this.FindName("dataGrid")));
            dataGrid.ItemsSource = Company.GetCompanyList();
        }
    }
}
