using exercise.main;
using NUnit.Framework;


namespace exercise.tests
{
    internal class BasketTests
    {
        Basket basket;
        Inventory inventory;

        const string BAGEL_SKU = "BGLO";
        const string COFFEE_SKU = "COFB";
        const string FILLING_SKU = "FILB";

        [SetUp]
        public void Setup()
        {
            inventory = new Inventory();
            basket = new Basket(inventory);
        }

        [Test]
        public void TestBasketCreation()
        {
            Assert.That(basket.TotalPrice(), Is.EqualTo(0.0f));
            Assert.That(basket.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestCanAddItems()
        {
            var item = basket.AddItem(BAGEL_SKU);
            var item2 = basket.AddItem(COFFEE_SKU);

            // assert unique ids
            Assert.That(item.ID, Is.EqualTo(1));
            Assert.That(item2.ID, Is.EqualTo(2));

            Assert.That(basket.Items.Count, Is.EqualTo(2));
            Assert.That(basket.Items[0], Is.EqualTo(item));
            Assert.That(basket.Items[1], Is.EqualTo(item2));

            Assert.That(basket.TotalPrice(), Is.EqualTo(1.48f));
        }

        [Test]
        public void TestCannotExceedCapacity()
        {
            for (int i = 0; i < 5; i++)
            {
                basket.AddItem(BAGEL_SKU);
            }

            // catch exception
            Exception ex = Assert.Throws<System.Exception>(() => basket.AddItem(BAGEL_SKU));
            Assert.That(ex.Message, Is.EqualTo("Basket is full"));
        }

        [Test]
        public void TestCannotAddInexistingItem()
        {
            Exception ex = Assert.Throws<System.Exception>(() => basket.AddItem("NONEXISTING"));
            Assert.That(ex.Message, Is.EqualTo("Item not found"));
        }

        [Test]
        public void TestCanRemoveItem()
        {
            var item1 = basket.AddItem(BAGEL_SKU);
            var item2 = basket.AddItem(COFFEE_SKU);
            var item3 = basket.AddItem(BAGEL_SKU);

            // try remove by wrong index
            Assert.That(basket.RemoveItem(4), Is.False);

            // remove coffee
            Assert.That(basket.RemoveItem(2), Is.True);

            // test count
            Assert.That(basket.Items.Count, Is.EqualTo(2));
            // test contents of Items
            Assert.That(basket.Items[0], Is.EqualTo(item1));
            Assert.That(basket.Items[1], Is.EqualTo(item3));

            // test ids are unchanged
            Assert.That(item1.ID, Is.EqualTo(1));
            Assert.That(item3.ID, Is.EqualTo(3));

            // test next id is used
            var item4 = basket.AddItem(COFFEE_SKU);
            Assert.That(item4.ID, Is.EqualTo(4));
        }

        [Test]
        public void TestReducesCapacity()
        {
            basket.ChangeMaxCapacity(2);

            var item = basket.AddItem(BAGEL_SKU);
            var item2 = basket.AddItem(COFFEE_SKU);

            Assert.Throws<System.Exception>(() => basket.AddItem(BAGEL_SKU));
        }

        [Test]
        public void TestCannotReduceCapacityBelowCurrentItems()
        {
            basket.AddItem(BAGEL_SKU);
            basket.AddItem(COFFEE_SKU);

            Assert.Throws<System.Exception>(() => basket.ChangeMaxCapacity(1));
        }

        [Test]
        public void TestCannotReduceCapacityToZeroOrBelowZero()
        {
            Assert.Throws<System.Exception>(() => basket.ChangeMaxCapacity(0));
        }
    }
}
