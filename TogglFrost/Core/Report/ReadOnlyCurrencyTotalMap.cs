using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TogglFrost.Core.Report {

    public class ReadOnlyCurrencyTotalMap : IReadOnlyCurrencyTotalMap, IDictionary<string, double> {

        private readonly ICurrencyTotalMap _currencyTotalMap;

        public double this[string currency] => GetTotal(currency);
                
        double IDictionary<string, double>.this[string key] {
            get => GetTotal(key);
            set => throw new NotSupportedException("Cannot set the elements in this collection. It is read-only.");
        }

        public IEnumerable<string> Currencies => _currencyTotalMap.Currencies;

        public IEnumerable<double> Totals => _currencyTotalMap.Totals;

        public int Count => _currencyTotalMap.Count;

        ICollection<string> IDictionary<string, double>.Keys => Currencies.ToArray();

        ICollection<double> IDictionary<string, double>.Values => Totals.ToArray();

        int ICollection<KeyValuePair<string, double>>.Count => Count;

        bool ICollection<KeyValuePair<string, double>>.IsReadOnly => true;

        public ReadOnlyCurrencyTotalMap(ICurrencyTotalMap currencyTotalMap) {

            _currencyTotalMap = currencyTotalMap ?? throw new ArgumentNullException(nameof(currencyTotalMap));

        }


        public double GetTotal(string currency) => _currencyTotalMap.GetTotal(currency);

        public bool HasTotal(string currency) => _currencyTotalMap.HasTotal(currency);

        public bool TryGetTotal(string currency, out double total) => _currencyTotalMap.TryGetTotal(currency, out total);

        bool IDictionary<string, double>.ContainsKey(string key) => HasTotal(key);

        void IDictionary<string, double>.Add(string key, double value) => throw new NotSupportedException("Cannot add elements to this collection. It is read-only.");

        bool IDictionary<string, double>.Remove(string key) => throw new NotSupportedException("Cannot remove any elements from this collection. It is read-only.");

        bool IDictionary<string, double>.TryGetValue(string key, out double value) => TryGetTotal(key, out value);

        void ICollection<KeyValuePair<string, double>>.Add(KeyValuePair<string, double> item) => throw new NotSupportedException("Cannot add elements to this collection. It is read-only.");

        void ICollection<KeyValuePair<string, double>>.Clear() => throw new NotSupportedException("Cannot clear the elements in this collection. It is read-only.");

        bool ICollection<KeyValuePair<string, double>>.Contains(KeyValuePair<string, double> item) => HasTotal(item.Key);

        public void CopyTo(KeyValuePair<string, double>[] array, int arrayIndex) => _currencyTotalMap.CopyTo(array, arrayIndex);

        bool ICollection<KeyValuePair<string, double>>.Remove(KeyValuePair<string, double> item) => throw new NotSupportedException("Cannot remove any elements from this collection. It is read-only.");

        public IEnumerator<KeyValuePair<string, double>> GetEnumerator() => _currencyTotalMap.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => $"Count: {Count}";

    }

}
