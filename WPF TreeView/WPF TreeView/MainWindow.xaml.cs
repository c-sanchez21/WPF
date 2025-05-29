using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml.Linq;

namespace WPF_TreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Family> families;
        ObservableCollection<Node> nodes;
        Dictionary<string, Node> nodeMap = new Dictionary<string, Node>();
        public ObservableCollection<Node> Example3Nodes { get; set; } = new ObservableCollection<Node>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            nodes = new ObservableCollection<Node>();
            Node foods = new Node() { Header = "Foods" };
            foods.SubNodes.Add(new Node() { Header = "Lasanga" });
            foods.SubNodes.Add(new Node() { Header = "Beef Bowl" });
            foods.SubNodes.Add(new Node() { Header = "Sushi" });
            nodes.Add(foods);
            tvFoods.Items.Clear();
            tvFoods.ItemsSource = nodes;

            families = new List<Family>();
            Family fam1 = new Family() { Name = "The Does" };
            Family fam2 = new Family() { Name = "The Smiths" };


            //Creates Families for TreeView Example
            Random r = new Random();
            fam1.Members.Add(new FamilyMember() { Name = "John Doe", Age = r.Next(18, 100) });
            fam1.Members.Add(new FamilyMember() { Name = "Jane Doe", Age = r.Next(18, 100) });

            fam2.Members.Add(new FamilyMember() { Name = "James", Age = r.Next(18, 100) });
            fam2.Members.Add(new FamilyMember() { Name = "Mary", Age = r.Next(18, 100) });

            families.Add(fam1);
            families.Add(fam2);

            tvFamilies.ItemsSource = families;

            PopulateExample3();
        }

        private void PopulateExample3()
        {
            Node n = new Node() { Header = "0" };
            nodeMap.Add(n.Header, n);
            Example3Nodes.Add(n);
            for (int i = 1; i <= 10; i++)
            {
                n.SubNodes.Add(new Node() { Header = i.ToString() });
                n = n.SubNodes[0];
                nodeMap.Add(n.Header, n);
            }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtItem.Text))
            {
                MessageBox.Show("Node Name should not be blank", "Error");
                return;
            }

            if (tvFoods.SelectedItem == null)
            {
                nodes.Add(new Node() { Header = txtItem.Text });
                return;
            }

            Node n = tvFoods.SelectedItem as Node;
            if (n == null) return;
            n.SubNodes.Add(new Node() { Header = txtItem.Text });
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Node p = SelectedItemParent.DataContext as Node;
            Node n = tvFoods.SelectedItem as Node;
            if (p == null)
                nodes.Remove(n);
            else p.SubNodes.Remove(n);
        }

        private ItemsControl SelectedItemParent = null;
        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            if (item == null) return;
            ItemsControl parent = ItemsControl.ItemsControlFromItemContainer(item);
            SelectedItemParent = parent;
        }

        private void Button_FindItemClick(object sender, RoutedEventArgs e)
        {   
            string searchStr = tbSearchBox.Text;
            if (!nodeMap.ContainsKey(searchStr))
            {
                MessageBox.Show($"Node node found: {searchStr}");
                return;
            }
            
            //Forces the Tree to be created (instead of virtual)
            ExpandAll(tvNumbers);
            CollapseAll(tvNumbers);

            Node n = nodeMap[searchStr];            
            TreeViewItem tvNode = GetTreeViewItem(tvNumbers, n);
            if (tvNode == null)
            {
                MessageBox.Show($"Node node found: {searchStr}");
                return;
            }
            tvNode.IsSelected = true;
            tvNode.IsExpanded = false;
            tvNode.BringIntoView();
        }

        private TreeViewItem GetTreeViewItem(ItemsControl container, object item)
        {
            if (container == null) return null;
            if (container.DataContext == item)
                return container as TreeViewItem;

            // Expand the current container
            if (container is TreeViewItem && !((TreeViewItem)container).IsExpanded)
                container.SetValue(TreeViewItem.IsExpandedProperty, true);

            // Try to generate the ItemsPresenter and the ItemsPanel.
            // by calling ApplyTemplate.  Note that in the
            // virtualizing case even if the item is marked
            // expanded we still need to do this step in order to
            // regenerate the visuals because they may have been virtualized away.
            container.ApplyTemplate();
            ItemsPresenter itemsPresenter =
                (ItemsPresenter)container.Template.FindName("ItemsHost", container);
            if (itemsPresenter != null)
            {
                itemsPresenter.ApplyTemplate();
            }            


            for (int i = 0, count = container.Items.Count; i < count; i++)
            {
                TreeViewItem subContainer = container.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                if (subContainer == null) continue;
                //subContainer.IsExpanded = true;
                subContainer.BringIntoView();

                //Recurses through the nodes                
                TreeViewItem resultContinaer = GetTreeViewItem(subContainer, item);
                if (resultContinaer != null)
                    return resultContinaer;
                //else subContainer.IsExpanded = false;
            }
            return null;
        }

        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            item.IsExpanded = true;
            item.IsSelected = true;         
        }

        private void Button_ClickExpandAll(object sender, RoutedEventArgs e)
        {
            ExpandAll(tvNumbers);            
        }

        private void ExpandAll(TreeView tv)
        {
            foreach (object o in tv.Items)
                if (tv.ItemContainerGenerator.ContainerFromItem(o) is TreeViewItem tvItem)
                    tvItem.ExpandSubtree();
        }

        private void CollapseAll(TreeView tv)
        {
            foreach(object o in tv.Items)
                if(tv.ItemContainerGenerator.ContainerFromItem(o) is TreeViewItem sub)
                    sub.IsExpanded = false; ;
        }
    }
    public class Family
    {
        public Family()
        {
            this.Members = new ObservableCollection<FamilyMember>();
        }

        #region Properties
        public ObservableCollection<FamilyMember> Members { get; set; }
        public string Name { get; set; }
        #endregion
    }

    public class FamilyMember
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
