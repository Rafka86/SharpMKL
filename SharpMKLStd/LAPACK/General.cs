using System.Runtime.InteropServices;
using static System.Math;

namespace SharpMKLStd {
  public static class Lapack {
    private const string LibPath = "mkl_rt.dll";

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgetrf")]
    public static extern int getrf(LapackLayout Layout, int m, int n, float[] a, int lda, int[] ipiv);
    public static int getrf(LapackLayout Layout, int m, int n, float[] a, int lda, out int[] ipiv) {
      ipiv = new int[Max(1, Min(m, n))];
      return getrf(Layout, m, n, a, lda, ipiv);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgetrf")]
    public static extern int getrf(LapackLayout Layout, int m, int n, double[] a, int lda, int[] ipiv);
    public static int getrf(LapackLayout Layout, int m, int n, double[] a, int lda, out int[] ipiv) {
      ipiv = new int[Max(1, Min(m, n))];
      return getrf(Layout, m, n, a, lda, ipiv);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgetrs")]
    public static extern int getrs(LapackLayout Layout, LapackTranspose Trans,
                                   int n, int nrhs, float[] a, int lda, int[] ipiv,
                                   float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgetrs")]
    public static extern int getrs(LapackLayout Layout, LapackTranspose Trans,
                                   int n, int nrhs, double[] a, int lda, int[] ipiv,
                                   double[] b, int ldb);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgeequ")]
    public static extern int geequ(LapackLayout Layout,
                                   int m, int n, float[] a, int lda,
                                   float[] r, float[] c,
                                   out float rowCnd, out float colCnd, out float aMax);
    public static int geequ(LapackLayout Layout,
                            int m, int n, float[] a, int lda,
                            out float[] r, out float[] c,
                            out float rowCnd, out float colCnd, out float aMax) {
      r = new float[m];
      c = new float[n];
      return geequ(Layout, m, n, a, lda, r, c, out rowCnd, out colCnd, out aMax);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgeequ")]
    public static extern int geequ(LapackLayout Layout,
                                   int m, int n, double[] a, int lda,
                                   double[] r, double[] c,
                                   out double rowCnd, out double colCnd, out double aMax);

    public static int geequ(LapackLayout Layout,
                            int m, int n, double[] a, int lda,
                            out double[] r, out double[] c,
                            out double rowCnd, out double colCnd, out double aMax) {
      r = new double[m];
      c = new double[n];
      return geequ(Layout, m, n, a, lda, r, c, out rowCnd, out colCnd, out aMax);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgeequb")]
    public static extern int geequb(LapackLayout Layout,
                                    int m, int n, float[] a, int lda,
                                    float[] r, float[] c,
                                    out float rowCnd, out float colCnd, out float aMax);
    public static int geequb(LapackLayout Layout,
                             int m, int n, float[] a, int lda,
                             out float[] r, out float[] c,
                             out float rowCnd, out float colCnd, out float aMax) {
      r = new float[m];
      c = new float[n];
      return geequb(Layout, m, n, a, lda, r, c, out rowCnd, out colCnd, out aMax);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgeequb")]
    public static extern int geequb(LapackLayout Layout,
                                    int m, int n, double[] a, int lda,
                                    double[] r, double[] c,
                                    out double rowCnd, out double colCnd, out double aMax);
    public static int geequb(LapackLayout Layout,
                             int m, int n, double[] a, int lda,
                             out double[] r, out double[] c,
                             out double rowCnd, out double colCnd, out double aMax) {
      r = new double[m];
      c = new double[n];
      return geequb(Layout, m, n, a, lda, r, c, out rowCnd, out colCnd, out aMax);
    }
  }
}