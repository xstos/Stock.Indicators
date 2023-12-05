namespace Skender.Stock.Indicators;

public sealed class AwesomeResult : ResultBase, IReusableResult
{
    public double? Oscillator { get; set; }
    public double? Normalized { get; set; }

    double IReusableResult.Value => Oscillator.Null2NaN();
}
