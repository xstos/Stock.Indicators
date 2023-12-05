namespace Skender.Stock.Indicators;

public sealed class ElderRayResult : ResultBase, IReusableResult
{
    public double? Ema { get; set; }
    public double? BullPower { get; set; }
    public double? BearPower { get; set; }

    double IReusableResult.Value => (BullPower + BearPower).Null2NaN();
}
