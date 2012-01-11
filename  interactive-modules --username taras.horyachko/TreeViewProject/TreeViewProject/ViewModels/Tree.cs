using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using TreeViewProject.Utils;
using System.Collections.ObjectModel;

namespace TreeViewProject.ViewModels
{
    public class Tree : ViewModelBase
    {
        private XmlNode _nodeXml;
        private XmlNode NodeXml
        {
            get { return _nodeXml; }
            set { _nodeXml = value; }
        }

        private Node _root;
        public Node Root
        {
            get { return _root; }
            set 
            { 
                _root = value;
                OnPropertyChanged("Root");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                if (_nodeXml != null)
                    XMLParser.SetAttribute(_nodeXml, XMLParser.XML_TREE_ATTRIBUTE_NAME, value);
                OnPropertyChanged("Name");
            }
        }
        
        private int _nodesCount;
        public int NodesCount
        {
            get { return _nodesCount; }
            private set 
            { 
                _nodesCount = value;
                if (_nodeXml != null)
                    XMLParser.SetAttribute(_nodeXml, XMLParser.XML_TREE_ATTRIBUTE_NODES_COUNT, value.ToString());
                OnPropertyChanged("NodesCount");
            }
        }

        private Tree() 
        {
            _root = null;
            _nodesCount = 0;
            _name = null;
            _nodeXml = null;
        }

        public static Tree ParseTree(XmlNode root)
        {
            Tree tree = new Tree();
            tree._name = XMLParser.GetAttributeValue(root, XMLParser.XML_TREE_ATTRIBUTE_NAME).ToString();
            string nodesCount = XMLParser.GetAttributeValue(root, XMLParser.XML_TREE_ATTRIBUTE_NODES_COUNT).ToString();
            int.TryParse(nodesCount, out tree._nodesCount);
            tree._root=Node.ParseXmlNode(root.FirstChild, null);
            tree._nodeXml = root;
            return tree;
        }

        public static Tree CreateTree(XmlNode trees)
        {
            Tree tree = new Tree();
            XmlNode xmltree = XMLParser.AddChild(trees, XMLParser.XML_TREE_NAME);
            tree._nodeXml = xmltree;
            return tree;
        }

        public static void DeleteTree(XmlNode trees, Tree tree)
        {
            XMLParser.RemoveChild(trees, tree.NodeXml);
        }
    }
}
