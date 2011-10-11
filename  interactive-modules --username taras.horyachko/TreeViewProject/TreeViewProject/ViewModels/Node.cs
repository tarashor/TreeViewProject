using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml;

namespace TreeViewProject.ViewModels
{
    public class Node : ViewModelBase
    {
        private XmlNode _nodeXml;

        private XmlNode NodeXml
        {
            get { return _nodeXml; }
            set { _nodeXml = value; }
        }


        private string _data;
        private Node _parent;
        private ObservableCollection<Node> children;

        public string Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }

        public ObservableCollection<Node> Children
        {
            get { return children; }
            set
            {
                children = value;
                OnPropertyChanged("Children");
            }
        }

        public Node Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public Node(XmlNode nodeXml, string data, Node parent)
        {
            _nodeXml = nodeXml;
            _data = data;
            _parent = parent;
            children = new ObservableCollection<Node>();
        }

        public void AddChild(Node child)
        {
            children.Add(child);
            if (_nodeXml != null)
                _nodeXml.AppendChild(child._nodeXml);
        }

        public void RemoveChild(Node child)
        {
            children.Remove(child);
            if (_nodeXml != null)
                _nodeXml.RemoveChild(child._nodeXml);
        }

    }
}
