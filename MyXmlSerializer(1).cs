using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using С_1.Serializers;

namespace С_1.Serializers
{
    using People;
    public class MyXmlSerializer : MySerializer
    {
        public override void WriteGroups(Group[] groups, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                new XmlSerializer(typeof(Group[])).Serialize(fs, groups);
            }
        }
        public override Group[] ReadGroups(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return (Group[])new XmlSerializer(typeof(Group[])).Deserialize(fs);
            }
        }

    }
}
