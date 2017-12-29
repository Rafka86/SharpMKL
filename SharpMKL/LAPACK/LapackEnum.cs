namespace SharpMKL {
  public enum LapackLayout {
    RowMajor = 101,
    ColumnMajor = 102
  }

  public enum LapackTranspose {
    NoTrans = 78,
    Trans = 84,
    ConjTrans = 67
  }

  public enum LapackNorm {
    One = 49,
    Infinity = 73
  }

  public enum LapackEquil {
    NoEquil = 78,
    Row = 82,
    Column = 67,
    Both = 66
  }

  public enum LapackUpLo {
    Upper = 85,
    Lower = 76
  }
}