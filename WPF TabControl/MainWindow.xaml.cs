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

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            ListView lv = sender as ListView;
            if(lv == null) return;
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(lv, lv.SelectedItems, DragDropEffects.Copy);
            }
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            ListView lv = sender as ListView;
            if(lv == null) return;
        }
    }
}