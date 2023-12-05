namespace Skender.Stock.Indicators;

public sealed class SlopeResult : ResultBase, IReusableResult
{
    public double? Slope { get; set; }
    public double? Intercept { get; set; }
    public double? StdDev { get; set; }
    public double? RSquared { get; set; }
    public decimal? Line { get; set; } // last line segment only

    double IReusableResult.Value => Slope.Null2NaN();
}
