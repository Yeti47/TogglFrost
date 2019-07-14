namespace TogglFrost.Core.Report {

    public interface IMutableCurrencyTotalMap : ICurrencyTotalMap {

        double this[string currency] { get; set; }

        void SetTotal(string currency, double total);
        void AddTotal(string currency, double total);

    }

}