namespace Skender.Stock.Indicators;

public sealed record class MaEnvelopeResult : IResult
{
    public DateTime TickDate { get; set; }
    public double? Centerline { get; set; }
    public double? UpperEnvelope { get; set; }
    public double? LowerEnvelope { get; set; }
}
