namespace Skender.Stock.Indicators;

// STANDARD DEVIATION (STREAMING)

public partial class StdDev : ChainProvider
{
    // TBD constructor
    public StdDev()
    {
        Initialize();
    }

    // TBD PROPERTIES

    // STATIC METHODS

    // parameter validation
    internal static void Validate(
        int lookbackPeriods,
        int? smaPeriods)
    {
        // check parameter arguments
        if (lookbackPeriods <= 1)
        {
            throw new ArgumentOutOfRangeException(nameof(lookbackPeriods), lookbackPeriods,
                "Lookback periods must be greater than 1 for Standard Deviation.");
        }

        if (smaPeriods is not null and <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(smaPeriods), smaPeriods,
                "SMA periods must be greater than 0 for Standard Deviation.");
        }
    }

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
