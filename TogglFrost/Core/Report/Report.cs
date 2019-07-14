using System;

namespace TogglFrost.Core.Report {

    public abstract class Report : ICurrencyTotalCalculator {

        public abstract ReadOnlyCurrencyTotalMap TotalCurrencies { get; }

        public abstract long TotalGrand { get; }
        public abstract long TotalBillable { get; }


    }

}
