using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPF_ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init(); //Initialize Listview - Add Items
        }

        public class Foo
        {
            public string Text { get; set; }
            public int Val { get; set; }
            public Foo() { }
            public Foo(string text, int val = 0)
            {
                this.Text = text;
                this.Val = val;
            }
            public override string ToString()
            {
                return string.Format("{0} ({1})", Text, Val);
            }
        }
        public void Init()
        {
            Random rand = new Random();
            int r;
            Foo f;
            List<Foo> myItems = new List<Foo>();
            for(int i =65; i <= 90; i++)//A-Z
            {
                r = rand.Next(-50, 51); //Get a random number [-50,50]
                f = new Foo(((char)i).ToString(), r); //Create a new instance of Foo
                myItems.Add(f); //Add Foo to list
            }
            myListView.Items.Clear(); //Item collection must be clear before using ItemSource;
            myListView.ItemsSource = myItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(myListView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Val", ListSortDirection.Ascending));
        }
    }
}