using System.Runtime.InteropServices;

namespace SharpMKL {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spbtrf")]
    public static extern int pbtrf(LapackLayout layout, LapackUpLo upLo, int n, int kd, float[] ab, int ldab);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpbtrf")]
    public static extern int pbtrf(LapackLayout layout, LapackUpLo upLo, int n, int kd, double[] ab, int ldab);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spbequ")]
    public static extern int pbequ(LapackLayout layout, LapackUpLo upLo, int n, int kd, float[] ab, int ldab,
                                   float[] s, out float sCond, out float aMax);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpbequ")]
    public static extern int pbequ(LapackLayout layout, LapackUpLo upLo, int n, int kd, double[] ab, int ldab,
                                   double[] s, out double sCond, out double aMax);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spbtrs")]
    public static extern int pbtrs(LapackLayout layout, LapackUpLo upLo, int n, int kd, int nrhs, float[] ab, int ldab, float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpbtrs")]
    public static extern int pbtrs(LapackLayout layout, LapackUpLo upLo, int n, int kd, int nrhs, double[] ab, int ldab, double[] b, int ldb);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spbcon")]
    public static extern int pbcon(LapackLayout layout, LapackUpLo upLo, int n, int kd, float[] ab, int ldab,
                                   float aNorm, out float aCond);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpbcon")]
    public static extern int pbcon(LapackLayout layout, LapackUpLo upLo, int n, int kd, double[] ab, int ldab,
                                   double aNorm, out double aCond);
  }
}