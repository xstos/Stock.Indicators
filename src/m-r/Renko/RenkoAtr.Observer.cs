namespace Skender.Stock.Indicators;

// RENKO CHART - ATR (STREAMING)

public partial class RenkoAtr : ChainProvider
{
    // TBD constructor
    public RenkoAtr()
    {
        Initialize();
    }

    // TBD PROPERTIES

    // STATIC METHODS

    // TBD increment calculation
    internal static double Increment() => throw new NotImplementedException();

    // NON-STATIC METHODS

    // handle quote arrival
    public override void OnNext((DateTime Date, double Value) value) => Add(value);

    // TBD add new tuple quote
    internal void Add((DateTime Date, double Value) tp) => throw new NotImplementedException();

    // TBD initialize with existing quote cache
    private void Initialize() => throw new NotImplementedException();
}
