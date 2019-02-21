using System.Numerics;
using System.Runtime.InteropServices;

namespace SharpMKL {
  public static class Blas1 {
    private const string LibPath = "mkl_rt";
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sasum")]
    public static extern float asum(int n, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dasum")]
    public static extern double asum(int n, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dzasum")]
    public static extern double asum(int n, Complex[] x, int incX);
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_saxpy")]
    public static extern void axpy(int n, float a, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_daxpy")]
    public static extern void axpy(int n, double a, double[] x, int incX, double[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zaxpy")]
    public static extern void axpy(int n, in Complex a, Complex[] x, int incX, [In, Out] Complex[] y, int incY);
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_scopy")]
    public static extern void copy(int n, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dcopy")]
    public static extern void copy(int n, double[] x, int incX, double[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zcopy")]
    public static extern void copy(int n, Complex[] x, int incX, [Out] Complex[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_scopy")]
    public static extern void copy(int n, in float x, int incX, out float y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dcopy")]
    public static extern void copy(int n, in double x, int incX, out double y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zcopy")]
    public static extern void copy(int n, in Complex x, int incX, out Complex y, int incY);
  
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sdot")]
    public static extern float dot(int n, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_ddot")]
    public static extern double dot(int n, double[] x, int incX, double[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sdsdot")]
    public static extern float sdot(int n, float sb, float[] sx, int incX, float[] sy, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dsdot")]
    public static extern double sdot(int n, float[] sx, int incX, float[] sy, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zdotc_sub")]
    public static extern void dotc(int n, Complex[] x, int incX, Complex[] y, int incY, out Complex dotC);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zdotu_sub")]
    public static extern void dotu(int n, Complex[] x, int incX, Complex[] y, int incY, out Complex dotU);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_snrm2")]
    public static extern float nrm2(int n, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dnrm2")]
    public static extern double nrm2(int n, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dznrm2")]
    public static extern double nrm2(int n, Complex[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_srot")]
    public static extern void rot(int n, float[] x, int incX, float[] y, int incY, float c, float s);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_drot")]
    public static extern void rot(int n, double[] x, int incX, double[] y, int incY, double c, double s);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zdrot")]
    public static extern void rot(int n, [In, Out] Complex[] x, int incX, [In, Out] Complex[] y, int incY, double c, double s);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_srotg")]
    public static extern void rotg(ref float a, ref float b, out float c, out float s);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_drotg")]
    public static extern void rotg(ref double a, ref double b, out double c, out double s);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zrotg")]
    public static extern void rotg(ref Complex a, in Complex b, out double c, out Complex s);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_srotm")]
    public static extern void rotm(int n, float[] x, int incX, float[] y, int incY, float[] param);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_drotm")]
    public static extern void rotm(int n, double[] x, int incX, double[] y, int incY, double[] param);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_srotmg")]
    public static extern void rotmg(ref float d1, ref float d2, ref float x1, float y1, float[] param);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_drotmg")]
    public static extern void rotmg(ref double d1, ref double d2, ref double x1, double y1, double[] param);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sscal")]
    public static extern void scal(int n, float a, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dscal")]
    public static extern void scal(int n, double a, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zscal")]
    public static extern void scal(int n, in Complex a, [In, Out] Complex[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zdscal")]
    public static extern void scal(int n, double a, [In, Out] Complex[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sswap")]
    public static extern void swap(int n, float[] x, int incX, float[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dswap")]
    public static extern void swap(int n, double[] x, int incX, double[] y, int incY);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_zswap")]
    public static extern void swap(int n, [In, Out] Complex[] x, int incX, [In, Out] Complex[] y, int incY);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_isamax")]
    public static extern int iamax(int n, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_idamax")]
    public static extern int iamax(int n, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_izamax")]
    public static extern int iamax(int n, Complex[] x, int incX);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_isamin")]
    public static extern int iamin(int n, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_idamin")]
    public static extern int iamin(int n, double[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_izamin")]
    public static extern int iamin(int n, Complex[] x, int incX);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dcabs1")]
    public static extern double cabs1(in Complex z);
  }
}