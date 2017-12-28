using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sdttrfb")]
    public static extern void dttrfb(ref int n, float[] dl, float[] d, float[] du, ref int info);
    public static int dttrfb(int n, float[] dl, float[] d, float[] du) {
      int info;
      dttrfb(ref n, dl, du, d, ref info);
      return info;
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ddttrfb")]
    public static extern void dttrfb(ref int n, double[] dl, double[] d, double[] du, ref int info);
    public static int dttrfb(int n, double[] dl, double[] d, double[] du) {
      int info;
      dttrfb(ref n, dl, du, d, ref info);
      return info;
    }
  }
}