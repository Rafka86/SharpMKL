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

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spoequ")]
    public static extern int poequ(LapackLayout Layout, int n, float[] a, int lda,
                                   float[] s, out float sCond, out float aMax);
    public static int poequ(LapackLayout Layout, int n, float[] a, int lda,
                            out float[]  s, out float sCond, out float aMax) {
      s = new float[n];
      return poequ(Layout, n, a, lda, s, out sCond, out aMax);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpoequ")]
    public static extern int poequ(LapackLayout Layout, int n, double[] a, int lda,
                                   double[] s, out double sCond, out double aMax);
    public static int poequ(LapackLayout Layout, int n, double[] a, int lda,
                            out double[]  s, out double sCond, out double aMax) {
      s = new double[n];
      return poequ(Layout, n, a, lda, s, out sCond, out aMax);
    }
  }
}