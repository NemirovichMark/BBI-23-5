namespace App
{
    public interface IOrder
    {
        void Add(Menu item);
        void Add(Menu item, int quantity);
        void Remove(Menu item);
        void Remove(Menu item, int quantity);
    }
    public interface IPayable
    {
        void Pay(List<Menu> menuItems);
    }
}
