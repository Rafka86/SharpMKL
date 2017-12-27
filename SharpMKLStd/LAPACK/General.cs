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

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgecon")]
    public static extern int gecon(LapackLayout Layout, LapackNorm Norm,
                                   int n, float[] a, int lda, float aNorm, ref float rCond);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgecon")]
    public static extern int gecon(LapackLayout Layout, LapackNorm Norm,
                                   int n, double[] a, int lda, double aNorm, ref double rCond);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgerfs")]
    public static extern int gerfs(LapackLayout Layout, LapackTranspose Transpose,
                                   int n, int nrhs, float[] a, int lda, float[] af, int ldaf, int[] ipiv,
                                   float[] b, int ldb, float[] x, int ldx, float[] fErr, float[] bErr);
    public static int gerfs(LapackLayout Layout, LapackTranspose Transpose,
                            int n, int nrhs, float[] a, int lda, float[] af, int ldaf, int[] ipiv,
                            float[] b, int ldb, float[] x, int ldx, out float[] fErr, out float[] bErr) {
      fErr = new float[nrhs > 1 ? nrhs : 1];
      bErr = new float[nrhs > 1 ? nrhs : 1];
      return gerfs(Layout, Transpose, n, nrhs, a, lda, af, ldaf, ipiv, b, ldb, x, ldx, fErr, bErr);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgerfs")]
    public static extern int gerfs(LapackLayout Layout, LapackTranspose Transpose,
                                   int n, int nrhs, double[] a, int lda, double[] af, int ldaf, int[] ipiv,
                                   double[] b, int ldb, double[] x, int ldx, double[] fErr, double[] bErr);
    public static int gerfs(LapackLayout Layout, LapackTranspose Transpose,
                            int n, int nrhs, double[] a, int lda, double[] af, int ldaf, int[] ipiv,
                            double[] b, int ldb, double[] x, int ldx, out double[] fErr, out double[] bErr) {
      fErr = new double[nrhs > 1 ? nrhs : 1];
      bErr = new double[nrhs > 1 ? nrhs : 1];
      return gerfs(Layout, Transpose, n, nrhs, a, lda, af, ldaf, ipiv, b, ldb, x, ldx, fErr, bErr);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgerfsx")]
    public static extern int gerfsx(LapackLayout Layout, LapackTranspose Transpose, LapackEquil Equed,
                                    int n, int nrhs, float[] a, int lda, float[] af, int ldaf, int[] ipiv,
                                    float[] r, float[] c, float[] b, int ldb, float[] x, int ldx,
                                    out float rCond, float[] bErr,
                                    int nErrBnds, float[] errBndsNorm, float[] errBndsConp,
                                    int nParams, float[] Params);

    public static int gerfsx(LapackLayout Layout, LapackTranspose Transpose, LapackEquil Equed,
                             int n, int nrhs, float[] a, int lda, float[] af, int ldaf, int[] ipiv,
                             float[] r, float[] c, float[] b, int ldb, float[] x, int ldx,
                             out float rCond, out float[] bErr,
                             int nErrBnds, out float[] errBndsNorm, out float[] errBndsConp,
                             int nParams, float[] Params) {
      bErr = new float[nrhs > 1 ? nrhs : 1];
      errBndsNorm = new float[nrhs * nErrBnds];
      errBndsConp = new float[nrhs * nErrBnds];
      return gerfsx(Layout, Transpose, Equed,
                    n, nrhs, a, lda, af, ldaf, ipiv,
                    r, c, b, ldb, x, ldx, out rCond, bErr,
                    nErrBnds, errBndsNorm, errBndsConp, nParams, Params);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgerfsx")]
    public static extern int gerfsx(LapackLayout Layout, LapackTranspose Transpose, LapackEquil Equed,
                                    int n, int nrhs, double[] a, int lda, double[] af, int ldaf, int[] ipiv,
                                    double[] r, double[] c, double[] b, int ldb, double[] x, int ldx,
                                    out double rCond, double[] bErr,
                                    int nErrBnds, double[] errBndsNorm, double[] errBndsConp,
                                    int nParams, double[] Params);
    public static int gerfsx(LapackLayout Layout, LapackTranspose Transpose, LapackEquil Equed,
                             int n, int nrhs, double[] a, int lda, double[] af, int ldaf, int[] ipiv,
                             double[] r, double[] c, double[] b, int ldb, double[] x, int ldx,
                             out double rCond, out double[] bErr,
                             int nErrBnds, out double[] errBndsNorm, out double[] errBndsConp,
                             int nParams, double[] Params) {
      bErr = new double[nrhs > 1 ? nrhs : 1];
      errBndsNorm = new double[nrhs * nErrBnds];
      errBndsConp = new double[nrhs * nErrBnds];
      return gerfsx(Layout, Transpose, Equed,
                    n, nrhs, a, lda, af, ldaf, ipiv,
                    r, c, b, ldb, x, ldx, out rCond, bErr,
                    nErrBnds, errBndsNorm, errBndsConp, nParams, Params);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgetri")]
    public static extern int getri(LapackLayout Layout, int n, float[] a, int lda);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgetri")]
    public static extern int getri(LapackLayout Layout, int n, double[] a, int lda);
  }
}