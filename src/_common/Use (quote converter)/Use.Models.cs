namespace Skender.Stock.Indicators;

// TODO: this is redundant to "BasicResult", but it has a funny name
public sealed record class UseResult : IReusableResult
{
    public DateTime TickDate { get; set; }
    public double Value { get; set; }
}
