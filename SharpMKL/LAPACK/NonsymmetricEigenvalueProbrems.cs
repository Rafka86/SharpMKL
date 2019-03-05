using System.Runtime.InteropServices;

namespace SharpMKL {

  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgeev")]
    public static extern int geev(LapackLayout layout, char jobvl, char jobvr, int n,
                                  float[] a, int lda, float[] wr, float[] wi,
                                  float[] vl, int ldvl, float[] vr, int ldvr);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgeev")]
    public static extern int geev(LapackLayout layout, char jobvl, char jobvr, int n,
                                  double[] a, int lda, double[] wr, double[] wi,
                                  double[] vl, int ldvl, double[] vr, int ldvr);
  }

}