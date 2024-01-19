using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.items
{
    public enum ItemType
    {
        BAGEL,
        COFFEE,
        FILLING
    }

    interface ItemInfo
    {
        public abstract string SKU { get; }
        public abstract float Price { get; }
        public abstract string Variant { get; }

    }

    public struct ItemData : ItemInfo
    {
        private string _sku;
        private float _price;
        private string _variant;
        public string SKU { get { return _sku; } }
        public float Price { get { return _price; } }
        public string Variant { get { return _variant; } }

        public ItemData(string sku, float price, string variant)
        {
            _sku = sku;
            _price = price;
            _variant = variant;
        }
    }
}
