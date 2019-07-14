namespace TogglFrost.Core.Report {
    public interface IReadOnlyCurrencyTotalMap : ICurrencyTotalMap {

        double this[string currency] { get; }
        
    }

}