using System;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpMKL;

using static System.Math;

namespace SharpMKLStdTest {
  [TestClass]
  public class Blas1Test {
    private const float TorF = 1e-6f;
    private const double TorD = 1e-12;
    
    [TestMethod]
    public void AsumTest() {
      const int size = 10;
      const int nPat = 3;
      var dg = new DataGenerator();

      for (var i = 0; i < nPat; i++) {
        var x = dg.FloatArray(size: size);
        Assert.AreEqual(x.Select(MathF.Abs).Sum(), Blas1.asum(x.Length, x, 1), TorF);
      }

      for (var i = 0; i < nPat; i++) {
        var x = dg.DoubleArray(size: size);
        Assert.AreEqual(x.Select(Abs).Sum(), Blas1.asum(x.Length, x, 1), TorD);
      }

      for (var i = 0; i < nPat; i++) {
        var x = dg.ComplexArray(size: size);
        var expz = x.Select(c => Abs(c.Real) + Abs(c.Imaginary)).Sum();
        Assert.AreEqual(expz, Blas1.asum(x.Length, x, 1), TorD);
      }
    }

    [TestMethod]
    public void AxpyTest() {
      var xf = new[] {1.0f, 1.0f, 1.0f};
      var yf = new[] {1.0f, 1.0f, 1.0f};
      var xd = new[] {1.0, 1.0, 1.0};
      var yd = new[] {1.0, 1.0, 1.0};
      var xz = new[] {new Complex(1.0, 1.0),
                      new Complex(1.0, 1.0),
                      new Complex(1.0, 1.0)};
      var yz = new[] {new Complex(1.0, 1.0),
                      new Complex(1.0, 1.0),
                      new Complex(1.0, 1.0)};
      
      Blas1.axpy(xf.Length, 2.0f, xf, 1, yf, 1);
      foreach (var t in yf)
        Assert.AreEqual(3.0f, t);
      Blas1.axpy(xd.Length, 2.0, xd, 1, yd, 1);
      foreach (var t in yd)
        Assert.AreEqual(3.0, t);
      Blas1.axpy(xz.Length, 2.0, xz, 1, yz, 1);
      var expected = new Complex(3.0, 3.0);
      foreach (var t in yz)
        Assert.AreEqual(expected, t);
    }

    [TestMethod]
    public void CopyTest() {
      var xf = new[] {1.0f, -1.0f, 0.0f};
      var xpf = new[] {0.0f, 1.0f, -1.0f};
      var yf = new float[xf.Length];
      var ypf = new float[xf.Length];
      var xd = new[] {1.0, -1.0, 0.0};
      var xpd = new[] {0.0, 1.0, -1.0};
      var yd = new double[xd.Length];
      var ypd = new double[xd.Length];
      var xz = new[] {new Complex(1.0, 0.0),
                      new Complex(0.0, 1.0),
                      new Complex(1.0, -1.0)};
      var xpz = new[] {new Complex(0.0, 0.0),
                       new Complex(1.0, 0.0),
                       new Complex(0.0, 1.0)};
      var yz = new Complex[xz.Length];
      var ypz = new Complex[xz.Length];

      Blas1.copy(3, xf, 1, yf, 1);
      Blas1.copy(3, xd, 1, yd, 1);
      Blas1.copy(3, xz, 1, yz, 1);
      Blas1.copy(2, in xf[0], 1, out ypf[1], 1);
      Blas1.copy(2, in xd[0], 1, out ypd[1], 1);
      Blas1.copy(2, in xz[0], 1, out ypz[1], 1);

      for (var i = 0; i < yf.Length; i++)
        Assert.AreEqual(xf[i], yf[i]);
      for (var i = 0; i < ypf.Length; i++)
        Assert.AreEqual(xpf[i], ypf[i]);
      for (var i = 0; i < yd.Length; i++)
        Assert.AreEqual(xd[i], yd[i]);
      for (var i = 0; i < ypd.Length; i++)
        Assert.AreEqual(xpd[i], ypd[i]);
      for (var i = 0; i < yz.Length; i++)
        Assert.AreEqual(xz[i], yz[i]);
      for (var i = 0; i < ypz.Length; i++)
        Assert.AreEqual(xpz[i], ypz[i]);
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
    public void DotCTest() {
      var x = new[] {new Complex(2, -2),
                     new Complex(-1,1),
                     new Complex(0, -1)};
      var y = new[] {new Complex(1, 1),
                     new Complex(1, -1),
                     new Complex(1, 0)};
      Blas1.dotc(x.Length, x, 1, y, 1, out var res);
      Assert.AreEqual(new Complex(-2, 5), res);
    }

    [TestMethod]
    public void DotUTest() {
      var x = new[] {new Complex(2, -2),
                     new Complex(-1,1),
                     new Complex(0, -1)};
      var y = new[] {new Complex(1, 1),
                     new Complex(1, -1),
                     new Complex(1, 0)};
      Blas1.dotu(x.Length, x, 1, y, 1, out var res);
      Assert.AreEqual(new Complex(4, 1), res);
    }

    [TestMethod]
    public void ScalTest() {
      const float af = 2.0f;
      const double ad = -1.0;
      var xf = new[] {1.0f, 1.0f, 1.0f};
      var mxf = new float[3];
      Blas1.copy(xf.Length, xf, 1, mxf, 1);
      var xd = new[] {1.0, 1.0, 1.0};
      var mxd = new double[3];
      Blas1.copy(xd.Length, xd, 1, mxd, 1);
      
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