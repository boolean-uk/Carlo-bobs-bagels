using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.items
{
    public class Coffee: Item
    {
        public override ItemType Type { get { return ItemType.COFFEE; } }

        public Coffee(int uniqueID, ItemData data) : base(uniqueID, data)
        {

        }
    }
}
