//Symmetric Positive Definite Packed Storage Matrix.

using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spptrf")]
    public static extern int pptrf(LapackLayout Layout, LapackUpLo UpLo, int n, float[] ap);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpptrf")]
    public static extern int pptrf(LapackLayout Layout, LapackUpLo UpLo, int n, double[] ap);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spptrs")]
    public static extern int pptrs(LapackLayout Layout, LapackUpLo UpLo,
                                   int n, int nrhs, float[] ap, float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpptrs")]
    public static extern int pptrs(LapackLayout Layout, LapackUpLo UpLo,
                                   int n, int nrhs, double[] ap, double[] b, int ldb);
    
  }
}