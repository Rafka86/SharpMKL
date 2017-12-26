using System.Runtime.InteropServices;

namespace SharpMKLStd.Native {
  public static class NativeBlas1 {
    private const string LibPath = "mkl_rt.dll";
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sasum")]
    public static extern float sasum(int n, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dasum")]
    public static extern double dasum(int n, double[] x, int incX);
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_saxpy")]
    public static extern void saxpy(int n, float a, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_daxpy")]
    public static extern void daxpy(int n, double a, double[] x, int incX, double[] y, int incY);
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_scopy")]
    public static extern void scopy(int n, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dcopy")]
    public static extern void dcopy(int n, double[] x, int incX, double[] y, int incY);
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sdot")]
    public static extern float sdot(int n, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ddot")]
    public static extern double ddot(int n, double[] x, int incX, double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sdsdot")]
    public static extern float sdsdot(int n, float sb, float[] sx, int incX, float[] sy, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsdot")]
    public static extern double dsdot(int n, float[] sx, int incX, float[] sy, int incY);
  }
}