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

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sgemv")]
    public static extern void gemv(BlasLayout Layout, BlasTranspose Trans,
                                   int m, int n, float alpha, float[] a, int lda,
                                   float[] x, int incX, float beta, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dgemv")]
    public static extern void gemv(BlasLayout Layout, BlasTranspose Trans,
                                   int m, int n, double alpha, double[] a, int lda,
                                   double[] x, int incX, double beta, double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sger")]
    public static extern void ger(BlasLayout Layout, int m, int n,
                                  float alpha, float[] x, int incX, float[] y, int incY,
                                  float[] a, int lda);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dger")]
    public static extern void ger(BlasLayout Layout, int m, int n,
                                  double alpha, double[] x, int incX, double[] y, int incY,
                                  double[] a, int lda);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssbmv")]
    public static extern void sbmv(BlasLayout Layout, BlasUpLo UpLo, int n, int k, float alpha, float[] a, int lda,
                                   float[] x, int incX, float beta, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsbmv")]
    public static extern void sbmv(BlasLayout Layout, BlasUpLo UpLo, int n, int k, double alpha, double[] a, int lda,
                                   double[] x, int incX, double beta, double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sspmv")]
    public static extern void spmv(BlasLayout Layout, BlasUpLo UpLo, int n, float alpha, float[] ap,
                                   float[] x, int incX, float beta, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dspmv")]
    public static extern void spmv(BlasLayout Layout, BlasUpLo UpLo, int n, double alpha, double[] ap,
                                   double[] x, int incX, double beta, double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sspr")]
    public static extern void spr(BlasLayout Layout, BlasUpLo UpLo, int n,
                                  float alpha, float[] x, int incX, float[] ap);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dspr")]
    public static extern void spr(BlasLayout Layout, BlasUpLo UpLo, int n,
                                  double alpha, double[] x, int incX, double[] ap);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sspr2")]
    public static extern void spr2(BlasLayout Layout, BlasUpLo UpLo, int n,
                                   float alpha, float[] x, int incX, float[] y, int incY, float[] ap);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dspr2")]
    public static extern void spr2(BlasLayout Layout, BlasUpLo UpLo, int n,
                                   double alpha, double[] x, int incX, double[] y, int incY, double[] ap);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssymv")]
    public static extern void symv(BlasLayout Layout, BlasUpLo UpLo, int n,
                                   float alpha, float[] a, int lda, float[] x, int incX,
                                   float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsymv")]
    public static extern void symv(BlasLayout Layout, BlasUpLo UpLo, int n,
                                   double alpha, double[] a, int lda, double[] x, int incX,
                                   double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssyr")]
    public static extern void syr(BlasLayout Layout, BlasUpLo UpLo, int n,
                                  float alpha, float[] x, int incX, float[] a, int lda);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsyr")]
    public static extern void syr(BlasLayout Layout, BlasUpLo UpLo, int n,
                                  double alpha, double[] x, int incX, double[] a, int lda);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ssyr2")]
    public static extern void syr2(BlasLayout Layout, BlasUpLo UpLo, int n,
                                  float alpha, float[] x, int incX, float[] y, int incY, float[] a, int lda);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsyr2")]
    public static extern void syr2(BlasLayout Layout, BlasUpLo UpLo, int n,
                                  double alpha, double[] x, int incX, double[] y, int incY, double[] a, int lda);
  }
}