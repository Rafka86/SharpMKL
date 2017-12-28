using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgttrf")]
    public static extern int gttrf(int n, float[] dl, float[] d, float[] du, float[] du2, int[] ipiv);
    public static int gttrf(int n, float[] dl, float[] d, float[] du, out float[] du2, out int[] ipiv) {
      du2 = new float[n - 2];
      ipiv = new int[n];
      return gttrf(n, dl, d, du, du2, ipiv);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgttrf")]
    public static extern int gttrf(int n, double[] dl, double[] d, double[] du, double[] du2, int[] ipiv);
    public static int gttrf(int n, double[] dl, double[] d, double[] du, out double[] du2, out int[] ipiv) {
      du2 = new double[n - 2];
      ipiv = new int[n];
      return gttrf(n, dl, d, du, du2, ipiv);
    }
  }
}