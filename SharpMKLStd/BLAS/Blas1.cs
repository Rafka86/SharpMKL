using SharpMKLStd.Native;

namespace SharpMKLStd {
  public static class Blas1 {
    public static float asum(float[] x) => NativeBlas1.sasum(x.Length, x, 1);
    public static double asum(double[] x) => NativeBlas1.dasum(x.Length, x, 1);

    public static void axpy(float a, float[] x, float[] y) => NativeBlas1.saxpy(x.Length, a, x, 1, y, 1);
    public static void axpy(double a, double[] x, double[] y) => NativeBlas1.daxpy(x.Length, a, x, 1, y, 1);

    public static void copy(float[] x, float[] y) => NativeBlas1.scopy(x.Length, x, 1, y, 1);
    public static void copy(float[] x, out float[] y) {
      y = new float[x.Length];
      NativeBlas1.scopy(x.Length, x, 1, y, 1);
    }
    public static void copy(double[] x, double[] y) => NativeBlas1.dcopy(x.Length, x, 1, y, 1);
    public static void copy(double[] x, out double[] y) {
      y = new double[x.Length];
      NativeBlas1.dcopy(x.Length, x, 1, y, 1);
    }
  }
}