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

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spoequb")]
    public static extern int poequb(LapackLayout Layout, int n, float[] a, int lda,
                                    float[] s, out float sCond, out float aMax);
    public static int poequb(LapackLayout Layout, int n, float[] a, int lda,
                             out float[]  s, out float sCond, out float aMax) {
      s = new float[n];
      return poequb(Layout, n, a, lda, s, out sCond, out aMax);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpoequb")]
    public static extern int poequb(LapackLayout Layout, int n, double[] a, int lda,
                                    double[] s, out double sCond, out double aMax);
    public static int poequb(LapackLayout Layout, int n, double[] a, int lda,
                             out double[]  s, out double sCond, out double aMax) {
      s = new double[n];
      return poequb(Layout, n, a, lda, s, out sCond, out aMax);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_spocon")]
    public static extern int pocon(LapackLayout Layout, LapackUpLo UpLo, int n,
                                   float[] a, int lda, float aNorm, out float rCond);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dpocon")]
    public static extern int pocon(LapackLayout Layout, LapackUpLo UpLo, int n,
                                   double[] a, int lda, double aNomr, out double rCond);

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sporfs")]
    public static extern int porfs(LapackLayout Layout, LapackUpLo UpLo, int n, int nrhs,
                                   float[] a, int lda, float[] af, int ldaf,
                                   float[] b, int ldb, float[] x, int ldx,
                                   float[] fErr, float[] bErr);
    public static int porfs(LapackLayout Layout, LapackUpLo UpLo, int n, int nrhs,
                            float[] a, int lda, float[] af, int ldaf,
                            float[] b, int ldb, float[] x, int ldx,
                            out float[] fErr, out float[] bErr) {
      fErr = new float[nrhs > 1 ? nrhs : 1];
      bErr = new float[nrhs > 1 ? nrhs : 1];
      return porfs(Layout, UpLo, n, nrhs, a, lda, af, ldaf, b, ldb, x, ldx, fErr, bErr);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dporfs")]
    public static extern int porfs(LapackLayout Layout, LapackUpLo UpLo, int n, int nrhs,
                                   double[] a, int lda, double[] af, int ldaf,
                                   double[] b, int ldb, double[] x, int ldx,
                                   double[] fErr, double[] bErr);
    public static int porfs(LapackLayout Layout, LapackUpLo UpLo, int n, int nrhs,
                            double[] a, int lda, double[] af, int ldaf,
                            double[] b, int ldb, double[] x, int ldx,
                            out double[] fErr, out double[] bErr) {
      fErr = new double[nrhs > 1 ? nrhs : 1];
      bErr = new double[nrhs > 1 ? nrhs : 1];
      return porfs(Layout, UpLo, n, nrhs, a, lda, af, ldaf, b, ldb, x, ldx, fErr, bErr);
    }

    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sporfsx")]
    public static extern int porfsx(LapackLayout Layout, LapackTranspose Transpose, LapackEquil Equed, int n, int nrhs,
                                    float[] a, int lda, float[] af, int ldaf, float[] s,
                                    float[] b, int ldb, float[] x, int ldx,
                                    out float rCond, float[] bErr,
                                    int nErrBnds, float[] errBndsNorm, float[] errBndsConp,
                                    int nParams, float[] Params);
    public static int porfsx(LapackLayout Layout, LapackTranspose Transpose, LapackEquil Equed, int n, int nrhs,
                             float[] a, int lda, float[] af, int ldaf, float[] s,
                             float[] b, int ldb, float[] x, int ldx,
                             out float rCond, out float[] bErr,
                             int nErrBnds, out float[] errBndsNorm, out float[] errBndsConp,
                             int nParams, float[] Params) {
      bErr = new float[nrhs > 1 ? nrhs : 1];
      errBndsNorm = new float[nrhs * nErrBnds];
      errBndsConp = new float[nrhs * nErrBnds];
      return porfsx(Layout, Transpose, Equed,
                    n, nrhs, a, lda, af, ldaf,
                    s, b, ldb, x, ldx, out rCond, bErr,
                    nErrBnds, errBndsNorm, errBndsConp, nParams, Params);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dporfsx")]
    public static extern int porfsx(LapackLayout Layout, LapackTranspose Transpose, LapackEquil Equed, int n, int nrhs,
                                    double[] a, int lda, double[] af, int ldaf, double[] s,
                                    double[] b, int ldb, double[] x, int ldx,
                                    out double rCond, double[] bErr,
                                    int nErrBnds, double[] errBndsNorm, double[] errBndsConp,
                                    int nParams, double[] Params);
    public static int porfsx(LapackLayout Layout, LapackTranspose Transpose, LapackEquil Equed, int n, int nrhs,
                             double[] a, int lda, double[] af, int ldaf, double[] s,
                             double[] b, int ldb, double[] x, int ldx,
                             out double rCond, out double[] bErr,
                             int nErrBnds, out double[] errBndsNorm, out double[] errBndsConp,
                             int nParams, double[] Params) {
      bErr = new double[nrhs > 1 ? nrhs : 1];
      errBndsNorm = new double[nrhs * nErrBnds];
      errBndsConp = new double[nrhs * nErrBnds];
      return porfsx(Layout, Transpose, Equed,
                    n, nrhs, a, lda, af, ldaf,
                    s, b, ldb, x, ldx, out rCond, bErr,
                    nErrBnds, errBndsNorm, errBndsConp, nParams, Params);
    }
  }
}