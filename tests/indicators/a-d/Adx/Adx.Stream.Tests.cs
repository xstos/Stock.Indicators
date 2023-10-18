using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skender.Stock.Indicators;
using Tests.Common;

namespace Tests.Indicators;

[TestClass]
public class AdlStreamTests : TestBase
{
    [TestMethod]
    public void Manual()
    {
        List<Quote> quotesList = quotes
            .ToSortedList();

        int length = quotesList.Count;

        // initialize
        Adl adl = new();

        // roll through history
        for (int i = 0; i < length; i++)
        {
            adl.Increment(quotesList[i]);
        }

        // results
        List<AdlResult> resultList = adl.ProtectedResults;

        // time-series, for comparison
        List<AdlResult> seriesList = quotes
            .GetAdl()
            .ToList();

        // assert, should equal series
        for (int i = 0; i < seriesList.Count; i++)
        {
            AdlResult s = seriesList[i];
            AdlResult r = resultList[i];

            Assert.AreEqual(s.Date, r.Date);
            Assert.AreEqual(s.MoneyFlowMultiplier, r.MoneyFlowMultiplier);
            Assert.AreEqual(s.MoneyFlowVolume, r.MoneyFlowVolume);
            Assert.AreEqual(s.Adl, r.Adl);
        }
    }
}
