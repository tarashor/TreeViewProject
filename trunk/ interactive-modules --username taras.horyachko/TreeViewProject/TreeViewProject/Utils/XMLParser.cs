using System.Xml;

namespace TreeViewProject.Utils
{
    public class XMLParser
    {
        public const string XML_DATA_FILE_NAME = "data.xml";

        public const string XML_NODE_ATTRIBUTE_NAME = "data";
        public const string XML_TREE_ATTRIBUTE_NAME = "name";
        public const string XML_TREE_ATTRIBUTE_NODES_COUNT = "nodescount";
        public const string XML_NODE_NAME = "node";
        public const string XML_TREE_NAME = "tree";

        public static void SaveXml(XmlDocument xmlDocument, string filename)
        {
            xmlDocument.Save(filename);
        }

        public static XmlDocument LoadXml(string filename)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);
            return xmlDocument;
        }

        public static object GetAttributeValue(XmlNode node, string attributeName)
        {
            return node.Attributes[attributeName].Value;
        }

        public static XmlNode SetAttribute(XmlNode node, string attributeName, string attributeValue)
        {
            XmlNode attribute = node.OwnerDocument.CreateNode(XmlNodeType.Attribute, attributeName, "");
            attribute.Value = attributeValue;
            node.Attributes.SetNamedItem(attribute);
            return node;
        }

        public static XmlNodeList GetChildren(XmlNode node)
        {
            return node.ChildNodes;
        }

        public static void AddChild(XmlNode parent, XmlNode child)
        {
            parent.AppendChild(child);
        }

        public static void RemoveChild(XmlNode parent, XmlNode child)
        {
            parent.RemoveChild(child);
        }

        public static XmlNode AddChild(XmlNode parent, string nodeName)
        {
            XmlNode child = parent.OwnerDocument.CreateNode(XmlNodeType.Element, nodeName, "");
            AddChild(parent, child);
            return child;
        }

    }
}