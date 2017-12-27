using System.Runtime.InteropServices;
using static System.Math;

namespace SharpMKLStd {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgbtrf")]
    public static extern int gbtrf(LapackLayout Layout, int m, int n, int kl, int ku,
                                   float[] ab, int ldab, int[] ipiv);
    public static int gbtrf(LapackLayout Layout, int m, int n, int kl, int ku,
                            float[] ab, int ldab, out int[] ipiv) {
      ipiv = new int[Max(1, Min(m, n))];
      return gbtrf(Layout, m, n, kl, ku, ab, ldab, ipiv);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgbtrf")]
    public static extern int gbtrf(LapackLayout Layout, int m, int n, int kl, int ku,
                                   double[] ab, int ldab, int[] ipiv);
    public static int gbtrf(LapackLayout Layout, int m, int n, int kl, int ku,
                            double[] ab, int ldab, out int[] ipiv) {
      ipiv = new int[Max(1, Min(m, n))];
      return gbtrf(Layout, m, n, kl, ku, ab, ldab, ipiv);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgbtrs")]
    public static extern int gbtrs(LapackLayout Layout, LapackTranspose Trans, int n, int kl, int ku, int nrhs,
                                   float[] ab, int ldab, int[] ipiv, float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgbtrs")]
    public static extern int gbtrs(LapackLayout Layout, LapackTranspose Trans, int n, int kl, int ku, int nrhs,
                                   double[] ab, int ldab, int[] ipiv, double[] b, int ldb);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgbequ")]
    public static extern int gbequ(LapackLayout Layout, int m, int n, int kl, int ku, float[] ab, int ldab,
                                   float[] r, float[] c, out float rowCnd, out float colCnd, out float aMax);
    public static int gbequ(LapackLayout Layout, int m, int n, int kl, int ku, float[] ab, int ldab,
                            out float[] r, out float[] c, out float rowCnd, out float colCnd, out float aMax) {
      r = new float[m];
      c = new float[n];
      return gbequ(Layout, m, n, kl, ku, ab, ldab, r, c, out rowCnd, out colCnd, out aMax);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgbequ")]
    public static extern int gbequ(LapackLayout Layout, int m, int n, int kl, int ku, double[] ab, int ldab,
                                   double[] r, double[] c, out double rowCnd, out double colCnd, out double aMax);
    public static int gbequ(LapackLayout Layout, int m, int n, int kl, int ku, double[] ab, int ldab,
                            out double[] r, out double[] c, out double rowCnd, out double colCnd, out double aMax) {
      r = new double[m];
      c = new double[n];
      return gbequ(Layout, m, n, kl, ku, ab, ldab, r, c, out rowCnd, out colCnd, out aMax);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgbequb")]
    public static extern int gbequb(LapackLayout Layout, int m, int n, int kl, int ku, float[] ab, int ldab,
                                    float[] r, float[] c, out float rowCnd, out float colCnd, out float aMax);
    public static int gbequb(LapackLayout Layout, int m, int n, int kl, int ku, float[] ab, int ldab,
                             out float[] r, out float[] c, out float rowCnd, out float colCnd, out float aMax) {
      r = new float[m];
      c = new float[n];
      return gbequb(Layout, m, n, kl, ku, ab, ldab, r, c, out rowCnd, out colCnd, out aMax);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgbequb")]
    public static extern int gbequb(LapackLayout Layout, int m, int n, int kl, int ku, double[] ab, int ldab,
                                    double[] r, double[] c, out double rowCnd, out double colCnd, out double aMax);
    public static int gbequb(LapackLayout Layout, int m, int n, int kl, int ku, double[] ab, int ldab,
                             out double[] r, out double[] c, out double rowCnd, out double colCnd, out double aMax) {
      r = new double[m];
      c = new double[n];
      return gbequb(Layout, m, n, kl, ku, ab, ldab, r, c, out rowCnd, out colCnd, out aMax);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgbcon")]
    public static extern int gbcon(LapackLayout Layout, LapackNorm Norm, int n, int kl, int ku,
                                   float[] ab, int ldab, int[] ipiv, float aNorm, ref float rCond);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgbcon")]
    public static extern int gbcon(LapackLayout Layout, LapackNorm Norm, int n, int kl, int ku,
                                   double[] ab, int ldab, int[] ipiv, double aNorm, ref double rCond);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgbrfs")]
    public static extern int gbrfs(LapackLayout Layout, LapackTranspose Trans, int n, int kl, int ku, int nrhs,
                                   float[] ab, int ldab, float[] afb, int ldafb, int[] ipiv,
                                   float[] b, int ldb, float[] x, int ldx, float[] fErr, float[] bErr);
    public static int gbrfs(LapackLayout Layout, LapackTranspose Trans, int n, int kl, int ku, int nrhs,
                            float[] ab, int ldab, float[] afb, int ldafb, int[] ipiv,
                            float[] b, int ldb, float[] x, int ldx, out float[] fErr, out float[] bErr) {
      fErr = new float[nrhs > 1 ? nrhs : 1];
      bErr = new float[nrhs > 1 ? nrhs : 1];
      return gbrfs(Layout, Trans, n, kl, ku, nrhs, ab, ldab, afb, ldafb, ipiv, b, ldb, x, ldx, fErr, bErr);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgbrfs")]
    public static extern int gbrfs(LapackLayout Layout, LapackTranspose Trans, int n, int kl, int ku, int nrhs,
                                   double[] ab, int ldab, double[] afb, int ldafb, int[] ipiv,
                                   double[] b, int ldb, double[] x, int ldx, double[] fErr, double[] bErr);
    public static int gbrfs(LapackLayout Layout, LapackTranspose Trans, int n, int kl, int ku, int nrhs,
                            double[] ab, int ldab, double[] afb, int ldafb, int[] ipiv,
                            double[] b, int ldb, double[] x, int ldx, out double[] fErr, out double[] bErr) {
      fErr = new double[nrhs > 1 ? nrhs : 1];
      bErr = new double[nrhs > 1 ? nrhs : 1];
      return gbrfs(Layout, Trans, n, kl, ku, nrhs, ab, ldab, afb, ldafb, ipiv, b, ldb, x, ldx, fErr, bErr);
    }
  }
}