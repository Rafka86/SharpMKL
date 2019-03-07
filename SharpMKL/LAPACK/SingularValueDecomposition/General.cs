using System.Runtime.InteropServices;

namespace SharpMKL {

  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgesdd")]
    public static extern int gesdd(LapackLayout layout, char jobz, int m, int n, float[] a, int lda,
                                   float[] s, float[] u, int ldu, float[] vt, int ldvt);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgesdd")]
    public static extern int gesdd(LapackLayout layout, char jobz, int m, int n, double[] a, int lda,
                                   double[] s, double[] u, int ldu, double[] vt, int ldvt);
  }

}