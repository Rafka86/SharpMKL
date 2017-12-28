using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spotrf")]
    public static extern int potrf(LapackLayout Layout, LapackUpLo UpLo, int n, float[] a, int lda);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpotrf")]
    public static extern int potrf(LapackLayout Layout, LapackUpLo UpLo, int n, double[] a, int lda);
  }
}