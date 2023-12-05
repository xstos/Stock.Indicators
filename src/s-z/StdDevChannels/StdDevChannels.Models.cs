namespace Skender.Stock.Indicators;

public sealed class StdDevChannelsResult : ResultBase
{
    public double? Centerline { get; set; }
    public double? UpperChannel { get; set; }
    public double? LowerChannel { get; set; }
    public bool BreakPoint { get; set; }
}
