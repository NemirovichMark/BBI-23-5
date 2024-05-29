using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _10lab
{
    abstract class MySerializer
    {
        public abstract FurnitureItem[] Read(string filename);
        public abstract void Write(FurnitureCatalog furnitureCatalog, string filename);
    }
    class MyXMLSerializer : MySerializer
    {
        public override FurnitureItem[] Read(string filename)
        {
            string res;
            List<FurnitureItem> arr = new List<FurnitureItem>();

            using (FileStream fstream = new FileStream(filename, FileMode.Open))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                res = Encoding.UTF8.GetString(buffer);
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(res.Replace("&", ""));

            var manager = doc.DocumentElement.ChildNodes;
            foreach (XmlNode node in manager)
            {
                FurnitureItem instance = null;
                string typeName = node.ChildNodes.Item(0).InnerText;
                string model = node.ChildNodes.Item(1).InnerText;
                string brand = node.ChildNodes.Item(2).InnerText;
                string price_str = node.ChildNodes.Item(3).InnerText;
                double price = Convert.ToDouble(price_str);
                if ((typeName.Contains("Chair")) || (typeName.Contains("Armchair")) || (typeName.Contains("Stool")))
                {
                    string hasBack = node.ChildNodes.Item(4).InnerText;
                    string hasWheels = node.ChildNodes.Item(5).InnerText;
                    bool hb = (hasBack == "True");
                    bool hw = (hasWheels == "True");
                    if (typeName.Contains("Armchair"))
                    {
                        string coating = node.ChildNodes.Item(6).InnerText;
                        instance = new Armchair(model, brand, price, hb, hw, coating);
                    }
                    else if (typeName.Contains("Stool"))
                    {
                        instance = new Stool(model, brand, price);
                    }
                    else
                    {
                        instance = new Chair(model, brand, hb, hw);
                    }
                }
                else if (typeName.Contains("Table"))
                {
                    string numOfPlaces_str = node.ChildNodes.Item(4).InnerText;
                    string foldable_str = node.ChildNodes.Item(5).InnerText;
                    int num = Convert.ToInt32(numOfPlaces_str);
                    bool foldable = (foldable_str == "True");
                    instance = new Table(model, brand, num, foldable);
                }
                else if (typeName.Contains("Sofa"))
                {
                    string angular_str = node.ChildNodes.Item(4).InnerText;
                    string foldable_str = node.ChildNodes.Item(5).InnerText;
                    bool angular = (angular_str == "True");
                    bool foldable = (foldable_str == "True");
                    instance = new Sofa(model, brand, angular, foldable);
                }
                else if (typeName.Contains("Bed"))
                {
                    string size_str = node.ChildNodes.Item(4).InnerText;
                    string bunkbed_str = node.ChildNodes.Item(5).InnerText;
                    bool size = (size_str == "True");
                    bool bunkbed = (bunkbed_str == "True");
                    instance = new Bed(model, brand, size, bunkbed);
                }
                arr.Add(instance);
            }
            return arr.ToArray();
        }

        public override void Write(FurnitureCatalog furnitureCatalog, string filename)
        {
            string res = "<Catalog>\n";
            for (int i = 0; i < furnitureCatalog.catalog.Count; i++)
            {
                res += "<Furniture>\n";
                res += $"<Type>{furnitureCatalog.catalog[i].GetType().ToString()}</Type>";
                res += furnitureCatalog.catalog[i].ToXML();
                res += "</Furniture>\n";
            }
            res += "</Catalog>\n";
            using (FileStream fstream = new FileStream(filename, FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(res);
                fstream.Write(buffer);
            }
            Console.WriteLine("XML записан!");
        }
    }

    public class FurnitureItemXML
    {
        public string Model;
        public string Brand;
        public double Price;
    }
}
