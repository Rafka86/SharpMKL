using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static class Blas3 {
    private const string LibPath = "mkl_rt.dll";

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sgemm")]
    public static extern void gemm(BlasLayout Layout, BlasTranspose TransA, BlasTranspose TransB, int m, int n, int k,
                                   float alpha, float[] a, int lda, float[] b, int ldb, float beta, float[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dgemm")]
    public static extern void gemm(BlasLayout Layout, BlasTranspose TransA, BlasTranspose TransB, int m, int n, int k,
                                   double alpha, double[] a, int lda, double[] b, int ldb, double beta, double[] c, int ldc);
  }
}