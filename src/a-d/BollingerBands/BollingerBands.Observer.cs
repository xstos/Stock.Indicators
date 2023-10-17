namespace Skender.Stock.Indicators;

// BOLLINGER BANDS (STREAMING)

public partial class BollingerBands : ChainProvider
{
    // TBD constructor
    public BollingerBands()
    {
        Initialize();
    }

    // TBD PROPERTIES

    // STATIC METHODS

    // parameter validation
    internal static void Validate(
        int lookbackPeriods,
        double standardDeviations)
    {
        // check parameter arguments
        if (lookbackPeriods <= 1)
        {
            throw new ArgumentOutOfRangeException(nameof(lookbackPeriods), lookbackPeriods,
                "Lookback periods must be greater than 1 for Bollinger Bands.");
        }

        if (standardDeviations <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(standardDeviations), standardDeviations,
                "Standard Deviations must be greater than 0 for Bollinger Bands.");
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
