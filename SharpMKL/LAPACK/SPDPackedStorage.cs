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
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sppequ")]
    public static extern int ppequ(LapackLayout Layout, LapackUpLo UpLo,
                                   int n, float[] ap, float[] s, out float sCond, out float aMax);
    public static int ppequ(LapackLayout Layout, LapackUpLo UpLo,
                            int n, float[] ap, out float[] s, out float sCond, out float aMax) {
      s = new float[n];
      return ppequ(Layout, UpLo, n, ap, s, out sCond, out aMax);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dppequ")]
    public static extern int ppequ(LapackLayout Layout, LapackUpLo UpLo,
                                   int n, double[] ap, double[] s, out double sCond, out double aMax);
    public static int ppequ(LapackLayout Layout, LapackUpLo UpLo,
                            int n, double[] ap, out double[] s, out double sCond, out double aMax) {
      s = new double[n];
      return ppequ(Layout, UpLo, n, ap, s, out sCond, out aMax);
    }
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sppcon")]
    public static extern int ppcon(LapackLayout Layout, LapackUpLo UpLo,
                                   int n, float[] ap, float aNorm, out float rCond);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dppcon")]
    public static extern int ppcon(LapackLayout Layout, LapackUpLo UpLo,
                                   int n, double[] ap, double aNorm, out double rCond);
  }
}