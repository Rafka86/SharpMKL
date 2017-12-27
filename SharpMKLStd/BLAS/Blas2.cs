using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static class Blas2 {
    private const string LibPath = "mkl_rt.dll";

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sgbmv")]
    public static extern void gbmv(BlasLayout Layout, BlasTranspose Trans,
                                   int m, int n, int kl, int ku, float alpha, float[] a, int lda,
                                   float[] x, int incX, float beta, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dgbmv")]
    public static extern void gbmv(BlasLayout Layout, BlasTranspose Trans,
                                   int m, int n, int kl, int ku, double alpha, double[] a, int lda,
                                   double[] x, int incX, double beta, double[] y, int incY);
  }
}