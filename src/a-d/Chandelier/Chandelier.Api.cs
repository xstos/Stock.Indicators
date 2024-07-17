namespace Skender.Stock.Indicators;

// CHANDELIER EXIT (API)
public static partial class Indicator
{
    // SERIES, from TQuote
    /// <include file='./info.xml' path='info/*' />
    ///
    public static IReadOnlyList<ChandelierResult> GetChandelier<TQuote>(
        this IEnumerable<TQuote> quotes,
        int lookbackPeriods = 22,
        double multiplier = 3,
        ChandelierType type = ChandelierType.Long)
        where TQuote : IQuote => quotes
            .ToQuoteDList()
            .CalcChandelier(lookbackPeriods, multiplier, type);
}
