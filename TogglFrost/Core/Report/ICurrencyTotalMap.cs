using System.Collections.Generic;

namespace TogglFrost.Core.Report {

    public interface ICurrencyTotalMap : IEnumerable<KeyValuePair<string, double>> { 

        IEnumerable<string> Currencies { get; }
        IEnumerable<double> Totals { get; }

        int Count { get; }

        double GetTotal(string currency);
        bool HasTotal(string currency);
        bool TryGetTotal(string currency, out double total);

        void CopyTo(KeyValuePair<string, double>[] array, int arrayIndex);
        
    }

}