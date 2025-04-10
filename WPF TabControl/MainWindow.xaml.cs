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

namespace TabControl
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
        private void MenuItem_ClickClose(object sender, RoutedEventArgs e)
        {            
            MenuItem menuItem = sender as MenuItem;
            if (menuItem == null) return;
            ContextMenu cm = menuItem.Parent as ContextMenu;            
            if (cm == null) return;
            TabItem item = cm.PlacementTarget as TabItem;
            if (item == null) return;            
            zTabControl.Items.Remove(item);
        }
    }
}