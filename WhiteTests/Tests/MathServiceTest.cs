using Microsoft.VisualStudio.TestTools.UnitTesting;
using White.Core.UIItems.WindowItems;
using ViewAccessors;
using MathService;

namespace MathServiceTest
{
    [TestClass]
    public class MathServiceTest
    {
        Window window;
        AccessorBase accessor;
        Test test;
        [TestInitialize]
        public void Initialize()
        {
            accessor = new AccessorBase();
            window = accessor.window;
            test = new Test();
        }

        [TestMethod]
        public void IdenticTest()
        {
            string resultString = "Representation for 6 includes: \n2\n3\n";
            string resString = test.CalculationPhiFunc(window, "6");
            Assert.AreEqual(resString, resultString);
        }
    }
}
