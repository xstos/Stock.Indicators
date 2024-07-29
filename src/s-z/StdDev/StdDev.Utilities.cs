namespace Skender.Stock.Indicators;

public static partial class Indicator
{
    // remove recommended periods
    /// <inheritdoc cref="Utility.RemoveWarmupPeriods{T}(IEnumerable{T})"/>
    public static IReadOnlyList<StdDevResult> RemoveWarmupPeriods(
        this IEnumerable<StdDevResult> results)
    {
        int removePeriods = results
            .ToList()
            .FindIndex(x => x.StdDev != null);

        return results.Remove(removePeriods);
    }
}
