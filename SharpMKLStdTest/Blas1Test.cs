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

    [TestMethod]
    public void AxpyTest() {
      var xf = new[] {1.0f, 1.0f, 1.0f};
      var yf = new[] {1.0f, 1.0f, 1.0f};
      var xd = new[] {1.0, 1.0, 1.0};
      var yd = new[] {1.0, 1.0, 1.0};
      
      Blas1.axpy(2.0f, xf, yf);
      foreach (var t in yf)
        Assert.AreEqual(3.0f, t);
      Blas1.axpy(2.0, xd, yd);
      foreach (var t in yd)
        Assert.AreEqual(3.0, t);
    }
  }
}