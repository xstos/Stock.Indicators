namespace Skender.Stock.Indicators;

public class RenkoIncremental<TQuote> where TQuote : IQuote
{
    public Func<TQuote,int> PushQuote { get; set; }
    public List<RenkoResult> Bricks { get; set; }
}
