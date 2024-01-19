using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.items
{
    public class Filling : Item
    {
        public override ItemType Type { get { return ItemType.FILLING; } }

        public Filling(int uniqueID, ItemData data) : base(uniqueID, data)
        {

        }
    }
}
