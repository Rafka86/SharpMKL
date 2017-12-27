using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static class Lapack {
    private const string LibPath = "mkl_rt.dll";

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgetrf")]
    public static extern int getrf(LapackLayout Layout, int m, int n, float[] a, int lda, int[] ipiv);
    public static int getrf(LapackLayout Layout, int m, int n, float[] a, int lda, out int[] ipiv) {
      ipiv = new int[n];
      return getrf(Layout, m, n, a, lda, ipiv);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgetrf")]
    public static extern int getrf(LapackLayout Layout, int m, int n, double[] a, int lda, int[] ipiv);
    public static int getrf(LapackLayout Layout, int m, int n, double[] a, int lda, out int[] ipiv) {
      ipiv = new int[n];
      return getrf(Layout, m, n, a, lda, ipiv);
    }
  }
}