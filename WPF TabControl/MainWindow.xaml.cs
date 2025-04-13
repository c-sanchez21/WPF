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
using System.Xml.Linq;

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
                DragDrop.DoDragDrop(lv, lv.SelectedItem, DragDropEffects.Move);                                
                /*
                To specify that an element is a drop target, you set its AllowDrop property to true.
                During a drag - and - drop operation, the following sequence of events occurs on the drop target:
                1. DragEnter
                2. DragOver
                3. DragLeave or Drop
                */
            }
        }

        /*
         * The DragEnter event occurs when the data is dragged into the drop target's boundary. 
         * You typically handle this event to provide a preview of the effects of the drag-and-drop operation, 
         * if appropriate for your application. 
         * Do not set the DragEventArgs.Effects property in the DragEnter event, 
         * as it will be overwritten in the DragOver event.
         */        
        private void ListView_DragEnter(object sender, DragEventArgs e)
        {            
            ListView lv = sender as ListView;
            if(lv == null) return;            
        }

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            string[] formats = e.Data.GetFormats();
            bool isListViewItem = e.Data.GetDataPresent("System.Windows.Controls.ListViewItem");
            if (isListViewItem)
                e.Effects = DragDropEffects.Move;
            else e.Effects = DragDropEffects.None;                            
        }
    }
}