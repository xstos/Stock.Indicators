namespace Skender.Stock.Indicators;

// SMOOTHED MOVING AVERAGE (COMMON)

public static class Smma
{
    // parameter validation
    internal static void Validate(
        int lookbackPeriods)
    {
        // check parameter arguments
        if (lookbackPeriods <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lookbackPeriods), lookbackPeriods,
                "Lookback periods must be greater than 0 for SMMA.");
        }
    }

}
