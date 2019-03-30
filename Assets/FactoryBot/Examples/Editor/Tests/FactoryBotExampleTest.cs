
using System;
using System.Collections.Generic;
using NUnit.Framework;

using FactoryBot;

namespace FactoryBotExample
{
    [TestFixture]
    public class FactoryBotExampleTest
    {
        [Test]
        public void FactoryBotBuildItemTest()
        {
            Item item = Factory.Build<Item>(new Dictionary<string, object>() {
                { "name", "test" },
                { "posX", 0.3f },
                { "posY", 0.1f },
                { "posZ", 0.2f },
                { "amount", 3 }
            });
            Assert.AreEqual(item.name, "test");
            Assert.AreEqual(item.posX, 0.3f);
            Assert.AreEqual(item.posY, 0.1f);
            Assert.AreEqual(item.posZ, 0.2f);
            Assert.AreEqual(item.amount, 3);
        }

        [Test]
        public void FactoryBotBuildPertialItemTest()
        {
            Item item = Factory.Build<Item>(new Dictionary<string, object>() {
                { "name", "test" },
            });
            Assert.AreEqual(item.name, "test");
            Assert.AreEqual(item.posX, 0f);
            Assert.AreEqual(item.posY, 0f);
            Assert.AreEqual(item.posZ, 0f);
            Assert.AreEqual(item.amount, 0);
        }

        [Test]
        public void FactoryBotBuildLocationTest()
        {
            Location location = Factory.Build<Location>(new Dictionary<string, object>() {
                { "name", "test" },
                { "lat", 0.4 },
                { "lng", 0.5 },
            });
            Assert.AreEqual(location.name, "test");
            Assert.AreEqual(location.lat, 0.4);
            Assert.AreEqual(location.lng, 0.5);
        }

        [Test]
        public void FactoryBotBuildPertialLocationTest()
        {
            Location location = Factory.Build<Location>(new Dictionary<string, object>() {
                { "name", "test" },
            });
            Assert.AreEqual(location.name, "test");
            Assert.AreEqual(location.lat, 0);
            Assert.AreEqual(location.lng, 0);
        }

        [Test]
        public void FactoryBotDefineBuildItemTest()
        {
            DefinedFactory<Item> definedItem = Factory.Define<Item>(new Dictionary<string, object>() {
                { "name", "test" },
                { "posX", 0.3f },
                { "posY", 0.1f },
                { "posZ", 0.2f },
                { "amount", 3 }
            });
            Item item = definedItem.Build();
            Assert.AreEqual(item.name, "test");
            Assert.AreEqual(item.posX, 0.3f);
            Assert.AreEqual(item.posY, 0.1f);
            Assert.AreEqual(item.posZ, 0.2f);
            Assert.AreEqual(item.amount, 3);

            Item overrideItem = definedItem.Build(new Dictionary<string, object>() {
                { "name", "testtest" },
                { "amount", 6 }
            });
            Assert.AreEqual(overrideItem.name, "testtest");
            Assert.AreEqual(overrideItem.posX, 0.3f);
            Assert.AreEqual(overrideItem.posY, 0.1f);
            Assert.AreEqual(overrideItem.posZ, 0.2f);
            Assert.AreEqual(overrideItem.amount, 6);
        }

        [Test]
        public void FactoryBotDefineBuildPertialItemTest()
        {
            DefinedFactory<Item> definedItem = Factory.Define<Item>(new Dictionary<string, object>() {
                { "name", "test" },
            });
            Item item = definedItem.Build();
            Assert.AreEqual(item.name, "test");
            Assert.AreEqual(item.posX, 0f);
            Assert.AreEqual(item.posY, 0f);
            Assert.AreEqual(item.posZ, 0f);
            Assert.AreEqual(item.amount, 0);

            Item overrideItem = definedItem.Build(new Dictionary<string, object>() {
                { "name", "testtest" },
                { "amount", 6 }
            });
            Assert.AreEqual(overrideItem.name, "testtest");
            Assert.AreEqual(overrideItem.posX, 0f);
            Assert.AreEqual(overrideItem.posY, 0f);
            Assert.AreEqual(overrideItem.posZ, 0f);
            Assert.AreEqual(overrideItem.amount, 6);
        }

        [Test]
        public void FactoryBotBuildItemListTest()
        {
            List<Item> itemList = Factory.BuildList<Item>(new Dictionary<string, object>() {
                { "name", "test" },
                { "posX", 0.3f },
                { "posY", 0.1f },
                { "posZ", 0.2f },
                { "amount", 3 }
            }, 10);

            Assert.AreEqual(itemList.Count, 10);
            foreach (Item item in itemList)
            {
                Assert.AreEqual(item.name, "test");
                Assert.AreEqual(item.posX, 0.3f);
                Assert.AreEqual(item.posY, 0.1f);
                Assert.AreEqual(item.posZ, 0.2f);
                Assert.AreEqual(item.amount, 3);
            }
        }

