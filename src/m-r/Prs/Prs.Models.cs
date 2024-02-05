namespace Skender.Stock.Indicators;

public sealed record class PrsResult : IReusableResult
{
    public DateTime Timestamp { get; set; }
    public double? Prs { get; set; }
    public double? PrsPercent { get; set; }

    [Obsolete("Use a chained `results.GetSma(smaPeriods)` to generate a moving average signal.", false)]
    public double? PrsSma { get; set; }

    double IReusableResult.Value => Prs.Null2NaN();
}
