using SharpMKLStd.Native;

namespace SharpMKLStd {
  public static class Blas1 {
    public static float asum(float[] x) => NativeBlas1.sasum(x.Length, x, 1);
    public static double asum(double[] x) => NativeBlas1.dasum(x.Length, x, 1);

    public static void axpy(float a, float[] x, float[] y) => NativeBlas1.saxpy(x.Length, a, x, 1, y, 1);
    public static void axpy(double a, double[] x, double[] y) => NativeBlas1.daxpy(x.Length, a, x, 1, y, 1);
  }
}