
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
    }
}
