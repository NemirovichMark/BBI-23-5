using System;
using System.Net.Http.Json;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
// using Newtonsoft.Json;
// using ProtoBuf;

public class Program
{
    public class Crop
    {
        public string CropName { set; get; }
        public int Season { set; get; }
        public string Purpose { set; get; }

        // Конструктор
        [JsonConstructor]
        public Crop() { }
        public Crop(string name, int season, string purpose)
        {
            this.CropName = name;
            this.Season = season;
            this.Purpose = purpose;
        }

        public override string ToString()
        {
            return $"Название: {CropName}, выращен в {Season}, назначение: {Purpose}";
        }
    }

    public class HarvestStatisticXML
    {
        public Crop[] MyCrop { set; get; }
        public DateTime[] HarvestDate { set; get; }
        public double[] Quantity { set; get; }

        /*
        public HarvestStatisticXML() { }
        public HarvestStatisticXML(Crop[] crop, DateTime[] dt, double[] quantity)
        {
            this.MyCrop = crop;
            this.HarvestDate = dt;
            this.Quantity = quantity;
            this.size = Math.Min(Math.Min(MyCrop.Length, HarvestDate.Length), Quantity.Length);
        }
        */
    }

    abstract partial class HarvestStatistic
    {
        public Crop[] MyCrop { protected set; get; }
        public DateTime[] HarvestDate { protected set; get; }
        public double[] Quantity { protected set; get; }
        public int size { protected set; get; }

        // Конструктор
        [JsonConstructor]
        public HarvestStatistic(Crop[] crop, DateTime[] dt, double[] quantity)
        {
            this.MyCrop = crop;
            this.HarvestDate = dt;
            this.Quantity = quantity;
            this.size = Math.Min(Math.Min(MyCrop.Length, HarvestDate.Length), Quantity.Length);
        }

        public virtual void DisplayStatistic()
        {
            Console.WriteLine(this.ToString());
        }

        public double GetYieldByCrop(Crop crop)
        {
            double res = 0;
            for (int i = 0; i < size; i++)
            {
                if (MyCrop[i].CropName == crop.CropName)
                {
                    res += Quantity[i];
                }
            }
            return res;
        }

        public double GetYieldByCrop(string cropName)
        {
            double res = 0;
            for (int i = 0; i < size; i++)
            {
                if (MyCrop[i].CropName == cropName)
                {
                    res += Quantity[i];
                }
            }
            return res;
        }

        public override string ToString()
        {
            string res = "Статистика по урожаю:\n";
            for (int i = 0; i < size; i++)
            {
                res = MyCrop[i].ToString() + "\n";
                res += $"Дата урожая: {HarvestDate[i]}, Количество: {Quantity[i]}кг.\n\n";
            }
            return res;
        }
    }

    [Serializable]
    class CropHarvest : HarvestStatistic
    {
        public double pricePerOne { private set; get; }

