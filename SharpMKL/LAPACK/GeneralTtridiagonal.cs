using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace SharpMKL {
  public static partial class Lapack {
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgttrf")]
    public static extern int gttrf(int n, float[] dl, float[] d, float[] du, float[] du2, int[] ipiv);
    public static int Gttrf(int n, float[] dl, float[] d, float[] du, out float[] du2, out int[] ipiv) {
      du2 = new float[n - 2];
      ipiv = new int[n];
      return gttrf(n, dl, d, du, du2, ipiv);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgttrf")]
    public static extern int gttrf(int n, double[] dl, double[] d, double[] du, double[] du2, int[] ipiv);
    public static int Gttrf(int n, double[] dl, double[] d, double[] du, out double[] du2, out int[] ipiv) {
      du2 = new double[n - 2];
      ipiv = new int[n];
      return gttrf(n, dl, d, du, du2, ipiv);
    }
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgttrs")]
    public static extern int gttrs(LapackLayout layout, LapackTranspose trans, int n, int nrhs,
                                   float[] dl, float[] d, float[] du, float[] du2, int[] ipiv,
                                   float[] b, int ldb);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgttrs")]
    public static extern int gttrs(LapackLayout layout, LapackTranspose trans, int n, int nrhs,
                                   double[] dl, double[] d, double[] du, double[] du2, int[] ipiv,
                                   float[] b, int ldb);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgtcon")]
    public static extern int gtcon(LapackNorm norm, int n,
                                   float[] dl, float[] d, float[] du, float[] du2, int[] ipiv,
                                   float aNorm, out float rCond);
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgtcon")]
    public static extern int gtcon(LapackNorm norm, int n,
                                   double[] dl, double[] d, double[] du, double[] du2, int[] ipiv,
                                   float aNorm, out float rCond);
    
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_sgtrfs")]
    public static extern int gtrfs(LapackLayout layout, LapackTranspose trans, int n, int nrhs,
                                   float[] dl, float[] d, float[] du, float[] dlf, float[] df, float[] duf,
                                   float[] du2, int[] ipiv, float[] b, int ldb, float[] x, int ldx,
                                   float[] fErr, float[] bErr);
    public static int Gtrfs(LapackLayout layout, LapackTranspose trans, int n, int nrhs,
                            float[] dl, float[] d, float[] du, float[] dlf, float[] df, float[] duf,
                            float[] du2, int[] ipiv, float[] b, int ldb, float[] x, int ldx,
                            out float[] fErr, out float[] bErr) {
      fErr = new float[nrhs > 1 ? nrhs : 1];
      bErr = new float[nrhs > 1 ? nrhs : 1];
      return gtrfs(layout, trans, n, nrhs, dl, d, du, dlf, df, duf, du2, ipiv, b, ldb, x, ldx, fErr, bErr);
    }
    [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "LAPACKE_dgtrfs")]
    public static extern int gtrfs(LapackLayout layout, LapackTranspose trans, int n, int nrhs,
                                   double[] dl, double[] d, double[] du, double[] dlf, double[] df, double[] duf,
                                   double[] du2, int[] ipiv, double[] b, int ldb, double[] x, int ldx,
                                   double[] fErr, double[] bErr);
    public static int Gtrfs(LapackLayout layout, LapackTranspose trans, int n, int nrhs,
                            double[] dl, double[] d, double[] du, double[] dlf, double[] df, double[] duf,
                            double[] du2, int[] ipiv, double[] b, int ldb, double[] x, int ldx,
                            out double[] fErr, out double[] bErr) {
      fErr = new double[nrhs > 1 ? nrhs : 1];
      bErr = new double[nrhs > 1 ? nrhs : 1];
      return gtrfs(layout, trans, n, nrhs, dl, d, du, dlf, df, duf, du2, ipiv, b, ldb, x, ldx, fErr, bErr);
    }
  }
}