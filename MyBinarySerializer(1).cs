using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using ProtoBuf;
using С_1.Serializers;

namespace С_1.Serializers
{
    using People;
    public class MyBinarySerializer : MySerializer
    {

        public override void WriteGroups(Group[] groups, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                Serializer.Serialize(fs, groups);
            }
        }
        public override Group[] ReadGroups(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return Serializer.Deserialize<Group[]>(fs);
            }
        }


    }
}
