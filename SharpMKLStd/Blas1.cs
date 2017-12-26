using SharpMKLStd.Native;

namespace SharpMKLStd {
  public static class Blas1 {
    public static float asum(float[] x) => NativeBlas1.sasum(x.Length, x, 1);
    public static double asum(double[] x) => NativeBlas1.dasum(x.Length, x, 1);
  }
}