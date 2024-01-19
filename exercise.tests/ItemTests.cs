using exercise.main.items;
using NUnit.Framework;

namespace exercise.tests
{
    internal class ItemTests
    {
        [Test]
        public void TestItemData()
        {
            var itemData = new ItemData("SKU", 1.0f, "Variant");
            Assert.That(itemData.SKU, Is.EqualTo("SKU"));
            Assert.That(itemData.Price, Is.EqualTo(1.0f));
            Assert.That(itemData.Variant, Is.EqualTo("Variant"));
        }

        [TestCase("SKU", 1.0f, "Variant", ItemType.BAGEL)]
        [TestCase("SKU", 1.0f, "Variant", ItemType.COFFEE)]
        [TestCase("SKU", 1.0f, "Variant", ItemType.FILLING)]
        public void TestItemCreation(string sku, float price, string variant, ItemType type)
        {
            var itemData = new ItemData(sku, price, variant);
            var item = Item.CreateItem(type, 1, itemData);

            switch (type)
            {
                case ItemType.BAGEL:
                    Assert.That(item, Is.TypeOf<Bagel>());
                    break;
                case ItemType.COFFEE:
                    Assert.That(item, Is.TypeOf<Coffee>());
                    break;
                case ItemType.FILLING:
                    Assert.That(item, Is.TypeOf<Filling>());
                    break;
            }

            Assert.That(item.ID, Is.EqualTo(1));
            Assert.That(item.SKU, Is.EqualTo("SKU"));
            Assert.That(item.Price, Is.EqualTo(1.0f));
            Assert.That(item.Variant, Is.EqualTo("Variant"));
            Assert.That(item.Type, Is.EqualTo(type));
            Assert.That(item.TotalPrice(), Is.EqualTo(1.0f));
        }

        [Test]
        public void TestBagelAddingFilling()
        {
            var itemData = new ItemData("SKU", 1.0f, "Variant");
            var bagel = Item.CreateItem(ItemType.BAGEL, 1, itemData) as Bagel;

            var fillingData = new ItemData("SKU", 2.0f, "Variant");
            var filling = Item.CreateItem(ItemType.FILLING, 2, fillingData) as Filling;


            bagel.AddFilling(filling);

            Assert.That(bagel.Fillings.Count, Is.EqualTo(1));
            Assert.That(bagel.Fillings[0], Is.EqualTo(filling));

            Assert.That(bagel.TotalPrice(), Is.EqualTo(3.0f));
        }

        [Test]
        public void TestRemovingFilling()
        {
            var itemData = new ItemData("SKU", 1.0f, "Variant");
            var bagel = Item.CreateItem(ItemType.BAGEL, 1, itemData) as Bagel;

            var fillingData = new ItemData("SKU", 2.0f, "Variant");
            var filling = Item.CreateItem(ItemType.FILLING, 2, fillingData) as Filling;

            var filling2Data = new ItemData("SKU2", 3.0f, "Variant");
            var filling2 = Item.CreateItem(ItemType.FILLING, 2, filling2Data) as Filling;

            var filling3Data = new ItemData("SKU3", 5.0f, "Variant");
            var filling3 = Item.CreateItem(ItemType.FILLING, 2, filling3Data) as Filling;

            Assert.That(bagel.AddFilling(filling), Is.EqualTo(0));
            Assert.That(bagel.AddFilling(filling2), Is.EqualTo(1));
            Assert.That(bagel.AddFilling(filling3), Is.EqualTo(2));

            // execute
            bagel.RemoveFilling(1);

            Assert.That(bagel.Fillings.Count, Is.EqualTo(2));
            Assert.That(bagel.Fillings[0], Is.EqualTo(filling));
            Assert.That(bagel.Fillings[1], Is.EqualTo(filling3));
            Assert.That(bagel.TotalPrice(), Is.EqualTo(8.0f));
        }
    }
}
