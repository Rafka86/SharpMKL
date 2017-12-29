using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpMKL;

namespace SharpMKLStdTest {
  [TestClass]
  public class Blas2Test {
    [TestMethod]
    public void GemvTest() {
      const double alpha = -2.0;
      const double beta = 2.0;
      var a = new[] {1.0, 1.0, 2.0, 1.0, 2.0, 1.0, 2.0, 1.0, 1.0};
      var x = new[] {3.0, -1.0, 2.0};
      var y = new double[3];
      
      Blas2.gemv(BlasLayout.RowMajor, BlasTranspose.NoTrans, 3, 3, alpha, a, 3, x, 1, beta, y, 1);

      var expects = new[] {-12.0, -6.0, -14.0};
      for (var i = 0 ; i < y.Length; i++)
        Assert.AreEqual(expects[i], y[i]);
    }
  }
}