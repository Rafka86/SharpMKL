using System.Numerics;
using System.Runtime.InteropServices;

namespace SharpMKL {

  [StructLayout(LayoutKind.Sequential)]
  public struct ComplexF {
    public float Real { get; set; }
    public float Imaginary { get; set; }

    public ComplexF(float real, float imag) {
      Real = real;
      Imaginary = imag;
    }

    public ComplexF((float real, float imag) value) : this(value.real, value.imag) {}

    public override bool Equals(object obj) => ((Complex) this).Equals(obj);

    public override int GetHashCode() => ((Complex) this).GetHashCode();

    public override string ToString() => ((Complex) this).ToString();

    public static implicit operator Complex(ComplexF cf) => new Complex(cf.Real, cf.Imaginary);

    public static explicit operator ComplexF(Complex c) => new ComplexF((float) c.Real, (float) c.Imaginary);
  }

}