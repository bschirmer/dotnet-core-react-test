using NUnit.Framework;
using PZCheesy.Services;

namespace PZCheesy.UnitTests
{
    [TestFixture]
    public class CheeseServiceTests
    {
        [Test]
        public void GetAllCheese()
        {
            var cheeseService = new CheeseService();

            var cheese = cheeseService.GetAllCheese();

            Assert.AreEqual(5, cheese.Count);
        }
    }
}