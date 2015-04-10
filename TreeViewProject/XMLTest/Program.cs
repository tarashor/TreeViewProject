using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeViewProject.Utils;
using System.Xml;

namespace XMLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = XMLParser.LoadXml(XMLParser.XML_DATA_FILE_NAME);

        }
    }
}
