
using exercise.main.items;

namespace exercise.main
{
    public class Basket
    {
        private int nextItemUniqueId = 1;
        private int maxCapacity = 5;
        private List<Item> _items;
        private Inventory _inventory;

        public List<Item> Items { get { return _items; } }

        public Basket(Inventory inventory)
        {
            _inventory = inventory;
            _items = new List<Item>();
        }

        public Item AddItem(string sku)
        {
            if (basketIsFull())
            {
                throw new Exception("Basket is full");
            }
            Tuple<ItemType, ItemData> itemData = _inventory.GetItemData(sku);
            Item item = Item.CreateItem(itemData.Item1, nextItemUniqueId, itemData.Item2);
            _items.Add(item);
            nextItemUniqueId++;
            return item;
        }

        public bool RemoveItem(int id)
        {
            Item item = _items.Find(item => item.ID == id);
            if (item == null)
            {
                return false;
            }
            _items.Remove(item);
            return true;
        }

        public float TotalPrice()
        {
            return _items.Sum(item => item.TotalPrice());
        }

        public void ChangeMaxCapacity(int newCapacity)
        {
            if (newCapacity <= 0)
            {
                throw new Exception("Capacity must be greater than 0");
            }

            if (newCapacity < _items.Count)
            {
                throw new Exception("Cannot reduce capacity below current number of items");
            }

            maxCapacity = newCapacity;
        }

        private bool basketIsFull()
        {
            return _items.Count >= maxCapacity;
        }
    }
}
