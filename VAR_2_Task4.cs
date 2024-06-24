using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Variant_2.Task3;
#region Выберите библиотеку(и) для сериализации
// using Newtonsoft;
//using System.Text.Json;
using System.Text.Json.Serialization;
#endregion
namespace Variant_2
{
    public class Task4
    {
        public interface IDataSerializer
        {
            void Write(object obj, string path);
            object Read(string path);
        }

        public interface ICreator
        {
            void CreateFolder(string path, string folderName);
            void CreateFile(string path, string fileName);
            void CreateFolders(string path, string[] folderNames);
            void CreateFiles(string path, string[] fileNames);
        }

        public class DataSerializer : IDataSerializer, ICreator
        {
            private Grep grepInstance;

            public DataSerializer(Grep grepInstance)
            {
                this.grepInstance = grepInstance;
            }

            public void Write(object obj, string path)
            {
                throw new NotImplementedException();
            }

            public object Read(string path)
            {
                throw new NotImplementedException();
            }

            public void CreateFolder(string path, string folderName)
            {
                throw new NotImplementedException();
            }

            public void CreateFile(string path, string fileName)
            {
                throw new NotImplementedException();
            }

            public void CreateFolders(string path, string[] folderNames)
            {
                throw new NotImplementedException();
            }

            public void CreateFiles(string path, string[] fileNames)
            {
                throw new NotImplementedException();
            }
        }


    }
}
