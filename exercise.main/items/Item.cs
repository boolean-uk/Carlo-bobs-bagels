namespace exercise.main.items
{
    public abstract class Item : ItemInfo
    {
        protected int _uniqueID;
        protected ItemData _data;

        public string SKU { get { return _data.SKU; } }
        public float Price { get { return _data.Price; } }
        public string Variant { get { return _data.Variant; } }


        public int ID { get { return _uniqueID; } }
        public abstract ItemType Type { get; }

        public Item(int uniqueID, ItemData data)
        {
            _uniqueID = uniqueID;
            _data = data;
        }

        public virtual float TotalPrice()
        {
            return _data.Price;
        }

        public static Item CreateItem(ItemType type, int uniqueID, ItemData data)
        {
            switch (type)
            {
                case ItemType.BAGEL:
                    return new Bagel(uniqueID, data);
                case ItemType.COFFEE:
                    return new Coffee(uniqueID, data);
                case ItemType.FILLING:
                    return new Filling(uniqueID, data);
                default:
                    throw new Exception("Cannot create item with Unknown ItemType");
            }
        }
    }
}
