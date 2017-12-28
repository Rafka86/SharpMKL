using System.Runtime.InteropServices;

namespace SharpMKLStd {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spotrf")]
    public static extern int potrf(LapackLayout Layout, LapackUpLo UpLo, int n, float[] a, int lda);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpotrf")]
    public static extern int potrf(LapackLayout Layout, LapackUpLo UpLo, int n, double[] a, int lda);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spotrs")]
    public static extern int potrs(LapackLayout Layout, LapackUpLo UpLo, int n, int nrhs,
                                   float[] a, int lda, float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpotrs")]
    public static extern int potrs(LapackLayout Layout, LapackUpLo UpLo, int n, int nrhs,
                                   double[] a, int lda, double[] b, int ldb);
  }
}