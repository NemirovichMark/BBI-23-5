using System.Xml.Serialization;

namespace App
{
    [Serializable]
    [XmlRoot("Order")]
    public class Order : IOrder
    {
        [XmlIgnore]
        private List<MenuItemXml> items = new List<MenuItemXml>();

        [XmlIgnore]
        public List<MenuItemXml> Items
        {
            get => items;
            set => items = value;
        }

        [XmlElement("Items")]
        public MenuItemXml[] XmlItems
        {
            get => items.ToArray();
            set => items = new List<MenuItemXml>(value);
        }

        private double totalCost; // Стоимость заказа

        public double TotalCost
        {
            get => totalCost;
            set => totalCost = value;
        }

        public Order()
        {
            menuItems = new List<Menu>();
        }

        public class MenuItemXml
        {
            private string menuName;
            private int quantity;

            public string MenuName
            {
                get => menuName;
                set => menuName = value;
            }

            public int Quantity
            {
                get => quantity;
                set => quantity = value;
            }
        }

        public void Add(Menu item)
        {
            Add(item, 1);
        }

        public void Add(Menu item, int quantity)
        {
            string itemName = item.Name;
            MenuItemXml menuItem = null;
            foreach (var menu in items)
            {
                if (menu.MenuName == itemName)
                {
                    menuItem = menu;
                    break;
                }
            }

            if (menuItem == null)
            {
                items.Add(new MenuItemXml { MenuName = itemName, Quantity = quantity });
            }
            else
            {
                menuItem.Quantity += quantity;
            }
        }

        public void Remove(Menu item)
        {
            Remove(item, items.Find(i => i.MenuName == item.Name)?.Quantity ?? 0);
        }

        public void Remove(Menu item, int quantity)
        {
            string itemName = item.Name;
            MenuItemXml menuItem = null;
            foreach (var menu in items)
            {
                if (menu.MenuName == itemName)
                {
                    menuItem = menu;
                    break;
                }
            }

            if (menuItem != null)
            {
                int itemQuantity = GetItemQuantity(item);
                if (itemQuantity <= quantity)
                {
                    items.Remove(menuItem);
                }
                else
                {
                    menuItem.Quantity -= quantity;
                }
            }
        }

        private int GetItemQuantity(Menu item)
        {
            string itemName = item.Name;
            foreach (var menu in items)
            {
                if (menu.MenuName == itemName)
                {
                    return menu.Quantity;
                }
            }
            return 0;
        }
        public Order(List<Menu> menuItems)
        {
            this.menuItems = menuItems ?? new List<Menu>(); // Инициализация списком или пустым списком

        }


        public double MakeOrder(List<Menu> menuItems)
        {
            totalCost = 0; // Обнуляем стоимость перед пересчетом
            foreach (var item in items)
            {
                var menuItem = menuItems.Find(menu => menu.Name == item.MenuName);
                if (menuItem != null)
                {
                    totalCost += menuItem.Price * item.Quantity; // Обновляем TotalCost
                }
            }
            return totalCost;
        }


        public List<MenuItemXml> GetItems()
        {
            return items;
        }

        private List<Menu> menuItems;

        public override string ToString()
        {
            string result = "Your Order:\n";
            foreach (var item in items)
            {
                result += $"{item.MenuName} - Quantity: {item.Quantity}\n";
            }

            return $"{result}Total Cost: {TotalCost}";
        }
    }
}