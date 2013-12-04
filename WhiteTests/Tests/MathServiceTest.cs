using Microsoft.VisualStudio.TestTools.UnitTesting;
using White.Core.UIItems.WindowItems;
using ViewAccessors;
using MathService;
using ViewAccessors;

namespace MathServiceTest
{
    [TestClass]
    public class MathServiceTest
    {
        Test test;
        AccessorBase accessor;
        DialogAccessor dialogAccessor;
        [TestInitialize]
        public void Initialize()
        {
            test = new Test();
        }

        [TestMethod]
        public void DecompositionTest()
        {
            accessor = new AccessorBase();
            string answer = "Representation for 6 includes: \n2\n3\n";
            string result = test.CalculationDecomposition(accessor, "6");
            Assert.AreEqual(result, answer);
        }

        [TestMethod]
        public void PhiFunctionTest()
        {
            dialogAccessor = new DialogAccessor();
            string answer = "Phi funcion for 6:\n1";
            string result = test.CalculationPhiFunction(dialogAccessor, "6");
            Assert.AreEqual(result, answer);
        }
    }
}
