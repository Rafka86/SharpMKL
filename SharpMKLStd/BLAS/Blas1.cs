using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static class Blas1 {
    private const string LibPath = "mkl_rt.dll";
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sasum")]
    public static extern float asum(int n, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dasum")]
    public static extern double asum(int n, double[] x, int incX);
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_saxpy")]
    public static extern void axpy(int n, float a, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_daxpy")]
    public static extern void axpy(int n, double a, double[] x, int incX, double[] y, int incY);
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_scopy")]
    public static extern void copy(int n, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dcopy")]
    public static extern void copy(int n, double[] x, int incX, double[] y, int incY);
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sdot")]
    public static extern float dot(int n, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ddot")]
    public static extern double dot(int n, double[] x, int incX, double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sdsdot")]
    public static extern float sdot(int n, float sb, float[] sx, int incX, float[] sy, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsdot")]
    public static extern double sdot(int n, float[] sx, int incX, float[] sy, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_snrm2")]
    public static extern float nrm2(int n, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dnrm2")]
    public static extern double nrm2(int n, double[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_srot")]
    public static extern void rot(int n, float[] x, int incX, float[] y, int incY, float c, float s);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_drot")]
    public static extern void rot(int n, double[] x, int incX, double[] y, int incY, double c, double s);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_srotg")]
    public static extern void rotg(ref float a, ref float b, out float c, out float s);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_drotg")]
    public static extern void rotg(ref double a, ref double b, out double c, out double s);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_srotm")]
    public static extern void rotm(int n, float[] x, int incX, float[] y, int incY, float[] param);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_drotm")]
    public static extern void rotm(int n, double[] x, int incX, double[] y, int incY, double[] param);
  }
}