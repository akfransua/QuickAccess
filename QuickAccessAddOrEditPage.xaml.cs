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
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace QuickAccess
{
    /// <summary>
    /// Interaction logic for QuickAccessAddOrEditPage.xaml
    /// </summary>
    public partial class QuickAccessAddOrEditPage : Page
    {
        private ListBox listBox1;

        public QuickAccessAddOrEditPage()
        {
            InitializeComponent();
        }


        // Custom constructor to pass expense report data
        public QuickAccessAddOrEditPage(ListBox data) : this()
        {
            // Bind to expense report data.
            this.listBox1 = data;
        }
        private void addPathButton(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(string.Format("{0} Directory name canno be empty  or is null", textBox1.Text));
            listBox1.Items.Add(textBox1.Text);
        }
    }
}
