namespace SharpMKLStd {
  public enum BlasLayout {
    RowMajor = 101,
    ColumnMajor = 102
  }

  public enum BlasTranspose {
    NoTrans = 111,
    Trans = 112,
    ConjTrans = 113
  }

  public enum BlasUpLo {
    Upper = 121,
    Lower = 122
  }

  public enum BlasDiag {
    Unit = 132,
    NonUnit = 131
  }

  public enum BlasSide {
    Left = 141,
    Right = 142
  }
}