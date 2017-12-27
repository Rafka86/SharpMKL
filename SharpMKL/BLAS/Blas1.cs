using System;
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
    public static void copy(int n, float[] x, int incX, out float[] y, int incY) {
      y = new float[n];
      copy(n, x, incX, y, incY);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dcopy")]
    public static extern void copy(int n, double[] x, int incX, double[] y, int incY);
    public static void copy(int n, double[] x, int incX, out double[] y, int incY) {
      y = new double[n];
      copy(n, x, incX, y, incY);
    }
  
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

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_srotmg")]
    public static extern void rotmg(ref float d1, ref float d2, ref float x1, float y1, float[] param);
    public static void rotmg(ref float d1, ref float d2, ref float x1, float y1, out float[] param) {
      param = new float[5];
      rotmg(ref d1, ref d2, ref x1, y1, param);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_drotmg")]
    public static extern void rotmg(ref double d1, ref double d2, ref double x1, double y1, double[] param);
    public static void rotmg(ref double d1, ref double d2, ref double x1, double y1, out double[] param) {
      param = new double[5];
      rotmg(ref d1, ref d2, ref x1, y1, param);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sscal")]
    public static extern void scal(int n, float a, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dscal")]
    public static extern void scal(int n, double a, double[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sswap")]
    public static extern void swap(int n, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dswap")]
    public static extern void swap(int n, double[] x, int incX, double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_isamax")]
    public static extern int iamax(int n, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_idamax")]
    public static extern int iamax(int n, double[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_isamin")]
    public static extern int iamin(int n, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_idamin")]
    public static extern int iamin(int n, double[] x, int incX);
  }
}