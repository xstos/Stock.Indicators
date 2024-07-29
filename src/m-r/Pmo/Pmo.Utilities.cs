namespace Skender.Stock.Indicators;

public static partial class Indicator
{
    // remove recommended periods
    /// <inheritdoc cref="Utility.RemoveWarmupPeriods{T}(IEnumerable{T})"/>
    public static IReadOnlyList<PmoResult> RemoveWarmupPeriods(
        this IEnumerable<PmoResult> results)
    {
        int ts = results
            .ToList()
            .FindIndex(x => x.Pmo != null) + 1;

        return results.Remove(ts + 250);
    }
}
