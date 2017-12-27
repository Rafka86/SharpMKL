using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpMKLStd;

namespace SharpMKLStdTest {
  [TestClass]
  public class Blas1Test {
    [TestMethod]
    public void AsumTest() {
      var xf = new[] {1.0f, 1.0f, 1.0f};
      var xd = new[] {1.0, 1.0, 1.0};

      Assert.AreEqual(3.0f, Blas1.asum(3, xf, 1));
      Assert.AreEqual(3.0, Blas1.asum(3, xd, 1));
    }

    [TestMethod]
    public void AxpyTest() {
      var xf = new[] {1.0f, 1.0f, 1.0f};
      var yf = new[] {1.0f, 1.0f, 1.0f};
      var xd = new[] {1.0, 1.0, 1.0};
      var yd = new[] {1.0, 1.0, 1.0};
      
      Blas1.axpy(3, 2.0f, xf, 1, yf, 1);
      foreach (var t in yf)
        Assert.AreEqual(3.0f, t);
      Blas1.axpy(3, 2.0, xd, 1, yd, 1);
      foreach (var t in yd)
        Assert.AreEqual(3.0, t);
    }

    [TestMethod]
    public void CopyTest() {
      var xf = new[] {1.0f, -1.0f, 0.0f};
      var yf = new float[xf.Length];
      var xd = new[] {1.0, -1.0, 0.0};
      var yd = new double[xd.Length];

      Blas1.copy(3, xf, 1, yf, 1);
      Blas1.copy(3, xd, 1, yd, 1);

      for (var i = 0; i < yf.Length; i++) {
        Assert.AreEqual(xf[i], yf[i]);
        Assert.AreEqual(xd[i], yd[i]);
      }
    }

    [TestMethod]
    public void DotTest() {
      var xf = new[] {1.0f, 1.0f, 1.0f};
      var yf = new[] {1.0f, 1.0f, 1.0f};
      var xd = new[] {1.0, 1.0, 1.0};
      var yd = new[] {1.0, 1.0, 1.0};
      
      Assert.AreEqual(3.0f, Blas1.dot(3, xf, 1, yf, 1));
      Assert.AreEqual(3.0, Blas1.dot(3, xd, 1, yd, 1));
    }

    [TestMethod]
    public void ScalTest() {
      const float af = 2.0f;
      const double ad = -1.0;
      var xf = new[] {1.0f, 1.0f, 1.0f};
      Blas1.copy(xf.Length, xf, 1, out var mxf, 1);
      var xd = new[] {1.0, 1.0, 1.0};
      Blas1.copy(xd.Length, xd, 1, out var mxd, 1);
      
      Blas1.scal(mxf.Length, af, mxf, 1);
      Blas1.scal(mxd.Length, ad, mxd, 1);

      for (var i = 0; i < mxf.Length; i++)
        Assert.AreEqual(af * xf[i], mxf[i]);
      for (var i = 0; i < mxd.Length; i++)
        Assert.AreEqual(ad * xd[i], mxd[i]);
    }

    [TestMethod]
    public void IamaxTest() {
      var xf = new[] {1.0f, -2.0f, 5.0f, 12.0f};
      var xd = new[] {1.0, -2.0, 5.0, 12.0, -3.0};

      Assert.AreEqual(3, Blas1.iamax(xf.Length, xf, 1));
      Assert.AreEqual(3, Blas1.iamax(xd.Length, xd, 1));
    }

    [TestMethod]
    public void IaminTest() {
      var xf = new[] {1.0f, -2.0f, 5.0f, 12.0f};
      var xd = new[] {1.0, -2.0, 5.0, 12.0, -3.0};

      Assert.AreEqual(0, Blas1.iamin(xf.Length, xf, 1));
      Assert.AreEqual(0, Blas1.iamin(xd.Length, xd, 1));
    }
  }
}