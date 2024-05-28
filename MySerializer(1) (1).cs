using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace С_1.Serializers
{
    using People;
    public abstract class MySerializer
    {

        public abstract void WriteGroups(Group[] groups, string filePath);
        public abstract Group[] ReadGroups(string filePath);

    }
    public abstract class Serial
    {
        public abstract void Write<T>(T obj, string filePath);
        public abstract T Read<T>(string filePath);
    }
}
