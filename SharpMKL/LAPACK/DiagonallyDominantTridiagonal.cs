using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sdttrfb")]
    public static extern void dttrfb(ref int n, float[] dl, float[] d, float[] du, ref int info);
    public static int dttrfb(int n, float[] dl, float[] d, float[] du) {
      int info;
      dttrfb(ref n, dl, d, du, ref info);
      return info;
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ddttrfb")]
    public static extern void dttrfb(ref int n, double[] dl, double[] d, double[] du, ref int info);
    public static int dttrfb(int n, double[] dl, double[] d, double[] du) {
      int info;
      dttrfb(ref n, dl, d, du, ref info);
      return info;
    }
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sdttrsb")]
    public static extern void dttrsb(ref LapackTranspose Trans, ref int n, ref int nrhs,
                                     float[] dl, float[] d, float[] du,
                                     float[] b, ref int ldb, ref int info);
    public static int dttrsb(LapackTranspose Trans, int n, int nrhs,
                             float[] dl, float[] d, float[] du,
                             float[] b, int ldb) {
      int info;
      dttrsb(ref Trans, ref n, ref nrhs, dl, d, du, b, ref ldb, ref info);
      return info;
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ddttrsb")]
    public static extern void dttrsb(ref LapackTranspose Trans, ref int n, ref int nrhs,
                                     double[] dl, double[] d, double[] du,
                                     double[] b, ref int ldb, ref int info);
    public static int dttrsb(LapackTranspose Trans, int n, int nrhs,
                             double[] dl, double[] d, double[] du,
                             double[] b, int ldb) {
      int info;
      dttrsb(ref Trans, ref n, ref nrhs, dl, d, du, b, ref ldb, ref info);
      return info;
    }
  }
}