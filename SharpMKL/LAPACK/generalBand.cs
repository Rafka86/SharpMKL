using System.Runtime.InteropServices;
using static System.Math;

namespace SharpMKLStd {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgbtrf")]
    public static extern int gbtrf(LapackLayout Layout, int m, int n, int kl, int ku,
                                   float[] ab, int ldab, int[] ipiv);
    public static int gbtrf(LapackLayout Layout, int m, int n, int kl, int ku,
                            float[] ab, int ldab, out int[] ipiv) {
      ipiv = new int[Max(1, Min(m, n))];
      return gbtrf(Layout, m, n, kl, ku, ab, ldab, ipiv);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgbtrf")]
    public static extern int gbtrf(LapackLayout Layout, int m, int n, int kl, int ku,
                                   double[] ab, int ldab, int[] ipiv);
    public static int gbtrf(LapackLayout Layout, int m, int n, int kl, int ku,
                            double[] ab, int ldab, out int[] ipiv) {
      ipiv = new int[Max(1, Min(m, n))];
      return gbtrf(Layout, m, n, kl, ku, ab, ldab, ipiv);
    }
  }
}