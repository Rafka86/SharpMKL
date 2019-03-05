using System.Runtime.InteropServices;

namespace SharpMKL {

  public static partial class Lapack{
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgesv")]
    public static extern int gesv(LapackLayout layout, int n, int nrhs, float[] a, int lda,
                                  int[] ipiv, float[] b, int ldb);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgesv")]
    public static extern int gesv(LapackLayout layout, int n, int nrhs, double[] a, int lda,
                                  int[] ipiv, double[] b, int ldb);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dsgesv")]
    public static extern int gesv(LapackLayout layout, int n, int nrhs, double[] a, int lda,
                                  int[] ipiv, double[] b, int ldb, double[] x, int ldx, out int iter);
  }

}