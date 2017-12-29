//Symmetric Positive Definite RFP Storage

using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spftrf")]
    public static extern int pftrf(LapackLayout Layout, LapackTranspose Trans, LapackUpLo UpLo, int n, float[] a);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpftrf")]
    public static extern int pftrf(LapackLayout Layout, LapackTranspose Trans, LapackUpLo UpLo, int n, double[] a);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spftrs")]
    public static extern int pftrs(LapackLayout Layout, LapackTranspose Trans, LapackUpLo UpLo, int n, int nrhs, float[] a, float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpftrs")]
    public static extern int pftrs(LapackLayout Layout, LapackTranspose Trans, LapackUpLo UpLo, int n, int nrhs, double[] a, double[] b, int ldb);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spftri")]
    public static extern int pftri(LapackLayout Layout, LapackTranspose Trans, LapackUpLo UpLo, int n, float[] a);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpftri")]
    public static extern int pftri(LapackLayout Layout, LapackTranspose Trans, LapackUpLo UpLo, int n, double[] a);
  }
}