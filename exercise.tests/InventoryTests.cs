using exercise.main;
using exercise.main.items;

namespace exercise.tests
{
    internal class InventoryTests
    {

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

        private Inventory inventory;

        [SetUp]
        public void Setup()
        {
            inventory = new Inventory();
        }

        [TestCase("BGLO", 0.49f, "Onion", ItemType.BAGEL)]
        [TestCase("BGLP", 0.39f, "Plain", ItemType.BAGEL)]
        [TestCase("BGLE", 0.49f, "Everything", ItemType.BAGEL)]
        [TestCase("BGLS", 0.49f, "Sesame", ItemType.BAGEL)]
        [TestCase("COFB", 0.99f, "Black", ItemType.COFFEE)]
        [TestCase("COFW", 1.19f, "White", ItemType.COFFEE)]
        [TestCase("COFC", 1.29f, "Capuccino", ItemType.COFFEE)]
        [TestCase("COFL", 1.29f, "Latte", ItemType.COFFEE)]
        [TestCase("FILB", 0.12f, "Bacon", ItemType.FILLING)]
        [TestCase("FILE", 0.12f, "Egg", ItemType.FILLING)]
        [TestCase("FILC", 0.12f, "Cheese", ItemType.FILLING)]
        [TestCase("FILX", 0.12f, "Cream Cheese", ItemType.FILLING)]
        [TestCase("FILS", 0.12f, "Smoked Salmon", ItemType.FILLING)]
        [TestCase("FILH", 0.12f, "Ham", ItemType.FILLING)]

        public void GetsCorrectItemFromInventory(string sku, float price, string variant, ItemType type)
        {
            var itemData = inventory.GetItemData(sku);
            Assert.That(itemData.Item1, Is.EqualTo(type));
            Assert.That(itemData.Item2.SKU, Is.EqualTo(sku));
            Assert.That(itemData.Item2.Price, Is.EqualTo(price));
            Assert.That(itemData.Item2.Variant, Is.EqualTo(variant));
        }

        [Test]
        public void ThrowsIfInvalidItemFetched()
        {
            // assert throws exception
            Exception ex = Assert.Throws<Exception>(() => inventory.GetItemData("INVALID"));

            Assert.That(ex.Message, Is.EqualTo("Item not found"));
        }
    }
}
