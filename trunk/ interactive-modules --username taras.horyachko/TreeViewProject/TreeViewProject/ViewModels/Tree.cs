using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TreeViewProject.ViewModels
{
    public class Tree : ViewModelBase
    {
        private const string nameAttribute = "name";
        private const string nodesCountAttribute = "nodescount";

        private Node _root;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
            OnPropertyChanged("Name");
            }
        }
        private int _nodesCount;

        public int NodesCount
        {
            get { return _nodesCount; }
            set { _nodesCount = value;
            OnPropertyChanged("NodesCount");
            }
        }
        private XmlDocument _xmlDocument;

        //_xmlDocument.SelectSingleNode(string.Format("tree[@name='{0}']"

        public Tree(XmlDocument xmlDocument, XmlNode root)
        {
            _xmlDocument = xmlDocument;
            _name = root.Attributes[nameAttribute].Value;
            _nodesCount = int.Parse(root.Attributes[nodesCountAttribute].Value);
            _root = CreateSubTreeFromXML(root.SelectSingleNode("node"), null);
        }


        private Node CreateSubTreeFromXML(XmlNode xmlNode, Node parent)
        {
            string data = xmlNode.Attributes["data"].Value;
            Node root = new Node(xmlNode, data, parent);
            if (xmlNode.HasChildNodes)
            {
                foreach (XmlNode childXml in xmlNode.ChildNodes)
                {
                    Node child = CreateSubTreeFromXML(childXml, root);
                    root.Children.Add(child);
                }
            }
            return root;
        }

        public void CreateNode(Node parent, string data)
        {
            XmlNode childXml = _xmlDocument.CreateNode("element", "node", "");
            XmlNode attr = _xmlDocument.CreateNode(XmlNodeType.Attribute, "data", "");
            attr.Value = data;
            childXml.Attributes.SetNamedItem(attr);
            Node child = new Node(childXml, data, parent);
            parent.AddChild(child);
        }

        public void DeleteNode(Node node)
        {
            node.Parent.RemoveChild(node);
        }
    }
}
