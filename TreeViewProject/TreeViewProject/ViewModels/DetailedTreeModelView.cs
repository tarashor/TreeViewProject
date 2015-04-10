using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace TreeViewProject.ViewModels
{
    public class DetailedTreeModelView:DetailedViewModelBase
    {
        private Tree _tree = null;

        private const string RootProperty = "Root";
        private ObservableCollection<Node> _roots;
        public ObservableCollection<Node> Roots 
        {
            get
            {
                if (_roots == null)
                {
                    _roots = new ObservableCollection<Node>();
                    _roots.Add(_tree.Root);
                }
                return _roots;
            }
        }

        public DetailedTreeModelView(Tree tree)
        {
            _tree = tree;
            Title = tree.Name;
        }

    }
}
