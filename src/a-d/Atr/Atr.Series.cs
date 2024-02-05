namespace Skender.Stock.Indicators;

// AVERAGE TRUE RANGE (SERIES)

public static partial class Indicator
{
    // calculate series
    internal static List<AtrResult> CalcAtr(
        this List<QuoteD> qdList,
        int lookbackPeriods)
    {
        // check parameter arguments
        Atr.Validate(lookbackPeriods);

        // initialize
        List<AtrResult> results = new(qdList.Count);
        double prevAtr = double.NaN;
        double prevClose = double.NaN;
        double sumTr = 0;

        // roll through quotes
        for (int i = 0; i < qdList.Count; i++)
        {
            double hmpc;
            double lmpc;
            QuoteD q = qdList[i];

            AtrResult r = new() { Timestamp = q.Timestamp };
            results.Add(r);

            if (i > 0)
            {
                hmpc = Math.Abs(q.High - prevClose);
                lmpc = Math.Abs(q.Low - prevClose);
            }
            else
            {
                prevClose = q.Close;
                continue;
            }

            double tr = Math.Max(q.High - q.Low, Math.Max(hmpc, lmpc));
            r.Tr = tr;

            if (i > lookbackPeriods)
            {
                // calculate ATR
                double atr = ((prevAtr * (lookbackPeriods - 1)) + tr) / lookbackPeriods;
                r.Atr = atr;
                r.Atrp = (q.Close == 0) ? null : atr / q.Close * 100;
                prevAtr = atr;
            }

            // TODO: update healing, without requiring specific indexing
            else if (i == lookbackPeriods)
            {
                // initialize ATR
                sumTr += tr;
                double atr = sumTr / lookbackPeriods;
                r.Atr = atr;
                r.Atrp = (q.Close == 0) ? null : atr / q.Close * 100;
                prevAtr = atr;
            }
            else
            {
                // only used for periods before ATR initialization
                sumTr += tr;
            }

            prevClose = q.Close;
        }

        return results;
    }
}
