namespace ConsoleApplication1
{
    using System.Collections.Generic;

    public interface IFurnitureCatalog
    {
        void AddItem(FurnitureItem item);
        void RemoveItem(FurnitureItem item);
        void AddItem(FurnitureItem[] items);
        void RemoveItem(FurnitureItem[] items);
        void DisplayCatalog();
    }

}
