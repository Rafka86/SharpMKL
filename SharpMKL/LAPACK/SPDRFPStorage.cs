//Symmetric Positive Definite RFP Storage

using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spftrf")]
    public static extern int pftrf(LapackLayout Layout, LapackTranspose Trans, LapackUpLo UpLo, int n, float[] a);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpftrf")]
    public static extern int pftrf(LapackLayout Layout, LapackTranspose Trans, LapackUpLo UpLo, int n, double[] a);
  }
}