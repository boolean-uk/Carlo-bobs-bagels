
using exercise.main.items;

namespace exercise.main
{
    public class Inventory
    {
        private Dictionary<string, Tuple<ItemType, ItemData>> _items;

        /*
            | SKU  | Price | Name    | Variant       |
            |------|-------|---------|---------------|
            | BGLO | 0.49  | Bagel   | Onion         |
            | BGLP | 0.39  | Bagel   | Plain         |
            | BGLE | 0.49  | Bagel   | Everything    |
            | BGLS | 0.49  | Bagel   | Sesame        |
            | COFB | 0.99  | Coffee  | Black         |
            | COFW | 1.19  | Coffee  | White         |
            | COFC | 1.29  | Coffee  | Capuccino     |
            | COFL | 1.29  | Coffee  | Latte         |
            | FILB | 0.12  | Filling | Bacon         |
            | FILE | 0.12  | Filling | Egg           |
            | FILC | 0.12  | Filling | Cheese        |
            | FILX | 0.12  | Filling | Cream Cheese  |
            | FILS | 0.12  | Filling | Smoked Salmon |
            | FILH | 0.12  | Filling | Ham           |
         */
        public Inventory()
        {
            _items = new Dictionary<string, Tuple<ItemType, ItemData>>();
            _items.Add("BGLO", new Tuple<ItemType, ItemData>(ItemType.BAGEL, new ItemData("BGLO", 0.49f, "Onion")));
            _items.Add("BGLP", new Tuple<ItemType, ItemData>(ItemType.BAGEL, new ItemData("BGLP", 0.39f, "Plain")));
            _items.Add("BGLE", new Tuple<ItemType, ItemData>(ItemType.BAGEL, new ItemData("BGLE", 0.49f, "Everything")));
            _items.Add("BGLS", new Tuple<ItemType, ItemData>(ItemType.BAGEL, new ItemData("BGLS", 0.49f, "Sesame")));
            _items.Add("COFB", new Tuple<ItemType, ItemData>(ItemType.COFFEE, new ItemData("COFB", 0.99f, "Black")));
            _items.Add("COFW", new Tuple<ItemType, ItemData>(ItemType.COFFEE, new ItemData("COFW", 1.19f, "White")));
            _items.Add("COFC", new Tuple<ItemType, ItemData>(ItemType.COFFEE, new ItemData("COFC", 1.29f, "Capuccino")));
            _items.Add("COFL", new Tuple<ItemType, ItemData>(ItemType.COFFEE, new ItemData("COFL", 1.29f, "Latte")));
            _items.Add("FILB", new Tuple<ItemType, ItemData>(ItemType.FILLING, new ItemData("FILB", 0.12f, "Bacon")));
            _items.Add("FILE", new Tuple<ItemType, ItemData>(ItemType.FILLING, new ItemData("FILE", 0.12f, "Egg")));
            _items.Add("FILC", new Tuple<ItemType, ItemData>(ItemType.FILLING, new ItemData("FILC", 0.12f, "Cheese")));
            _items.Add("FILX", new Tuple<ItemType, ItemData>(ItemType.FILLING, new ItemData("FILX", 0.12f, "Cream Cheese")));
            _items.Add("FILS", new Tuple<ItemType, ItemData>(ItemType.FILLING, new ItemData("FILS", 0.12f, "Smoked Salmon")));
            _items.Add("FILH", new Tuple<ItemType, ItemData>(ItemType.FILLING, new ItemData("FILH", 0.12f, "Ham")));
        }

        public Tuple<ItemType, ItemData> GetItemData(string sku)
        {
            if (!_items.ContainsKey(sku))
            {
                throw new Exception("Item not found");
            }
            return _items[sku];
        }
    }
}
