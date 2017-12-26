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
      CompareTime(100);
      CompareTime(100000);

      void CompareTime(int size) {
        (double[] x, double[] y) GenerateVector() {
          var x = new double[size];
          var y = new double[size];
          for (var i = 0; i < size; i++) {
            x[i] = 1.0;
            y[i] = 1.0;
          }
          return (x, y);
        }

        var sw = new Stopwatch();
        (var xv, var yv) = GenerateVector();
        WriteLine($"Calc dot product by raw C# : size = {size}");
        sw.Reset();
        var res = 0.0;
        for (var i = 0; i < Loop; i++) {
          sw.Start();
          res = Dot(xv, yv);
          sw.Stop();
        }
        WriteLine($"Result : {res}\tTime : {sw.Elapsed / (double) Loop}");
        
        WriteLine($"Calc dot product by BLAS : size = {size}");
        sw.Reset();
        for (var i = 0; i < Loop; i++) {
          sw.Start();
          res = Blas1.dot(xv, yv);
          sw.Stop();
        }
        WriteLine($"Result : {res}\tTime : {sw.Elapsed / (double) Loop}");
      }
    }
  }
}