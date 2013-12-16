using Microsoft.VisualStudio.TestTools.UnitTesting;
using White.Core.UIItems.WindowItems;
using ViewAccessors;
using _MathService;
using Services;
using White.Core;
using System.IO;

namespace MathServiceTest
{
    [TestClass]
    public class MathServiceTest
    {
        Context context;

        [TestInitialize]
        public void Initialize()
        {
            context = new Context();
        }

        [TestMethod]
        public void DecompositionTest()
        { 
            string answer = "Representation for 6 includes: \n2\n3\n";
            string result = context.MathService.CalculationDecomposition("6");
            Assert.AreEqual(result, answer);
        }

        [TestMethod]
        public void PhiFunctionTest()
        {   
            string answer = "Phi funcion for 6:\n2";
            string result = context.MathService.CalculationPhiFunction("6");
            Assert.AreEqual(result, answer);
        }
    }
}
