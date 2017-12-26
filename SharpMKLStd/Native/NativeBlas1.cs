using System.Runtime.InteropServices;

namespace SharpMKLStd.Native {
  public static class NativeBlas1 {
    private const string LibPath = "libmkl_rt.so";

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_sasum")]
    public static extern float sasum(int n, float[] x, int incX);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cblas_dasum")]
    public static extern double dasum(int n, double[] x, int incX);
  }
}