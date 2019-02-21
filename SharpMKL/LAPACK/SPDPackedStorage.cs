//Symmetric Positive Definite Packed Storage Matrix.

using System.Data;
using System.Runtime.InteropServices;

namespace SharpMKL {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spptrf")]
    public static extern int pptrf(LapackLayout layout, LapackUpLo upLo, int n, float[] ap);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpptrf")]
    public static extern int pptrf(LapackLayout layout, LapackUpLo upLo, int n, double[] ap);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spptrs")]
    public static extern int pptrs(LapackLayout layout, LapackUpLo upLo,
                                   int n, int nrhs, float[] ap, float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpptrs")]
    public static extern int pptrs(LapackLayout layout, LapackUpLo upLo,
                                   int n, int nrhs, double[] ap, double[] b, int ldb);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sppequ")]
    public static extern int ppequ(LapackLayout layout, LapackUpLo upLo,
                                   int n, float[] ap, float[] s, out float sCond, out float aMax);
    public static int Ppequ(LapackLayout layout, LapackUpLo upLo,
                            int n, float[] ap, out float[] s, out float sCond, out float aMax) {
      s = new float[n];
      return ppequ(layout, upLo, n, ap, s, out sCond, out aMax);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dppequ")]
    public static extern int ppequ(LapackLayout layout, LapackUpLo upLo,
                                   int n, double[] ap, double[] s, out double sCond, out double aMax);
    public static int Ppequ(LapackLayout layout, LapackUpLo upLo,
                            int n, double[] ap, out double[] s, out double sCond, out double aMax) {
      s = new double[n];
      return ppequ(layout, upLo, n, ap, s, out sCond, out aMax);
    }
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sppcon")]
    public static extern int ppcon(LapackLayout layout, LapackUpLo upLo, int n, float[] ap, float aNorm, out float rCond);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dppcon")]
    public static extern int ppcon(LapackLayout layout, LapackUpLo upLo, int n, double[] ap, double aNorm, out double rCond);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spprfs")]
    public static extern int pprfs(LapackLayout layout, LapackUpLo upLo, int n, int nrhs,
                                   float[] ap, float[] afp, float[] b, int ldb, float[] x, int ldx,
                                   float[] fErr, float[] bErr);
    public static int Pprfs(LapackLayout layout, LapackUpLo upLo, int n, int nrhs,
                            float[] ap, float[] afp, float[] b, int ldb, float[] x, int ldx,
                            out float[] fErr, out float[] bErr) {
      fErr = new float[nrhs > 1 ? nrhs : 1];
      bErr = new float[nrhs > 1 ? nrhs : 1];
      return pprfs(layout, upLo, n, nrhs, ap, afp, b, ldb, x, ldx, fErr, bErr);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpprfs")]
    public static extern int pprfs(LapackLayout layout, LapackUpLo upLo, int n, int nrhs,
                                   double[] ap, double[] afp, double[] b, int ldb, double[] x, int ldx,
                                   double[] fErr, double[] bErr);
    public static int Pprfs(LapackLayout layout, LapackUpLo upLo, int n, int nrhs,
                            double[] ap, double[] afp, double[] b, int ldb, double[] x, int ldx,
                            out double[] fErr, out double[] bErr) {
      fErr = new double[nrhs > 1 ? nrhs : 1];
      bErr = new double[nrhs > 1 ? nrhs : 1];
      return pprfs(layout, upLo, n, nrhs, ap, afp, b, ldb, x, ldx, fErr, bErr);
    }
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spptri")]
    public static extern int pptri(LapackLayout layout, LapackUpLo upLo, int n, float[] ap);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpptri")]
    public static extern int pptri(LapackLayout layout, LapackUpLo upLo, int n, double[] ap);
  }
}