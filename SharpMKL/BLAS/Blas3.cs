using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static class Blas3 {
    private const string LibPath = "mkl_rt.dll";

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sgemm")]
    public static extern void gemm(BlasLayout Layout, BlasTranspose TransA, BlasTranspose TransB, int m, int n, int k,
                                   float alpha, float[] a, int lda, float[] b, int ldb,
                                   float beta, float[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dgemm")]
    public static extern void gemm(BlasLayout Layout, BlasTranspose TransA, BlasTranspose TransB, int m, int n, int k,
                                   double alpha, double[] a, int lda, double[] b, int ldb,
                                   double beta, double[] c, int ldc);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssymm")]
    public static extern void symm(BlasLayout Layout, BlasSide Side, BlasUpLo UpLo, int m, int n,
                                   float alpha, float[] a, int lda, float[] b, int ldb,
                                   float beta, float[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsymm")]
    public static extern void symm(BlasLayout Layout, BlasSide Side, BlasUpLo UpLo, int m, int n,
                                   double alpha, double[] a, int lda, double[] b, int ldb,
                                   double beta, double[] c, int ldc);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssyrk")]
    public static extern void syrk(BlasLayout Layout, BlasUpLo UpLo, BlasTranspose Trans, int n, int k,
                                   float alpha, float[] a, int lda, float beta, float[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsyrk")]
    public static extern void syrk(BlasLayout Layout, BlasUpLo UpLo, BlasTranspose Trans, int n, int k,
                                   double alpha, double[] a, int lda, double beta, double[] c, int ldc);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssyrk2")]
    public static extern void syrk2(BlasLayout Layout, BlasUpLo UpLo, BlasTranspose Trans, int n, int k,
                                    float alpha, float[] a, int lda, float[] b, int ldb,
                                    float beta, float[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsyrk2")]
    public static extern void syrk2(BlasLayout Layout, BlasUpLo UpLo, BlasTranspose Trans, int n, int k,
                                    double alpha, double[] a, int lda, double[] b, int ldb,
                                    double beta, double[] c, int ldc);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_strmm")]
    public static extern void trmm(BlasLayout Layout, BlasSide Side, BlasUpLo UpLo,
                                   BlasTranspose Trans, BlasDiag Diag, int m, int n,
                                   float alpha, float[] a, int lda, float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dtrmm")]
    public static extern void trmm(BlasLayout Layout, BlasSide Side, BlasUpLo UpLo,
                                   BlasTranspose Trans, BlasDiag Diag, int m, int n,
                                   double alpha, double[] a, int lda, double[] b, int ldb);
  }
}