        [JsonConstructor]
        public CropHarvest(Crop[] crop, DateTime[] dt, double[] quantity, double pricePerOne = 1) : base(crop, dt, quantity)
        {
            this.pricePerOne = pricePerOne;
        }
        public override void DisplayStatistic()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            string res = "Статистика по собранному урожаю:\n";
            for (int i = 0; i < size; i++)
            {
                res += MyCrop[i].ToString() + "\n";
                res += $"Дата урожая: {HarvestDate[i]}, Количество: {Quantity[i]}кг., Цена: {Quantity[i] * pricePerOne}";
            }
            res += $"Общая сумма: {(GetYield() * pricePerOne).ToString()}";
            return res;
        }
    }

    [Serializable]
    class CropYield : HarvestStatistic
    {
        public CropYield(Crop[] crop, DateTime[] dt, double[] quantity) : base(crop, dt, quantity)
        {
        }
        public override void DisplayStatistic()
        {
            Console.WriteLine("Здесь будет текст");
        }
    }

    interface IHarvestCalculator
    {
        public double GetYield();
        public double GetYieldPerDay();
        public double GetAvgYield();
        public double GetAllYield();
    }

    abstract partial class HarvestStatistic : IHarvestCalculator
    {
        public double GetAllYield()
        {
            double res = 0;
            for (int i = 0; i < size; i++)
            {
                res += Quantity[i];
            }
            return res;
        }

        public double GetAvgYield()
        {
            DateTime firstDay = HarvestDate[0];
            DateTime lastDay = HarvestDate[^1];

            Console.WriteLine($"Самый первый день: {firstDay}");
            Console.WriteLine($"Самый последний день: {lastDay}");

            // Подсчитываем общее количество культур
            int totalQuantity = 0;
            foreach (double quantity in Quantity)
            {
                totalQuantity += Convert.ToInt32(quantity);
            }
            Console.WriteLine($"{totalQuantity} единиц собрано");

            return totalQuantity / HarvestDate.Length;
        }

        public double GetYield()
        {
            double res = 0;
            for (int i = 0; i < size; i++)
            {
                res += Quantity[i];
            }
            return res;
        }

        public double GetYieldPerDay()
        {
            DateTime firstDay = HarvestDate[0];
            DateTime lastDay = HarvestDate[^1];

            Console.WriteLine($"Самый первый день: {firstDay}");
            Console.WriteLine($"Самый последний день: {lastDay}");

            // Подсчитываем общее количество культур
            int totalQuantity = 0;
            foreach (double quantity in Quantity)
            {
                totalQuantity += Convert.ToInt32(quantity);
            }
            Console.WriteLine($"{totalQuantity} единиц собрано");

            return totalQuantity / (lastDay - firstDay).Days;
        }
    }

    abstract class MySerializer
    {
        public abstract HarvestStatistic Read(string filename);
        public abstract void Write(HarvestStatistic harvestStatistics, string filename);
    }

    class MyXMLSerializer : MySerializer
    {
        public override HarvestStatistic Read(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HarvestStatisticXML));

            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                HarvestStatisticXML xml = (HarvestStatisticXML)serializer.Deserialize(fileStream);
                CropHarvest hs = new CropHarvest(xml.MyCrop, xml.HarvestDate, xml.Quantity);
                return hs;
            }
        }

        public override void Write(HarvestStatistic harvestStatistics, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HarvestStatisticXML));

            HarvestStatisticXML xml_hs = new HarvestStatisticXML 
            {
                MyCrop = harvestStatistics.MyCrop,
                HarvestDate =  harvestStatistics.HarvestDate,
                Quantity = harvestStatistics.Quantity
            };

            using (FileStream fileStream = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(fileStream, xml_hs);
            }
        }
    }


    static void Main(string[] args)
    {
        Crop[] crops = {
                new Crop("Кукуруза", 9, "Еда"),
                new Crop("Картофель", 9, "Еда"),
                new Crop("Морковь", 10, "Еда"),
                new Crop("Свёкла", 11, "Еда"),
                new Crop("Капуста", 12, "Еда"),
                new Crop("Огурцы", 1, "Еда"),
                new Crop("Помидоры", 2, "Еда"),
                new Crop("Клубника", 3, "Еда и напитки"),
                new Crop("Малина", 4, "Еда и напитки"),
                new Crop("Яблоко", 5, "Еда")
            };

        DateTime[] dt =
        {
            new DateTime(2024, 6, 10),
            new DateTime(2024, 7, 10),
            new DateTime(2024, 8, 10),
            new DateTime(2024, 9, 10),
            new DateTime(2024, 10, 10),
            new DateTime(2024, 10, 11),
            new DateTime(2024, 10, 12),
            new DateTime(2024, 10, 13),
            new DateTime(2024, 10, 14),
            new DateTime(2024, 10, 15),
        };
        double[] q = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        CropHarvest ch = new CropHarvest(crops, dt, q);

        ch.DisplayStatistic();
        Console.WriteLine($"Цена всего урожая: {ch.GetAllYield()}");

        MyXMLSerializer xml = new MyXMLSerializer();
        xml.Write(ch, "raw_data.xml");
        HarvestStatistic raw_hs = xml.Read("raw_data.xml");
        raw_hs.DisplayStatistic();
    }
}
