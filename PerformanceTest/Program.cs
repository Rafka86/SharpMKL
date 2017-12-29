using System;
using System.ComponentModel.DataAnnotations;
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
        int generalIndex(int i, int j) => i * N + j;
        for (var i = 1; i <= M; i++) {
          for (var j = 1; j <= M; j++) {
            var k = (i - 1) * M + j - 1;
            aBase[generalIndex(k, k)] = 4.0 / (h * h);
            if (i > 1) {
              var kDown = k - M;
              aBase[generalIndex(k, kDown)] = -1.0 / (h * h);
            }
            if (i < M) {
              var kUp = k + M;
              aBase[generalIndex(k, kUp)] = -1.0 / (h * h);
            }
            if (j > 1) {
              var kLeft = k - 1;
              aBase[generalIndex(k, kLeft)] = -1.0 / (h * h);
            }
            if (j < M) {
              var kRight = k + 1;
              aBase[generalIndex(k, kRight)] = -1.0 / (h * h);
            }
            bBase[k] = Heat;
          }
        }
        
        var sw = new Stopwatch();
        WriteLine("Calc Poisson eq by raw C#.");
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
        
        WriteLine("Calc Poisson eq by LAPACK calls for general matrix.");
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

        const int bu = M;
        const int bl = M;
        const int ldab = 2 * bl + bu + 1;
        int bandIndex(int i, int j) => j * ldab + bl + bu + (i - j);
        var abBase = new double[ldab * N];
        for (var i = 1; i <= M; i++) {
          for (var j = 1; j <= M; j++) {
            var k = (i - 1) * M + j - 1;
            abBase[bandIndex(k, k)] = 4.0 / (h * h);
            if (i > 1) {
              var kDown = k - M;
              abBase[bandIndex(k, kDown)] = -1.0 / (h * h);
            }
            if (i < M) {
              var kUp = k + M;
              abBase[bandIndex(k, kUp)] = -1.0 / (h * h);
            }
            if (j > 1) {
              var kLeft = k - 1;
              abBase[bandIndex(k, kLeft)] = -1.0 / (h * h);
            }
            if (j < M) {
              var kRight = k + 1;
              abBase[bandIndex(k, kRight)] = -1.0 / (h * h);
            }
            bBase[k] = Heat;
          }
        }
        WriteLine("Calc Poisson eq by LAPACK calls for band matrix.");
        sw.Reset();
        for (var i = 0; i < LoopLU; i++) {
          Blas1.copy(abBase.Length, abBase, 1, out var ab, 1);
          Blas1.copy(bBase.Length, bBase, 1, out var b, 1);
          sw.Start();
          Lapack.gbtrf(LapackLayout.ColumnMajor, N, N, bl, bu, ab, ldab, ipiv);
          Lapack.gbtrs(LapackLayout.ColumnMajor, LapackTranspose.NoTrans, N, bl, bu, 1, ab, ldab, ipiv, b, N);
          sw.Stop();
          if (i == LoopLU - 1) Blas1.copy(b.Length, b, 1, res, 1);
        }
        WriteLine($"Result : {res[((M + 1) / 2 - 1) * M + M + 1]}\tTime : {sw.Elapsed / (double) LoopLU}");
        
        const int ldapb = bl + 1;
        int packedIndex(int i, int j) => j * ldapb + i - j;
        var apbBase = new double[ldapb * N];
        for (var i = 1; i <= M; i++) {
          for (var j = 1; j <= M; j++) {
            var k = (i - 1) * M + j - 1;
            apbBase[packedIndex(k, k)] = 4.0 / (h * h);
            if (i > 1) {
              var kDown = k - M;
              apbBase[packedIndex(k, kDown)] = -1.0 / (h * h);
            }
            if (j > 1) {
              var kLeft = k - 1;
              apbBase[packedIndex(k, kLeft)] = -1.0 / (h * h);
            }
            bBase[k] = Heat;
          }
        }
        WriteLine("Calc Poisson eq by LAPACK calls for packed band matrix.");
        sw.Reset();
        for (var i = 0; i < LoopLU; i++) {
          Blas1.copy(apbBase.Length, apbBase, 1, out var apb, 1);
          Blas1.copy(bBase.Length, bBase, 1, out var b, 1);
          sw.Start();
          Lapack.pbtrf(LapackLayout.ColumnMajor, LapackUpLo.Lower, N, bl, apb, ldapb);
          Lapack.pbtrs(LapackLayout.ColumnMajor, LapackUpLo.Lower, N, bl, 1, apb, ldapb, b, N);
          sw.Stop();
          if (i == LoopLU - 1) Blas1.copy(b.Length, b, 1, res, 1);
        }
        WriteLine($"Result : {res[((M + 1) / 2 - 1) * M + M + 1]}\tTime : {sw.Elapsed / (double) LoopLU}");
      }
    }
  }
}