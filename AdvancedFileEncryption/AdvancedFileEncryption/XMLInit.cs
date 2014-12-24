using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdvancedFileEncryption
{
    class XMLInit
    {
        static string FileName = "UserAccount.xml";

        public string GetFileName()
        {
            return FileName;
        }

        public XmlDocument ReadXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FileName);

            return doc;
        }
    }
}
