using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

using SharpMKL;
using static SharpMKL.Blas1;
using static SharpMKL.Lapack;
using static System.Console;

namespace PerformanceTest {
  internal static class Program {
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

    public static T DeepCopy<T>(this T src) {
      using (var memoryStream = new MemoryStream()) {
        var binForm = new BinaryFormatter();
        binForm.Serialize(memoryStream, src);
        memoryStream.Seek(0, SeekOrigin.Begin);
        return (T) binForm.Deserialize(memoryStream);
      }
    }
    
    private static void Main() {
      CompareTimeRowCopy((4, 4), 3);
      CompareTimeColumnCopy((4, 4), 3);
      //CompareTimeCopy(10000);
      //CompareTimeCopy(100000000);
      //CompareTimeDot(10);
      //CompareTimeDot(100);
      //CompareTimeDot(100000);

      //CompareTimeLu();

      void CompareTimeRowCopy((int row, int col) shape, int index) {
        var dg  = new DataGenerator();
        var src = dg.DoubleArray(size: shape.row * shape.col);
        var sw  = new Stopwatch();

        {
          WriteLine($"Copy partially array[{src.Length}] by BLAS.");
          var dst = new double[shape.col];
          sw.Reset();
          copy(dst.Length, in src[index * shape.col], 1, out dst[0], 1);
          sw.Start();
          sw.Stop();

          for (var i = 0; i < shape.row; i++)
            for (var j = 0; j < shape.col; j++)
              Write($"{src[i * shape.col + j]}{(j == shape.col - 1 ? '\n' : ' ')}");
          foreach (var x in dst)
            WriteLine(x);

          WriteLine($"Result : {src.Zip(dst, (s, d) => (s, d)).All(x => x.s == x.d)}\tTime : {sw.Elapsed}");
        }

        {
          WriteLine($"Copy partially array[{src.Length}] by Parallel.");
          var dst = new double[shape.row];
          sw.Reset();
          sw.Start();
          var tsk = Parallel.For(0, dst.Length, i => dst[i] = src[index * shape.col + i]);
          while (!tsk.IsCompleted) { }
          sw.Stop();

          for (var i = 0; i < shape.row; i++)
            for (var j = 0; j < shape.col; j++)
              Write($"{src[i * shape.col + j]}{(j == shape.col - 1 ? '\n' : ' ')}");
          foreach (var x in dst)
            WriteLine(x);

          WriteLine($"Result : {src.Zip(dst, (s, d) => (s, d)).All(x => x.s == x.d)}\tTime : {sw.Elapsed}");
        }
      }

      void CompareTimeColumnCopy((int row, int col) shape, int index) {
        var dg = new DataGenerator();
        var src = dg.DoubleArray(size: shape.row * shape.col);
        var sw = new Stopwatch();
        
        {
          WriteLine($"Copy partially array[{src.Length}] by BLAS.");
          var dst = new double[shape.row];
          sw.Reset();
          copy(dst.Length, in src[index], shape.col, out dst[0], 1);
          sw.Start();
          sw.Stop();
          
          for (var i = 0; i < shape.row; i++)
            for (var j = 0; j < shape.col; j++)
              Write($"{src[i * shape.col + j]}{(j == shape.col - 1 ? '\n' : ' ')}");
          foreach (var x in dst)
            WriteLine(x);

          WriteLine($"Result : {src.Zip(dst, (s, d) => (s, d)).All(x => x.s == x.d)}\tTime : {sw.Elapsed}");
        }

        {
          WriteLine($"Copy partially array[{src.Length}] by Parallel.");
          var dst = new double[shape.row];
          sw.Reset();
          sw.Start();
          var tsk = Parallel.For(0, dst.Length, i => dst[i] = src[i * shape.col + index]);
          while (!tsk.IsCompleted) { }
          sw.Stop();
          
          for (var i = 0; i < shape.row; i++)
            for (var j = 0; j < shape.col; j++)
              Write($"{src[i * shape.col + j]}{(j == shape.col - 1 ? '\n' : ' ')}");
          foreach (var x in dst)
            WriteLine(x);

          WriteLine($"Result : {src.Zip(dst, (s, d) => (s, d)).All(x => x.s == x.d)}\tTime : {sw.Elapsed}");
        }
      }
      
      void CompareTimeCopy(int size) {
        var dg = new DataGenerator();
        var src = dg.ComplexArray(size: size);
        var sw = new Stopwatch();
        
        {
          WriteLine($"Copy complex array[{size}] by Memory Stream.");
          sw.Reset();
          sw.Start();
          var dst = src.DeepCopy();
          sw.Stop();
          dst[1] = new Complex(1.0, 0.0);
          WriteLine($"Result : {src.Zip(dst, (s, d) => (s, d)).All(x => (Complex) x.s == (Complex) x.d)}\tTime : {sw.Elapsed}");
        }
        
        {
          WriteLine($"Copy complex array[{size}] by Parallel.For.");
          sw.Reset();
          var dst = new Complex[size];
          sw.Start();
          var tsk = Parallel.For(0, dst.Length, i => dst[i] = src[i]);
          while (!tsk.IsCompleted) { }
          sw.Stop();
          dst[1] = new Complex(1.0, 0.0);
          WriteLine($"Result : {src.Zip(dst, (s, d) => (s, d)).All(x => (Complex) x.s == (Complex) x.d)}\tTime : {sw.Elapsed}");
        }
        
        {
          WriteLine($"Copy complex array[{size}] by BLAS.");
          sw.Reset();
          var dst = new Complex[size];
          sw.Start();
          copy(src.Length, src, 1, dst, 1);
          sw.Stop();
          //for (var i = 0; i < src.Length; i++)
          //  WriteLine($"{src[i]} {dst[i]}");
          dst[1] = new Complex(1.0, 0.0);
          WriteLine($"Result : {src.Zip(dst, (s, d) => (s, d)).All(x => (Complex) x.s == (Complex) x.d)}\tTime : {sw.Elapsed}");
        }
      }
      
      void CompareTimeDot(int size) {
        const int loopDot = 10000;
        var sw = new Stopwatch();
        
        (var x, var y) = GenerateVector();
        WriteLine($"Calc dot product by raw C# : size = {size}");
        sw.Reset();
        var res = 0.0;
        for (var i = 0; i < loopDot; i++) {
          sw.Start();
          res = Dot(x, y);
          sw.Stop();
        }
        WriteLine($"Result : {res}\tTime : {sw.Elapsed / (double) loopDot}");
        
        WriteLine($"Calc dot product by BLAS : size = {size}");
        sw.Reset();
        for (var i = 0; i < loopDot; i++) {
          sw.Start();
          res = dot(size, x, 1, y, 1);
          sw.Stop();
        }
        WriteLine($"Result : {res}\tTime : {sw.Elapsed / (double) loopDot}\n");
        
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
      
      void CompareTimeLu() {
        const int loopLu = 100;
        const int m = 49;
        const int n = m * m;
        const double h = 1.0 / (m + 1);
        const double heat = 4.0;
        var aBase = new double[n * n];
        var bBase = new double[n];
        var ipiv = new int[n];
        int GeneralIndex(int i, int j) => i * n + j;
        for (var i = 1; i <= m; i++) {
          for (var j = 1; j <= m; j++) {
            var k = (i - 1) * m + j - 1;
            aBase[GeneralIndex(k, k)] = 4.0 / (h * h);
            if (i > 1) {
              var kDown = k - m;
              aBase[GeneralIndex(k, kDown)] = -1.0 / (h * h);
            }
            if (i < m) {
              var kUp = k + m;
              aBase[GeneralIndex(k, kUp)] = -1.0 / (h * h);
            }
            if (j > 1) {
              var kLeft = k - 1;
              aBase[GeneralIndex(k, kLeft)] = -1.0 / (h * h);
            }
            if (j < m) {
              var kRight = k + 1;
              aBase[GeneralIndex(k, kRight)] = -1.0 / (h * h);
            }
            bBase[k] = heat;
          }
        }
        
        var sw = new Stopwatch();
        WriteLine("Calc Poisson eq by raw C#.");
        sw.Reset();
        var res = new double[bBase.Length];
        for (var i = 0; i < loopLu; i++) {
          var a = new double[aBase.Length];
          var b = new double[bBase.Length];
          copy(aBase.Length, aBase, 1, a, 1);
          copy(bBase.Length, bBase, 1, b, 1);
          sw.Start();
          Decomp(n, n, a, ipiv);
          Solve(n, n, a, b, ipiv);
          sw.Stop();
          if (i == loopLu - 1) copy(b.Length, b, 1, res, 1);
        }
        WriteLine($"Result : {res[((m + 1) / 2 - 1) * m + m + 1]}\tTime : {sw.Elapsed / (double) loopLu}");
        
        WriteLine("Calc Poisson eq by LAPACK calls for general matrix.");
        sw.Reset();
        for (var i = 0; i < loopLu; i++) {
          var a = new double[aBase.Length];
          var b = new double[bBase.Length];
          copy(aBase.Length, aBase, 1, a, 1);
          copy(bBase.Length, bBase, 1, b, 1);
          sw.Start();
          getrf(LapackLayout.RowMajor, n, n, a, n, ipiv);
          getrs(LapackLayout.RowMajor, LapackTranspose.NoTrans, n, 1, a, n, ipiv, b, 1);
          sw.Stop();
          if (i == loopLu - 1) copy(b.Length, b, 1, res, 1);
        }
        WriteLine($"Result : {res[((m + 1) / 2 - 1) * m + m + 1]}\tTime : {sw.Elapsed / (double) loopLu}");

        const int bu = m;
        const int bl = m;
        const int ldab = 2 * bl + bu + 1;
        int BandIndex(int i, int j) => j * ldab + bl + bu + (i - j);
        var abBase = new double[ldab * n];
        for (var i = 1; i <= m; i++) {
          for (var j = 1; j <= m; j++) {
            var k = (i - 1) * m + j - 1;
            abBase[BandIndex(k, k)] = 4.0 / (h * h);
            if (i > 1) {
              var kDown = k - m;
              abBase[BandIndex(k, kDown)] = -1.0 / (h * h);
            }
            if (i < m) {
              var kUp = k + m;
              abBase[BandIndex(k, kUp)] = -1.0 / (h * h);
            }
            if (j > 1) {
              var kLeft = k - 1;
              abBase[BandIndex(k, kLeft)] = -1.0 / (h * h);
            }
            if (j < m) {
              var kRight = k + 1;
              abBase[BandIndex(k, kRight)] = -1.0 / (h * h);
            }
            bBase[k] = heat;
          }
        }
        WriteLine("Calc Poisson eq by LAPACK calls for band matrix.");
        sw.Reset();
        for (var i = 0; i < loopLu; i++) {
          var ab = new double[abBase.Length];
          var b = new double[bBase.Length];
          copy(abBase.Length, abBase, 1, ab, 1);
          copy(bBase.Length, bBase, 1, b, 1);
          sw.Start();
          gbtrf(LapackLayout.ColumnMajor, n, n, bl, bu, ab, ldab, ipiv);
          gbtrs(LapackLayout.ColumnMajor, LapackTranspose.NoTrans, n, bl, bu, 1, ab, ldab, ipiv, b, n);
          sw.Stop();
          if (i == loopLu - 1) copy(b.Length, b, 1, res, 1);
        }
        WriteLine($"Result : {res[((m + 1) / 2 - 1) * m + m + 1]}\tTime : {sw.Elapsed / (double) loopLu}");
        
        const int ldapb = bl + 1;
        int PackedIndex(int i, int j) => j * ldapb + i - j;
        var apbBase = new double[ldapb * n];
        for (var i = 1; i <= m; i++) {
          for (var j = 1; j <= m; j++) {
            var k = (i - 1) * m + j - 1;
            apbBase[PackedIndex(k, k)] = 4.0 / (h * h);
            if (i > 1) {
              var kDown = k - m;
              apbBase[PackedIndex(k, kDown)] = -1.0 / (h * h);
            }
            if (j > 1) {
              var kLeft = k - 1;
              apbBase[PackedIndex(k, kLeft)] = -1.0 / (h * h);
            }
            bBase[k] = heat;
          }
        }
        WriteLine("Calc Poisson eq by LAPACK calls for positive difinite band matrix.");
        sw.Reset();
        for (var i = 0; i < loopLu; i++) {
          var apb = new double[apbBase.Length];
          var b = new double[bBase.Length];
          copy(apbBase.Length, apbBase, 1, apb, 1);
          copy(bBase.Length, bBase, 1, b, 1);
          sw.Start();
          pbtrf(LapackLayout.ColumnMajor, LapackUpLo.Lower, n, bl, apb, ldapb);
          pbtrs(LapackLayout.ColumnMajor, LapackUpLo.Lower, n, bl, 1, apb, ldapb, b, n);
          sw.Stop();
          if (i == loopLu - 1) copy(b.Length, b, 1, res, 1);
        }
        WriteLine($"Result : {res[((m + 1) / 2 - 1) * m + m + 1]}\tTime : {sw.Elapsed / (double) loopLu}");
      }
    }
  }
}