using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_TreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Family> families;
        ObservableCollection<Node> nodes; 
        public MainWindow()
        {
            InitializeComponent();

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

            Random r = new Random();
            fam1.Members.Add(new FamilyMember() { Name = "John Doe", Age = r.Next(18, 100) });
            fam1.Members.Add(new FamilyMember() { Name = "Jane Doe", Age = r.Next(18, 100) });

            fam2.Members.Add(new FamilyMember() { Name = "James", Age = r.Next(18, 100) });
            fam2.Members.Add(new FamilyMember() { Name = "Mary", Age = r.Next(18, 100) });

            families.Add(fam1);
            families.Add(fam2);

            tvFamilies.ItemsSource = families;
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(tvFoods.SelectedItem == null)
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
            //TODO: Implement deletion of subItems
            Node n = tvFoods.SelectedItem as Node;
            if (n == null) return;
            nodes.Remove(n);

            //tvFoods.Items.Remove(tvFoods.SelectedItem);
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

    public class Node
    {
        public string Header { get; set; }

        public ObservableCollection<Node> SubNodes { get; set; } = new ObservableCollection<Node>();
        //public List<Node> SubNodes { get; set; } = new List<Node>();
    }
}
