namespace Skender.Stock.Indicators;

public sealed record class WmaResult : IReusableResult
{
    public DateTime TickDate { get; set; }
    public double? Wma { get; set; }

    double IReusableResult.Value => Wma.Null2NaN();
}
