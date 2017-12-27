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
  }
}