namespace Skender.Stock.Indicators;

public sealed class DonchianResult : ResultBase
{
    public decimal? UpperBand { get; set; }
    public decimal? Centerline { get; set; }
    public decimal? LowerBand { get; set; }
    public decimal? Width { get; set; }
}
