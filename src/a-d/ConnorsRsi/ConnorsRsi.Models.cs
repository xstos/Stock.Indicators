namespace Skender.Stock.Indicators;

public sealed class ConnorsRsiResult : ResultBase, IReusableResult
{
    public double? Rsi { get; set; }
    public double? RsiStreak { get; set; }
    public double? PercentRank { get; set; }
    public double? ConnorsRsi { get; set; }

    // internal use only
    internal double Streak { get; set; }
    double IReusableResult.Value => ConnorsRsi.Null2NaN();
}
