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
        private GridViewColumnHeader lvSortCol = null;
        private SortAdorner lvSortAdorner = null;
        public MainWindow()
        {
            InitializeComponent();
            Init(); //Initialize Listview - Add Items
            //CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(myListView.ItemsSource);
            //cv.SortDescriptions.Add(new SortDescription("Val", ListSortDirection.Ascending));
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

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader col = (sender as GridViewColumnHeader);
            string sortPropery = col.Tag.ToString();
            if (lvSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(lvSortCol).Remove(lvSortAdorner);
                myListView.Items.SortDescriptions.Clear();
            }

            ListSortDirection sortDir = ListSortDirection.Ascending;
            if((col == lvSortCol) && (lvSortAdorner.Direction == sortDir))
                sortDir = ListSortDirection.Descending;

            lvSortCol = col;
            lvSortAdorner = new SortAdorner(lvSortCol, sortDir);

            AdornerLayer.GetAdornerLayer(lvSortCol).Add(lvSortAdorner);
            myListView.Items.SortDescriptions.Add(new SortDescription(sortPropery, sortDir));
        }

        public class SortAdorner : Adorner
        {
            private static Geometry ascGeometry =
                Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                : base(element)
            {
                this.Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                    (
                        AdornedElement.RenderSize.Width - 15,
                        (AdornedElement.RenderSize.Height - 5) / 2
                    );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }
    }
}