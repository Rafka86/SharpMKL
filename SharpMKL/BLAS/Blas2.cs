using System.Numerics;
using System.Runtime.InteropServices;

namespace SharpMKL {
  public static class Blas2 {
    private const string LibPath = "mkl_rt";

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sgbmv")]
    public static extern void gbmv(BlasLayout layout, BlasTranspose trans,
                                   int m, int n, int kl, int ku, float alpha, float[] a, int lda,
                                   float[] x, int incX, float beta, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dgbmv")]
    public static extern void gbmv(BlasLayout layout, BlasTranspose trans,
                                   int m, int n, int kl, int ku, double alpha, double[] a, int lda,
                                   double[] x, int incX, double beta, double[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zgbmv")]
    public static extern void gbmv(BlasLayout layout, BlasTranspose trans,
                                   int m, int n, int kl, int ku, in Complex alpha, Complex[] a, int lda,
                                   Complex[] x, int incX, in Complex beta, [In, Out] Complex[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sgemv")]
    public static extern void gemv(BlasLayout layout, BlasTranspose trans,
                                   int m, int n, float alpha, float[] a, int lda,
                                   float[] x, int incX, float beta, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dgemv")]
    public static extern void gemv(BlasLayout layout, BlasTranspose trans,
                                   int m, int n, double alpha, double[] a, int lda,
                                   double[] x, int incX, double beta, double[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zgemv")]
    public static extern void gemv(BlasLayout layout, BlasTranspose trans,
                                   int m, int n, in Complex alpha, Complex[] a, int lda,
                                   Complex[] x, int incX, in Complex beta, [In, Out] Complex[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sger")]
    public static extern void ger(BlasLayout layout, int m, int n,
                                  float alpha, float[] x, int incX, float[] y, int incY,
                                  float[] a, int lda);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dger")]
    public static extern void ger(BlasLayout layout, int m, int n,
                                  double alpha, double[] x, int incX, double[] y, int incY,
                                  double[] a, int lda);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zgerc")]
    public static extern void gerc(BlasLayout layout, int m, int n,
                                   in Complex alpha, Complex[] x, int incX, Complex[] y, int incY,
                                   [In, Out] Complex[] a, int lda);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zgeru")]
    public static extern void geru(BlasLayout layout, int m, int n,
                                   in Complex alpha, Complex[] x, int incX, Complex[] y, int incY,
                                   [In, Out] Complex[] a, int lda);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zhbmv")]
    public static extern void hbmv(BlasLayout layout, BlasUpLo upLo, int n, int k,
                                   in Complex alpha, Complex[] a, int lda, Complex[] x, int incX,
                                   in Complex beta, [In, Out] Complex[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zhemv")]
    public static extern void hemv(BlasLayout layout, BlasUpLo upLo, int n,
                                   in Complex alpha, Complex[] a, int lda, Complex[] x, int incX,
                                   in Complex beta, [In, Out] Complex[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zher")]
    public static extern void her(BlasLayout layout, BlasUpLo upLo, int n,
                                  in Complex alpha, Complex[] x, int incX,
                                  [In, Out] Complex[] a, int lda);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zher2")]
    public static extern void her2(BlasLayout layout, BlasUpLo upLo, int n,
                                   in Complex alpha, Complex[] x, int incX, Complex[] y, int incY,
                                   [In, Out] Complex[] a, int lda);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zhpmv")]
    public static extern void hpmv(BlasLayout layout, BlasUpLo upLo, int n, int k,
                                   in Complex alpha, Complex[] ap, Complex[] x, int incX,
                                   in Complex beta, [In, Out] Complex[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zhpr")]
    public static extern void hpr(BlasLayout layout, BlasUpLo upLo, int n,
                                  double alpha, Complex[] x, int incX, [In, Out] Complex[] ap);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zhpr2")]
    public static extern void hpr2(BlasLayout layout, BlasUpLo upLo, int n,
                                   in Complex alpha, Complex[] x, int incX,
                                   Complex[] y, int incY, [In, Out] Complex[] ap);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssbmv")]
    public static extern void sbmv(BlasLayout layout, BlasUpLo upLo, int n, int k, float alpha, float[] a, int lda,
                                   float[] x, int incX, float beta, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsbmv")]
    public static extern void sbmv(BlasLayout layout, BlasUpLo upLo, int n, int k, double alpha, double[] a, int lda,
                                   double[] x, int incX, double beta, double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sspmv")]
    public static extern void spmv(BlasLayout layout, BlasUpLo upLo, int n, float alpha, float[] ap,
                                   float[] x, int incX, float beta, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dspmv")]
    public static extern void spmv(BlasLayout layout, BlasUpLo upLo, int n, double alpha, double[] ap,
                                   double[] x, int incX, double beta, double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sspr")]
    public static extern void spr(BlasLayout layout, BlasUpLo upLo, int n,
                                  float alpha, float[] x, int incX, float[] ap);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dspr")]
    public static extern void spr(BlasLayout layout, BlasUpLo upLo, int n,
                                  double alpha, double[] x, int incX, double[] ap);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sspr2")]
    public static extern void spr2(BlasLayout layout, BlasUpLo upLo, int n,
                                   float alpha, float[] x, int incX, float[] y, int incY, float[] ap);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dspr2")]
    public static extern void spr2(BlasLayout layout, BlasUpLo upLo, int n,
                                   double alpha, double[] x, int incX, double[] y, int incY, double[] ap);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssymv")]
    public static extern void symv(BlasLayout layout, BlasUpLo upLo, int n,
                                   float alpha, float[] a, int lda, float[] x, int incX,
                                   float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsymv")]
    public static extern void symv(BlasLayout layout, BlasUpLo upLo, int n,
                                   double alpha, double[] a, int lda, double[] x, int incX,
                                   double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssyr")]
    public static extern void syr(BlasLayout layout, BlasUpLo upLo, int n,
                                  float alpha, float[] x, int incX, float[] a, int lda);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsyr")]
    public static extern void syr(BlasLayout layout, BlasUpLo upLo, int n,
                                  double alpha, double[] x, int incX, double[] a, int lda);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssyr2")]
    public static extern void syr2(BlasLayout layout, BlasUpLo upLo, int n,
                                   float alpha, float[] x, int incX, float[] y, int incY, float[] a, int lda);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsyr2")]
    public static extern void syr2(BlasLayout layout, BlasUpLo upLo, int n,
                                   double alpha, double[] x, int incX, double[] y, int incY, double[] a, int lda);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_stbmv")]
    public static extern void tbmv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n, int k,
                                   float[] a, int lda, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dtbmv")]
    public static extern void tbmv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n, int k,
                                   double[] a, int lda, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ztbmv")]
    public static extern void tbmv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n, int k,
                                   Complex[] a, int lda, [In, Out] Complex[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_stbsv")]
    public static extern void tbsv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n, int k,
                                   float[] a, int lda, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dtbsv")]
    public static extern void tbsv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n, int k,
                                   double[] a, int lda, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ztbsv")]
    public static extern void tbsv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n, int k,
                                   Complex[] a, int lda, [In, Out] Complex[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_stpmv")]
    public static extern void tpmv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   float[] ap, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dtpmv")]
    public static extern void tpmv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   double[] ap, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ztpmv")]
    public static extern void tpmv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   Complex[] ap, [In, Out] Complex[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_stpsv")]
    public static extern void tpsv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   float[] ap, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dtpsv")]
    public static extern void tpsv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   double[] ap, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ztpsv")]
    public static extern void tpsv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   Complex[] ap, [In, Out] Complex[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_strmv")]
    public static extern void trmv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   float[] a, int lda, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dtrmv")]
    public static extern void trmv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   double[] a, int lda, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ztrmv")]
    public static extern void trmv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   Complex[] a, int lda, [In, Out] Complex[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_strsv")]
    public static extern void trsv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   float[] a, int lda, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dtrsv")]
    public static extern void trsv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   double[] a, int lda, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ztrsv")]
    public static extern void trsv(BlasLayout layout, BlasUpLo upLo, BlasTranspose trans, BlasDiag diag, int n,
                                   Complex[] a, int lda, [In, Out] Complex[] x, int incX);
  }
}