        [Test]
        public void FactoryBotBuildPertialItemListTest()
        {
            List<Item> itemList = Factory.BuildList<Item>(new Dictionary<string, object>() {
                { "name", "test" },
            }, 10);

            Assert.AreEqual(itemList.Count, 10);
            foreach (Item item in itemList)
            {
                Assert.AreEqual(item.name, "test");
                Assert.AreEqual(item.posX, 0f);
                Assert.AreEqual(item.posY, 0f);
                Assert.AreEqual(item.posZ, 0f);
                Assert.AreEqual(item.amount, 0);
            }
        }

        [Test]
        public void FactoryBotDefineBuildItemListTest()
        {
            DefinedFactory<Item> definedItem = Factory.Define<Item>(new Dictionary<string, object>() {
                { "name", "test" },
                { "posX", 0.3f },
                { "posY", 0.1f },
                { "posZ", 0.2f },
                { "amount", 3 }
            });
            List<Item> itemList = definedItem.BuildList();
            Assert.AreEqual(itemList.Count, 1);
            foreach (Item item in itemList)
            {
                Assert.AreEqual(item.name, "test");
                Assert.AreEqual(item.posX, 0.3f);
                Assert.AreEqual(item.posY, 0.1f);
                Assert.AreEqual(item.posZ, 0.2f);
                Assert.AreEqual(item.amount, 3);
            }

            List<Item> overrideOneItemList = definedItem.BuildList(new Dictionary<string, object>() {
                { "posX", 0.6f },
                { "posY", 0.6f },
                { "posZ", 0.6f },
            });
            Assert.AreEqual(overrideOneItemList.Count, 1);
            foreach (Item item in overrideOneItemList)
            {
                Assert.AreEqual(item.name, "test");
                Assert.AreEqual(item.posX, 0.6f);
                Assert.AreEqual(item.posY, 0.6f);
                Assert.AreEqual(item.posZ, 0.6f);
                Assert.AreEqual(item.amount, 3);
            }

            List<Item> overrideItemList = definedItem.BuildList(new Dictionary<string, object>() {
                { "name", "testtest" },
                { "amount", 6 }
            }, 5);
            Assert.AreEqual(overrideItemList.Count, 5);
            foreach (Item item in overrideItemList)
            {
                Assert.AreEqual(item.name, "testtest");
                Assert.AreEqual(item.posX, 0.3f);
                Assert.AreEqual(item.posY, 0.1f);
                Assert.AreEqual(item.posZ, 0.2f);
                Assert.AreEqual(item.amount, 6);
            }
        }

        [Test]
        public void FactoryBotDefineBuildPertialItemListTest()
        {
            DefinedFactory<Item> definedItem = Factory.Define<Item>(new Dictionary<string, object>() {
                { "name", "test" },
            });
            List<Item> itemList = definedItem.BuildList();
            Assert.AreEqual(itemList.Count, 1);
            foreach (Item item in itemList)
            {
                Assert.AreEqual(item.name, "test");
                Assert.AreEqual(item.posX, 0f);
                Assert.AreEqual(item.posY, 0f);
                Assert.AreEqual(item.posZ, 0f);
                Assert.AreEqual(item.amount, 0);
            }

            List<Item> overrideOneItemList = definedItem.BuildList(new Dictionary<string, object>() {
                { "posX", 0.6f },
                { "posY", 0.6f },
                { "posZ", 0.6f },
            });
            Assert.AreEqual(overrideOneItemList.Count, 1);
            foreach (Item item in overrideOneItemList)
            {
                Assert.AreEqual(item.name, "test");
                Assert.AreEqual(item.posX, 0.6f);
                Assert.AreEqual(item.posY, 0.6f);
                Assert.AreEqual(item.posZ, 0.6f);
                Assert.AreEqual(item.amount, 0);
            }

            List<Item> overrideItemList = definedItem.BuildList(new Dictionary<string, object>() {
                { "name", "testtest" },
                { "amount", 6 }
            }, 5);
            Assert.AreEqual(overrideItemList.Count, 5);
            foreach (Item item in overrideItemList)
            {
                Assert.AreEqual(item.name, "testtest");
                Assert.AreEqual(item.posX, 0f);
                Assert.AreEqual(item.posY, 0f);
                Assert.AreEqual(item.posZ, 0f);
                Assert.AreEqual(item.amount, 6);
            }
        }
    }
}
