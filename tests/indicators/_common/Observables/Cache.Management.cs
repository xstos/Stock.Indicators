namespace Tests.Common.Observables;

[TestClass]
public class CacheMgmtTests : TestBase
{
    [TestMethod]
    public void Analysis() => Assert.Inconclusive("test not implemented");

    [TestMethod]
    public void Purge() => Assert.Inconclusive("test not implemented");

    [TestMethod]
    public void Modify() => Assert.Inconclusive("test not implemented");

    [TestMethod]
    public void Overflowing()
    {
        // initialize
        QuoteHub<Quote> provider = new();
        Quote q = new() { Timestamp = DateTime.Now }; // dup

        Use<Quote> observer = provider
            .Use(CandlePart.Close);

        // overflowing, under threshold
        for (int i = 0; i <= 100; i++)
        {
            provider.Add(q);
        }

        provider.EndTransmission();

        // assert
        provider.Results.Should().HaveCount(1);
        observer.Results.Should().HaveCount(1);
        provider.IsFaulted.Should().BeFalse();
    }

    [TestMethod]
    public void Overflowed()
    {
        // initialize
        QuoteHub<Quote> provider = new();
        Quote q = new() { Timestamp = DateTime.Now }; // dup

        // overflowed, over threshold
        Assert.ThrowsException<OverflowException>(() => {

            for (int i = 0; i <= 101; i++)
            {
                provider.Add(q);
            }
        });

        provider.EndTransmission();

        // assert
        provider.Results.Should().HaveCount(1);
        provider.IsFaulted.Should().BeTrue();
    }

    [TestMethod]
    public void ActAddNew() => Assert.Inconclusive("test not implemented");

    [TestMethod]
    public void ActAddOld()  // late arrival
    {
        List<Quote> quotesList = Quotes
            .ToSortedList();

        int length = Quotes.Count();

        // add base quotes
        QuoteHub<Quote> provider = new();

        Use<Quote> observer = provider
            .Use(CandlePart.Close);

        // emulate incremental quotes
        for (int i = 0; i < length; i++)
        {
            // skip one
            if (i == 100)
            {
                continue;
            }

            Quote q = quotesList[i];
            provider.Add(q);
        }

        // add late
        provider.Add(quotesList[100]);

        // assert same as original
        for (int i = 0; i < length; i++)
        {
            Quote q = quotesList[i];
            Reusable r = observer.Cache[i];

            // compare quote to result cache
            r.Timestamp.Should().Be(q.Timestamp);
            r.Value.Should().Be((double)q.Close);
        }

        // close observations
        provider.EndTransmission();
    }

    [TestMethod]
    public void ActUpdate() => Assert.Inconclusive("test not implemented");

    [TestMethod]
    public void ActDelete() => Assert.Inconclusive("test not implemented");

    [TestMethod]
    public void ActDoNothing() => Assert.Inconclusive("test not implemented");
}
