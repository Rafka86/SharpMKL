//Symmetric Positive Definite RFP Storage

using System.Runtime.InteropServices;

namespace SharpMKL {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spftrf")]
    public static extern int pftrf(LapackLayout layout, LapackTranspose trans, LapackUpLo upLo, int n, float[] a);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpftrf")]
    public static extern int pftrf(LapackLayout layout, LapackTranspose trans, LapackUpLo upLo, int n, double[] a);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spftrs")]
    public static extern int pftrs(LapackLayout layout, LapackTranspose trans, LapackUpLo upLo,
                                   int n, int nrhs, float[] a, float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpftrs")]
    public static extern int pftrs(LapackLayout layout, LapackTranspose trans, LapackUpLo upLo,
                                   int n, int nrhs, double[] a, double[] b, int ldb);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spftri")]
    public static extern int pftri(LapackLayout layout, LapackTranspose trans, LapackUpLo upLo, int n, float[] a);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpftri")]
    public static extern int pftri(LapackLayout layout, LapackTranspose trans, LapackUpLo upLo, int n, double[] a);
  }
}