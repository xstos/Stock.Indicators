namespace Skender.Stock.Indicators;

// REMOVE AND PRUNING of SERIES
public static class Pruning
{
    // REMOVE SPECIFIC PERIODS
    public static IReadOnlyList<T> RemoveWarmupPeriods<T>(
        this IEnumerable<T> series,
        int removePeriods)
        => removePeriods < 0
            ? throw new ArgumentOutOfRangeException(nameof(removePeriods), removePeriods,
                "If specified, the Remove Periods value must be greater than or equal to 0.")
            : series.Remove(removePeriods);

    // REMOVE PERIODS
    internal static List<T> Remove<T>(
        this IEnumerable<T> series,
        int removePeriods)
    {
        List<T> seriesList = series.ToList();

        if (seriesList.Count <= removePeriods)
        {
            return [];
        }

        if (removePeriods <= 0)
        {
            return seriesList;
        }

        for (int i = 0; i < removePeriods; i++)
        {
            seriesList.RemoveAt(0);
        }

        return seriesList;
    }
}
