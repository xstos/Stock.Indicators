using System.Collections.ObjectModel;

namespace Tests.Common;

[TestClass]
public class Results : SeriesTestBase
{
    [TestMethod]
    public void Condense()
    {
        List<AdxResult> x = quotes
            .GetAdx(14)
            .ToList();

        // make a few more in the middle null and NaN
        x[249].Adx = null;
        x[345].Adx = double.NaN;

        List<AdxResult> r = x.Condense().ToList();

        // proper quantities
        Assert.AreEqual(473, r.Count);

        // sample values
        AdxResult last = r.LastOrDefault();
        Assert.AreEqual(17.7565, last.Pdi.Round(4));
        Assert.AreEqual(31.1510, last.Mdi.Round(4));
        Assert.AreEqual(34.2987, last.Adx.Round(4));
    }

    [TestMethod]
    public void ToTuple()
    {
        // baseline for comparison
        List<SmaResult> baseline =
        [
            new SmaResult() { TickDate = DateTime.Parse("1/1/2000", EnglishCulture), Sma = null },
            new SmaResult() { TickDate = DateTime.Parse("1/2/2000", EnglishCulture), Sma = null },
            new SmaResult() { TickDate = DateTime.Parse("1/3/2000", EnglishCulture), Sma = 3 },
            new SmaResult() { TickDate = DateTime.Parse("1/4/2000", EnglishCulture), Sma = 4 },
            new SmaResult() { TickDate = DateTime.Parse("1/5/2000", EnglishCulture), Sma = 5 },
            new SmaResult() { TickDate = DateTime.Parse("1/6/2000", EnglishCulture), Sma = 6 },
            new SmaResult() { TickDate = DateTime.Parse("1/7/2000", EnglishCulture), Sma = 7 },
            new SmaResult() { TickDate = DateTime.Parse("1/8/2000", EnglishCulture), Sma = double.NaN },
            new SmaResult() { TickDate = DateTime.Parse("1/9/2000", EnglishCulture), Sma = null }
        ];

        // default chainable NaN with pruning (internal)
        List<(DateTime TickDate, double Value)> chainableTuple = baseline
            .ToTupleResult();

        Assert.AreEqual(5, chainableTuple.Count(x => !double.IsNaN(x.Value)));
        Assert.AreEqual(4, chainableTuple.Count(x => double.IsNaN(x.Value)));

        // PUBLIC VARIANT

        // default chainable NaN with pruning
        Collection<(DateTime TickDate, double Value)> cnaNresults = baseline
            .ToTupleChainable();

        Assert.AreEqual(5, cnaNresults.Count(x => !double.IsNaN(x.Value)));
        Assert.AreEqual(4, cnaNresults.Count(x => double.IsNaN(x.Value)));

        // with NaN option, no pruning
        List<(DateTime TickDate, double Value)> nanResults = baseline
            .ToTupleResult();

        Assert.AreEqual(4, nanResults.Count(x => x.Value is double.NaN));
        Assert.AreEqual(9, nanResults.Count);
    }
}
