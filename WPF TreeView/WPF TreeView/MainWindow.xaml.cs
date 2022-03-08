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
        public MainWindow()
        {
            InitializeComponent();

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
            TreeViewItem newItem = new TreeViewItem();
            newItem.Header = txtItem.Text;
            tvFoods.Items.Add(newItem);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implement deletion of subItems
            tvFoods.Items.Remove(tvFoods.SelectedItem);
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
