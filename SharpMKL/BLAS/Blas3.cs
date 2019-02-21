using System.Numerics;
using System.Runtime.InteropServices;

namespace SharpMKL {
  public static class Blas3 {
    private const string LibPath = "mkl_rt";

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sgemm")]
    public static extern void gemm(BlasLayout layout, BlasTranspose transA, BlasTranspose transB, int m, int n, int k,
                                   float alpha, float[] a, int lda, float[] b, int ldb,
                                   float beta, float[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dgemm")]
    public static extern void gemm(BlasLayout layout, BlasTranspose transA, BlasTranspose transB, int m, int n, int k,
                                   double alpha, double[] a, int lda, double[] b, int ldb,
                                   double beta, double[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zgemm")]
    public static extern void gemm(BlasLayout layout, BlasTranspose transA, BlasTranspose transB, int m, int n, int k,
                                   in Complex alpha, Complex[] a, int lda, Complex[] b, int ldb,
                                   in Complex beta, [In, Out] Complex[] c, int ldc);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zhemm")]
    public static extern void hemm(BlasLayout layout, BlasSide side, BlasUpLo upLo, int m, int n,
                                   in Complex alpha, Complex[] a, int lda, Complex[] b, int ldb,
                                   in Complex beta, [In, Out] Complex[] c, int ldc);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zherk")]
    public static extern void herk(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, int n, int k,
                                   double alpha, Complex[] a, int lda,
                                   double beta, [In, Out] Complex[] c, int ldc);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zher2k")]
    public static extern void her2k(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, int n, int k,
                                   in Complex alpha, Complex[] a, int lda, Complex[] b, int ldb,
                                   double beta, [In, Out] Complex[] c, int ldc);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssymm")]
    public static extern void symm(BlasLayout layout, BlasSide side, BlasUpLo upLo, int m, int n,
                                   float alpha, float[] a, int lda, float[] b, int ldb,
                                   float beta, float[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsymm")]
    public static extern void symm(BlasLayout layout, BlasSide side, BlasUpLo upLo, int m, int n,
                                   double alpha, double[] a, int lda, double[] b, int ldb,
                                   double beta, double[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zsymm")]
    public static extern void symm(BlasLayout layout, BlasSide side, BlasUpLo upLo, int m, int n,
                                   in Complex alpha, Complex[] a, int lda, Complex[] b, int ldb,
                                   in Complex beta, [In, Out] Complex[] c, int ldc);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssyrk")]
    public static extern void syrk(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, int n, int k,
                                   float alpha, float[] a, int lda, float beta, float[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsyrk")]
    public static extern void syrk(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, int n, int k,
                                   double alpha, double[] a, int lda, double beta, double[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zsyrk")]
    public static extern void syrk(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, int n, int k,
                                   in Complex alpha, Complex [] a, int lda,
                                   in Complex beta, [In, Out] Complex[] c, int ldc);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssyr2k")]
    public static extern void syr2k(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, int n, int k,
                                    float alpha, float[] a, int lda, float[] b, int ldb,
                                    float beta, float[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsyr2k")]
    public static extern void syr2k(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, int n, int k,
                                    double alpha, double[] a, int lda, double[] b, int ldb,
                                    double beta, double[] c, int ldc);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zsyr2k")]
    public static extern void syr2k(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, int n, int k,
                                    in Complex alpha, Complex[] a, int lda, Complex[] b, int ldb,
                                    in Complex beta, [In, Out] Complex[] c, int ldc);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_strmm")]
    public static extern void trmm(BlasLayout layout, BlasSide side, BlasUpLo upLo,
                                   BlasTranspose trans, BlasDiag diag, int m, int n,
                                   float alpha, float[] a, int lda, float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dtrmm")]
    public static extern void trmm(BlasLayout layout, BlasSide side, BlasUpLo upLo,
                                   BlasTranspose trans, BlasDiag diag, int m, int n,
                                   double alpha, double[] a, int lda, double[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ztrmm")]
    public static extern void trmm(BlasLayout layout, BlasSide side, BlasUpLo upLo,
                                   BlasTranspose trans, BlasDiag diag, int m, int n,
                                   in Complex alpha, Complex[] a, int lda, [In, Out] Complex[] b, int ldb);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_strsm")]
    public static extern void trsm(BlasLayout layout, BlasSide side, BlasUpLo upLo,
                                   BlasTranspose trans, BlasDiag diag, int m, int n,
                                   float alpha, float[] a, int lda, float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dtrsm")]
    public static extern void trsm(BlasLayout layout, BlasSide side, BlasUpLo upLo,
                                   BlasTranspose trans, BlasDiag diag, int m, int n,
                                   double alpha, double[] a, int lda, double[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ztrsm")]
    public static extern void trsm(BlasLayout layout, BlasSide side, BlasUpLo upLo,
                                   BlasTranspose trans, BlasDiag diag, int m, int n,
                                   in Complex alpha, Complex[] a, int lda, [In, Out] Complex[] b, int ldb);
  }
}