using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpMKLStd;

namespace SharpMKLStdTest {
  [TestClass]
  public class Blas1Test {
    [TestMethod]
    public void AsumTest() {
      var xf = new[] {1.0f, 1.0f, 1.0f};
      var xd = new[] {1.0, 1.0, 1.0};

      Assert.AreEqual(3.0f, Blas1.asum(xf));
      Assert.AreEqual(3.0, Blas1.asum(xd));
    }
  }
}