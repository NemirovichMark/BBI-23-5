using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;


namespace С_1.Serializers
{
    using People;
    public class MyJsonSerializer : MySerializer
    {


        public override Group[] ReadGroups(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<Group[]>(fs);
            }
        }


        public override void WriteGroups(Group[] groups, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(fs, groups);
            }
        }


    }
}
