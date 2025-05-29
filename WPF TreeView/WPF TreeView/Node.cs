using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TreeView
{
    public class Node
    {
        public string Header { get; set; }

        public ObservableCollection<Node> SubNodes { get; set; } = new ObservableCollection<Node>();
    }
}
