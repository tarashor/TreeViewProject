using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml;
using TreeViewProject.Utils;

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
        public string Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                if (_nodeXml != null)
                    XMLParser.SetAttribute(_nodeXml, XMLParser.XML_NODE_ATTRIBUTE_NAME, value);
                OnPropertyChanged("Data");
            }
        }

        private ObservableCollection<Node> children;
        public ObservableCollection<Node> Children
        {
            get { return children; }
            private set
            {
                children = value;
                OnPropertyChanged("Children");
            }
        }

        private Node _parent;
        public Node Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        private Node()
        {
            _nodeXml = null;
            _parent = null;
            _data = null;
            children = null;
        }

        public static Node ParseXmlNode(XmlNode xmlNode, Node parent)
        {
            Node node = new Node();
            node._nodeXml = xmlNode;
            node._data = XMLParser.GetAttributeValue(xmlNode, XMLParser.XML_NODE_ATTRIBUTE_NAME).ToString();
            node.Parent = parent;
            node.Children = new ObservableCollection<Node>();
            if (xmlNode.HasChildNodes)
            {
                foreach(XmlNode xmlChild in xmlNode.ChildNodes)
                {
                    Node child = ParseXmlNode(xmlChild, node);
                    node.Children.Add(child);
                }
            }
            return node;
        }


        public void AddChild(Node child)
        {
            children.Add(child);
            _parent = this;
            if (_nodeXml != null)
                XMLParser.AddChild(this._nodeXml, child._nodeXml);
        }

        public Node AddChild(string attributeValue)
        {
            Node node = new Node();
            XmlNode xmlNode = XMLParser.AddChild(_nodeXml, XMLParser.XML_NODE_NAME);
            node._nodeXml = xmlNode;
            node._data = attributeValue;
            node.children = new ObservableCollection<Node>();
            this.children.Add(node);
            node._parent = this;
            return node;
        }

        public void RemoveChild(Node child)
        {
            children.Remove(child);
            if (_nodeXml != null)
                XMLParser.RemoveChild(this._nodeXml, child._nodeXml);
        }

        public void Remove()
        {
            Parent.RemoveChild(this);
        }



    }
}
