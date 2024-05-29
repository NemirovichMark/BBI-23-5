namespace ConsoleApplication1
{
    using _10lab;
    using ConsoleApplication1;
    using System;
    using System.Security.Claims;
    using System.Xml.Serialization;

    class Program
    {
        public static void DisplayCatalog(FurnitureCatalog[] catalogs)
        {
            foreach (var catalog in catalogs)
            {
                catalog.DisplayCatalog();
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            FurnitureCatalog[] catalogs = new FurnitureCatalog[3];
            for (int i = 0; i < catalogs.Length; i++)
            {
                catalogs[i] = new FurnitureCatalog();
            }

            FurnitureItem[] items = new FurnitureItem[]
            {
            new Chair("Model1", "BrandA", true, true),
            new Chair("Model2", "BrandB", false, false),
            new Chair("Model3", "BrandC", true, true),
            new Chair("Model4", "BrandD", false, false),
            new Chair("Model5", "BrandE", true, true),
            new Chair("Model6", "BrandF", false, false),
            new Chair("Model7", "BrandG", true, true),
            new Chair("Model8", "BrandH", false, false),
            new Chair("Model9", "BrandI", true, true),
            new Chair("Model10", "BrandJ", false, false),
            new Table("Model1", "BrandA", 4, true),
            new Table("Model2", "BrandB", 3, false),
            new Table("Model3", "BrandC", 4, true),
            new Table("Model4", "BrandD", 5, false),
            new Table("Model5", "BrandE", 4, true),
            new Table("Model6", "BrandF", 6, false),
            new Table("Model7", "BrandG", 4, true),
            new Table("Model8", "BrandH", 3, false),
            new Table("Model9", "BrandI", 4, true),
            new Table("Model10", "BrandJ", 5, false),
            new Sofa("Model1", "BrandA", true, true),
            new Sofa("Model2", "BrandB", false, false),
            new Sofa("Model3", "BrandC", true, true),
            new Sofa("Model4", "BrandD", false, false),
            new Sofa("Model5", "BrandE", true, true),
            new Sofa("Model6", "BrandF", false, false),
            new Sofa("Model7", "BrandG", true, true),
            new Sofa("Model8", "BrandH", false, false),
            new Sofa("Model9", "BrandI", true, true),
            new Sofa("Model10", "BrandJ", false, false),
            new Bed("Model1", "BrandA", true, true),
            new Bed("Model2", "BrandB", true, false),
            new Bed("Model3", "BrandC", false, true),
            new Bed("Model4", "BrandD", true, false),
            new Bed("Model5", "BrandE", false, true),
            new Bed("Model6", "BrandF", false, false),
            new Bed("Model7", "BrandG", true, true),
            new Bed("Model8", "BrandH", false, false),
            new Bed("Model9", "BrandI", true, true),
            new Bed("Model10", "BrandJ", false, false),
            };

            for (int i = 0; i < 3; i++)
            {
                catalogs[i].AddItem(new FurnitureItem[] {
                items[0 + i * 10], items[1 + i * 10], items[2 + i * 10], items[3 + i * 10], items[4 + i * 10],
                items[5 + i * 10], items[6 + i * 10], items[7 + i * 10], items[8 + i * 10], items[9 + i * 10]
            });
            }

            foreach (var _catalog in catalogs)
            {
                _catalog.AddItem(new FurnitureItem[] {
                items[0], items[1], items[10], items[11], items[20], items[21], items[30], items[31]
            });
            }

            foreach (var _catalog in catalogs)
            {
                _catalog.AddItem(new FurnitureItem[] {
                items[2], items[12], items[22], items[32]
            });
            }

            foreach (var _catalog in catalogs)
            {
                _catalog.Sort();
            }

            Console.WriteLine("Sorted Catalogs:");
            DisplayCatalog(catalogs);

            for (int i = 0; i < catalogs.Length; i++)
            {
                string filename = $"catalog_{i + 1}.json";
                catalogs[i].SaveCatalogToJson(filename);
            }

            FurnitureCatalog loadedCatalog1 = new FurnitureCatalog();
            loadedCatalog1.LoadCatalogFromJson("catalog_1.json");

            Console.WriteLine("raw_data.json :");
            loadedCatalog1.DisplayCatalog();

            FurnitureCatalog loadedCatalog2 = new FurnitureCatalog();
            loadedCatalog2.LoadCatalogFromJson("catalog_2.json");

            Console.WriteLine("data.json:");
            loadedCatalog2.DisplayCatalog();

            FurnitureCatalog loadedCatalog3 = new FurnitureCatalog();
            loadedCatalog3.LoadCatalogFromJson("catalog_3.json");

            Console.WriteLine("sort_data.json:");
            loadedCatalog3.DisplayCatalog();
            Random rand = new Random();
            string[] models = { "Атланта", "Омега", "Рио", "Британика", "Токио", "Лира" };
            string[] brands = { "Икея", "ПинскДрев", "Askona", "Hoff" };
            string[] coating = { "Текстиль", "Кожа" };
            FurnitureCatalog catalog = new FurnitureCatalog();
            catalog.AddItem(new Chair(models[rand.Next(models.Length - 1)], brands[rand.Next(brands.Length - 1)], true, true));
            catalog.AddItem(new Table(models[rand.Next(models.Length - 1)], brands[rand.Next(brands.Length - 1)], 4, true));
            catalog.AddItem(new Sofa(models[rand.Next(models.Length - 1)], brands[rand.Next(brands.Length - 1)], true, true));
            catalog.AddItem(new Bed(models[rand.Next(models.Length - 1)], brands[rand.Next(brands.Length - 1)], true, true));

            for (int i = 0; i < 5; i++)
            {
                string coat = coating[rand.Next(coating.Length - 1)];
                catalog.AddItem(new Armchair(models[rand.Next(models.Length - 1)], brands[rand.Next(brands.Length - 1)], 3500, true, true, coating[0]));
                catalog.AddItem(new Stool(models[rand.Next(models.Length - 1)], brands[rand.Next(brands.Length - 1)], rand.Next(500) + 250));
            }
            MyXMLSerializer xml = new MyXMLSerializer();

            xml.Write(catalog, "raw_data.xml");
            FurnitureItem[] _items = xml.Read("raw_data.xml");
            FurnitureCatalog catalog_2 = new FurnitureCatalog();
            catalog_2.AddItem(_items);

            Console.WriteLine("\n============[XML]===========\n");
            catalog_2.DisplayCatalog();
            catalog_2.PrioritySort();

            xml.Write(catalog_2, "data.xml");
            items = xml.Read("data.xml");
            FurnitureCatalog catalog_3 = new FurnitureCatalog();
            catalog_3.AddItem(_items);
            Console.WriteLine("\n============[XML Priority Sort]===========\n");
            catalog_3.DisplayCatalog();
        }
    }

}