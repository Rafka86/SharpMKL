using System;
using System.Collections.Generic;
using System.Numerics;

using SharpMKL;

namespace PerformanceTest {

  class DataGenerator {
    private readonly IEnumerator<uint> _r;

    internal DataGenerator() {
      var w = (uint) Environment.TickCount;
      var x = w << 13;
      var y = (w >> 9) ^ (w << 6);
      var z = y >> 7;
      _r = RandGen();

      IEnumerator<uint> RandGen() {
        uint t;
        while (true) {
          t = x ^ (x << 11);
          x = y;
          y = z;
          z = w;
          yield return w = w ^ (w >> 19) ^ t ^ (t >> 8);
        }
        // ReSharper disable once IteratorNeverReturns
      }
    }

    internal uint Rand {
      get {
        _r.MoveNext();
        return _r.Current;
      }
    }

    internal int RandInt(int min = 0, int max = 0x7fffffff) => (int) (Rand % (max - min + 1)) + min;

    internal float RandFloat(float min = 0.0f, float max = 1.0f)
      => (float) (Rand % 0xffff) / 0xffff * (max - min) + min;

    internal double RandDouble(double min = 0.0, double max = 1.0)
      => (double) (Rand % 0xffff) / 0xffff * (max - min) + min;

    internal ComplexF RandComplexF(float min = 0.0f, float max = 1.0f)
      => new ComplexF(RandFloat(min, max), RandFloat(min, max));

    internal Complex RandComplex(double min = 0.0, double max = 1.0)
      => new Complex(RandDouble(min, max), RandDouble(min, max));

    internal int[] IntArray(int min = 0, int max = 0x7fffffff, int size = 1) {
      var res = new int[size];
      for (var i = 0; i < res.Length; i++)
        res[i] = RandInt(min, max);
      return res;
    }

    internal float[] FloatArray(float min = 0.0f, float max = 1.0f, int size = 1) {
      var res = new float[size];
      for (var i = 0; i < res.Length; i++)
        res[i] = RandFloat(min, max);
      return res;
    }

    internal double[] DoubleArray(double min = 0.0, double max = 1.0, int size = 1) {
      var res = new double[size];
      for (var i = 0; i < res.Length; i++)
        res[i] = RandDouble(min, max);
      return res;
    }

    internal ComplexF[] ComplexFArray(float min = 0.0f, float max = 1.0f, int size = 1) {
      var res = new ComplexF[size];
      for (var i = 0; i < res.Length; i++)
        res[i] = RandComplexF(min, max);
      return res;
    }

    internal Complex[] ComplexArray(double min = 0.0, double max = 1.0, int size = 1) {
      var res = new Complex[size];
      for (var i = 0; i < res.Length; i++)
        res[i] = RandComplex(min, max);
      return res;
    }
  }

}