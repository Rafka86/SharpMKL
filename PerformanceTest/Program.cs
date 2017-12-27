using System.Diagnostics;
using SharpMKLStd;
using static System.Console;

namespace PerformanceTest {
  internal static class Program {
    private const int LoopDot = 10000;
    private const int LoopLU = 5;
    
    private static void Swap(ref double n1, ref double n2) {
      double tmp;
      tmp = n1;
      n1 = n2;
      n2 = tmp;
    }
    
    private static double Dot(double[] x, double[] y) {
      var res = 0.0;
      for (var i = 0; i < x.Length; i++)
        res += x[i] * y[i];
      return res;
    }

    private static void Decomp(int m, int n, double[] a, int[] ipiv) {
      for (var i = 0; i < ipiv.Length; i++) ipiv[i] = i;

      for (var i = 0; i < m; i++) {
        if (!IsZero(a[i * n + i])) continue;
        var t = i;
        for (var j = i + 1; j < m; j++)
          if (a[t * n + i] < a[j * n + i])
            t = j;
        for (var j = 0; j < n; j++) Swap(ref a[i], ref a[t]);
        ipiv[i] = t;
      }
      
      for (var k = 0; k < m; k++) {
        for (var i = k + 1; i < m; i++) {
          var p = a[i * n + k] / a[k * n + k];
          for (var j = k + 1; j < m; j++)
            a[i * n + j] -= p * a[k * n + j];
          a[i * n + k] = p;
        }
      }

      bool IsZero(double p) => -double.Epsilon * 1e10 < p && p < double.Epsilon * 1e10;
    }

    private static void Solve(int m, int n, double[] a, double[] b, int[] ipiv) {
      for(var i = 0; i < ipiv.Length; i++)
        if (ipiv[i] != i) Swap(ref b[i], ref b[ipiv[i]]);

      for (var i = 1; i < b.Length; i++) {
        var sum = 0.0;
        for (var j = 0; j <= i - 1; j++) sum += a[i * n + j] * b[j];
        b[i] -= sum;
      }

      for (var i = b.Length - 1; i >= 0; i--) {
        var sum = 0.0;
        for (var j = i + 1; j < b.Length; j++) sum += a[i * n + j] * b[j];
        b[i] = (b[i] - sum) / a[i * n + i];
      }
    }
    
    private static void Main() {
      CompareTimeDot(10);
      CompareTimeDot(100);
      CompareTimeDot(100000);

      CompareTimeLU();
      
      void CompareTimeDot(int size) {
        var sw = new Stopwatch();
        (var x, var y) = GenerateVector();
        WriteLine($"Calc dot product by raw C# : size = {size}");
        sw.Reset();
        var res = 0.0;
        for (var i = 0; i < LoopDot; i++) {
          sw.Start();
          res = Dot(x, y);
          sw.Stop();
        }
        WriteLine($"Result : {res}\tTime : {sw.Elapsed / (double) LoopDot}");
        
        WriteLine($"Calc dot product by BLAS : size = {size}");
        sw.Reset();
        for (var i = 0; i < LoopDot; i++) {
          sw.Start();
          res = Blas1.dot(size, x, 1, y, 1);
          sw.Stop();
        }
        WriteLine($"Result : {res}\tTime : {sw.Elapsed / (double) LoopDot}\n");
        
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
      
      void CompareTimeLU() {
        const int M = 49;
        const int N = M * M;
        const double h = 1.0 / (M + 1);
        const double Heat = 4.0;
        var aBase = new double[N * N];
        var bBase = new double[N];
        var ipiv = new int[N];
        for (var i = 1; i <= M; i++) {
          for (var j = 1; j <= M; j++) {
            var k = (j - 1) * M + i - 1;
            aBase[k * N + k] = 4.0 / (h * h);
            if (i > 1) {
              var kl = k - 1;
              aBase[kl * N + k] = -1.0 / (h * h);
            }
            if (i < M) {
              var kr = k + 1;
              aBase[kr * N + k] = -1.0 / (h * h);
            }
            if (j > 1) {
              var kd = k - M;
              aBase[kd * N + k] = -1.0 / (h * h);
            }
            if (j < M) {
              var ku = k + M;
              aBase[ku * N + k] = -1.0 / (h * h);
            }
            bBase[k] = Heat;
          }
        }
        
        var sw = new Stopwatch();
        WriteLine("Calc Poisson eq by raw C#");
        sw.Reset();
        var res = new double[bBase.Length];
        for (var i = 0; i < LoopLU; i++) {
          Blas1.copy(aBase.Length, aBase, 1, out var a, 1);
          Blas1.copy(bBase.Length, bBase, 1, out var b, 1);
          sw.Start();
          Decomp(N, N, a, ipiv);
          Solve(N, N, a, b, ipiv);
          sw.Stop();
          if (i == LoopLU - 1) Blas1.copy(b.Length, b, 1, res, 1);
        }
        WriteLine($"Result : {res[((M + 1) / 2 - 1) * M + M + 1]}\tTime : {sw.Elapsed / (double) LoopLU}");
        
        WriteLine("Calc Poisson eq by LAPACK");
        sw.Reset();
        for (var i = 0; i < LoopLU; i++) {
          Blas1.copy(aBase.Length, aBase, 1, out var a, 1);
          Blas1.copy(bBase.Length, bBase, 1, out var b, 1);
          sw.Start();
          Lapack.getrf(LapackLayout.RowMajor, N, N, a, N, ipiv);
          Lapack.getrs(LapackLayout.RowMajor, LapackTranspose.NoTrans, N, 1, a, N, ipiv, b, 1);
          sw.Stop();
          if (i == LoopLU - 1) Blas1.copy(b.Length, b, 1, res, 1);
        }
        WriteLine($"Result : {res[((M + 1) / 2 - 1) * M + M + 1]}\tTime : {sw.Elapsed / (double) LoopLU}");
      }
    }
  }
}