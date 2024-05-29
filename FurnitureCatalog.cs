namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;

    public partial class FurnitureCatalog : IFurnitureCatalog
    {
        public List<FurnitureItem> catalog { private set; get; }
        public FurnitureCatalog() {
            catalog = new List<FurnitureItem>();
        }
        public FurnitureCatalog(FurnitureItem[] items) { catalog = new List<FurnitureItem>(items); }

        public void AddItem(FurnitureItem item)
        {
            item.SetPrice();
            catalog.Add(item);
        }

        public void RemoveItem(FurnitureItem item)
        {
            catalog.Remove(item);
        }

        public void AddItem(FurnitureItem[] items)
        {
            foreach (var item in items)
            {
                item.SetPrice();
                catalog.Add(item);
            }
        }

        public void RemoveItem(FurnitureItem[] items)
        {
            foreach (var item in items)
            {
                catalog.Remove(item);
            }
        }

        public void DisplayCatalog()
        {
            foreach (var item in catalog)
            {
                Console.WriteLine(item);
            }
        }
    }

    public partial class FurnitureCatalog
    {
        public void Sort()
        {
            for (int i = 0; i < catalog.Count; i++)
            {
                var item = catalog[i];
                for (int j = i - 1; j >= 0;)
                {
                    if (item.price > catalog[j].price)
                    {
                        catalog[j + 1] = catalog[j];
                        catalog[j] = item;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private JsonSerializer jsonSerializer = new JsonSerializer();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public void SaveCatalogToJson(string filename)
        {
            string fullPath = Path.Combine(path, filename);
            jsonSerializer.SerializeToFile(this.catalog, fullPath);
        }

        public void LoadCatalogFromJson(string filename)
        {
            string fullPath = Path.Combine(path, filename);
            catalog = jsonSerializer.DeserializeFromFile<List<FurnitureItem>>(fullPath);
        }
    }
    public partial class FurnitureCatalog // Задание 1
    {
        public void PrioritySort()
        {
            for (int i = 0; i < catalog.Count; i++)
            {
                for (int j = i + 1; j < catalog.Count; j++)
                {
                    int flag_brand = String.Compare(catalog[i].brand, catalog[j].brand);
                    int flag_model = String.Compare(catalog[i].model, catalog[j].model);
                    if ((flag_brand == -1) || (flag_brand == 0) && (flag_model == -1))
                    {
                        FurnitureItem tmp = catalog[i];
                        catalog[i] = catalog[j];
                        catalog[j] = tmp;
                    }
                }
            }
        }
    }
}