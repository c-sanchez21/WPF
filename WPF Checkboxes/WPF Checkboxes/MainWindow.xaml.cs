using System;
using System.Collections.Generic;
using System.IO;
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
using System.ComponentModel;


namespace WPF_Checkboxes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyData Data { get; set; } = new MyData();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            Data.Dow = DayOfWeek.Everyday;
        }

        private void ShowVal_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Data.Dow.ToString());                     
        }
    }
}
