namespace Skender.Stock.Indicators;

public static partial class Indicator
{
    // remove recommended periods
    /// <inheritdoc cref="Utility.RemoveWarmupPeriods{T}(IEnumerable{T})"/>
    public static IReadOnlyList<ChopResult> RemoveWarmupPeriods(
        this IEnumerable<ChopResult> results)
    {
        int removePeriods = results
           .ToList()
           .FindIndex(x => x.Chop != null);

        return results.Remove(removePeriods);
    }
}
