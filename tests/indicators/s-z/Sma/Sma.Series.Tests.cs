namespace Tests.Indicators;

[TestClass]
public class SmaSeriesTests : SeriesTestBase
{
    [TestMethod]
    public override void Standard()
    {
        List<SmaResult> results = quotes
            .GetSma(20)
            .ToList();

        // proper quantities
        Assert.AreEqual(502, results.Count);
        Assert.AreEqual(483, results.Count(x => x.Sma != null));

        // sample values
        Assert.IsNull(results[18].Sma);
        Assert.AreEqual(214.5250, results[19].Sma.Round(4));
        Assert.AreEqual(215.0310, results[24].Sma.Round(4));
        Assert.AreEqual(234.9350, results[149].Sma.Round(4));
        Assert.AreEqual(255.5500, results[249].Sma.Round(4));
        Assert.AreEqual(251.8600, results[501].Sma.Round(4));
    }

    [TestMethod]
    public void CandlePartOpen()
    {
        List<SmaResult> results = quotes
            .Use(CandlePart.Open)
            .GetSma(20)
            .ToList();

        Assert.AreEqual(502, results.Count);
        Assert.AreEqual(483, results.Count(x => x.Sma != null));

        // sample values
        Assert.IsNull(results[18].Sma);
        Assert.AreEqual(214.3795, results[19].Sma.Round(4));
        Assert.AreEqual(214.9535, results[24].Sma.Round(4));
        Assert.AreEqual(234.8280, results[149].Sma.Round(4));
        Assert.AreEqual(255.6915, results[249].Sma.Round(4));
        Assert.AreEqual(253.1725, results[501].Sma.Round(4));
    }

    [TestMethod]
    public void CandlePartVolume()
    {
        List<SmaResult> results = quotes
            .Use(CandlePart.Volume)
            .GetSma(20)
            .ToList();

        Assert.AreEqual(502, results.Count);
        Assert.AreEqual(483, results.Count(x => x.Sma != null));

        // sample values
        SmaResult r24 = results[24];
        Assert.AreEqual(77293768.2, r24.Sma);

        SmaResult r290 = results[290];
        Assert.AreEqual(157958070.8, r290.Sma);

        SmaResult r501 = results[501];
        Assert.AreEqual(DateTime.ParseExact("12/31/2018", "MM/dd/yyyy", EnglishCulture), r501.Timestamp);
        Assert.AreEqual(163695200, r501.Sma);
    }

    [TestMethod]
    public void Chainor()
    {
        List<EmaResult> results = quotes
            .GetSma(10)
            .GetEma(10)
            .ToList();

        Assert.AreEqual(502, results.Count);
        Assert.AreEqual(484, results.Count(x => x.Ema != null));
    }

    [TestMethod]
    public void TupleNaN()
    {
        List<SmaResult> r = tupleNanny
            .GetSma(6)
            .ToList();

        Assert.AreEqual(200, r.Count);
        Assert.AreEqual(0, r.Count(x => x.Sma is double and double.NaN));
    }

    [TestMethod]
    public void NaN()
    {
        List<SmaResult> r = TestData.GetBtcUsdNan()
            .GetSma(50)
            .ToList();

        Assert.AreEqual(0, r.Count(x => x.Sma is double and double.NaN));
    }

    [TestMethod]
    public override void BadData()
    {
        List<SmaResult> r = badQuotes
            .GetSma(15)
            .ToList();

        Assert.AreEqual(502, r.Count);
        Assert.AreEqual(0, r.Count(x => x.Sma is double and double.NaN));
    }

    [TestMethod]
    public override void NoQuotes()
    {
        List<SmaResult> r0 = noquotes
            .GetSma(5)
            .ToList();

        Assert.AreEqual(0, r0.Count);

        List<SmaResult> r1 = onequote
            .GetSma(5)
            .ToList();

        Assert.AreEqual(1, r1.Count);
    }

    [TestMethod]
    public void Removed()
    {
        List<SmaResult> results = quotes
            .GetSma(20)
            .RemoveWarmupPeriods()
            .ToList();

        // assertions
        Assert.AreEqual(502 - 19, results.Count);
        Assert.AreEqual(251.8600, results.LastOrDefault().Sma.Round(4));
    }

    [TestMethod]
    public override void Equality()
    {
        SmaResult r1 = new()
        {
            Timestamp = evalDate,
            Sma = 1d
        };

        SmaResult r2 = new()
        {
            Timestamp = evalDate,
            Sma = 1d
        };

        SmaResult r3 = new()
        {
            Timestamp = evalDate,
            Sma = 2d
        };

        Assert.IsTrue(Equals(r1, r2));
        Assert.IsFalse(Equals(r1, r3));

        Assert.IsTrue(r1.Equals(r2));
        Assert.IsFalse(r1.Equals(r3));

        Assert.IsTrue(r1 == r2);
        Assert.IsFalse(r1 == r3);

        Assert.IsFalse(r1 != r2);
        Assert.IsTrue(r1 != r3);
    }

    // bad lookback period
    [TestMethod]
    public void Exceptions()
        => Assert.ThrowsException<ArgumentOutOfRangeException>(()
            => quotes.GetSma(0));
}
