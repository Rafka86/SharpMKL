using System.Diagnostics;
using SharpMKLStd;
using static System.Console;

namespace PerformanceTest {
  internal static class Program {
    private const int Loop = 10000;
    
    static double Dot(double[] x, double[] y) {
      var res = 0.0;
      for (var i = 0; i < x.Length; i++)
        res += x[i] * y[i];
      return res;
    }

    private static void Main() {
      CompareTime(10);
      //CompareTime(100);
      //CompareTime(100000);

      var a = new[] {1.0, 1.0, 0.0, 3.0, 2.0, 1.0, -1.0, 1.0, 3.0, -1.0, -1.0, 2.0, -1.0, 2.0, 3.0 - 1.0};
      Lapack.getrf(LapackLayout.RowMajor, 4, 4, a, 4, out var ipiv);
      for (var i = 0; i < 4; i++)
        WriteLine($"{a[i * 4 + 0]} {a[i * 4] + 1} {a[i * 4] + 2} {a[i * 4] + 3}");
      
      void CompareTime(int size) {
        var sw = new Stopwatch();
        (var x, var y) = GenerateVector();
        WriteLine($"Calc dot product by raw C# : size = {size}");
        sw.Reset();
        var res = 0.0;
        for (var i = 0; i < Loop; i++) {
          sw.Start();
          res = Dot(x, y);
          sw.Stop();
        }
        WriteLine($"Result : {res}\tTime : {sw.Elapsed / (double) Loop}");
        
        WriteLine($"Calc dot product by BLAS : size = {size}");
        sw.Reset();
        for (var i = 0; i < Loop; i++) {
          sw.Start();
          res = Blas1.dot(size, x, 1, y, 1);
          sw.Stop();
        }
        WriteLine($"Result : {res}\tTime : {sw.Elapsed / (double) Loop}");
        
        (double[] x, double[] y) GenerateVector() {
          x = new double[size];
          y = new double[size];
          for (var i = 0; i < size; i++) {
            x[i] = 1.0;
            y[i] = 1.0;
          }
          return (x, y);
        }
      }
    }
  }
}