namespace exercise.main.items
{
    public class Bagel: Item
    {
        private List<Filling> _fillings;

        public List<Filling> Fillings { get { return _fillings; } }

        public override ItemType Type { get { return ItemType.BAGEL; } }

        public Bagel(int uniqueID, ItemData data) : base(uniqueID, data)
        {
            _fillings = new List<Filling>();
        }

        public int AddFilling(Filling filling)
        {
            int nextFillingId = _fillings.Count;
            _fillings.Add(filling);
            return nextFillingId;
        }

        public void RemoveFilling(int index)
        {
            if (index >= 0 && index < _fillings.Count)
            {
                _fillings.RemoveAt(index);
            }
            else
            {
                throw new Exception("Filling not found");
            }
        }
        public override float TotalPrice()
        {
            return _data.Price + _fillings.Sum(f => f.TotalPrice());
        }
    }
}
