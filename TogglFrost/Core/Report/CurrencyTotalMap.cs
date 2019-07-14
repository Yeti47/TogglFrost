using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TogglFrost.Core.Report {

    public class CurrencyTotalMap : CurrencyTotalMapBase, IMutableCurrencyTotalMap, IDictionary<string, double> {

        #region Fields

        #endregion

        #region Indexers

        public double this[string currency] {

            get => GetTotal(currency);
            set => SetTotal(currency, value);
            
        }

        double IDictionary<string, double>.this[string key] {
            get => this[key];
            set => this[key] = value;
        }

        #endregion

        #region Props

        ICollection<string> IDictionary<string, double>.Keys => Currencies.ToArray();

        ICollection<double> IDictionary<string, double>.Values => Totals.ToArray();

        int ICollection<KeyValuePair<string, double>>.Count => _totals.Count;

        bool ICollection<KeyValuePair<string, double>>.IsReadOnly => false;

        #endregion

        #region Ctors

        public CurrencyTotalMap(IDictionary<string, double> totalMap = null) : base(totalMap) {

        }

        #endregion

        #region Methods

        public void SetTotal(string currency, double total) {

            if (!HasTotal(currency))
                throw new IndexOutOfRangeException();

            _totals[currency] = total;

        }

        public void AddTotal(string currency, double total) {

            if (HasTotal(currency))
                throw new ArgumentException($"The collection already contains the currency {currency}.");

            _totals.Add(currency, total);

        }

        public bool RemoveTotal(string currency) {

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentNullException(nameof(currency));

            return _totals.Remove(currency);

        }

        public void Clear() => _totals.Clear();

        bool IDictionary<string, double>.ContainsKey(string key) => HasTotal(key);

        void IDictionary<string, double>.Add(string key, double value) => AddTotal(key, value);

        bool IDictionary<string, double>.Remove(string key) => RemoveTotal(key);

        bool IDictionary<string, double>.TryGetValue(string key, out double value) => TryGetTotal(key, out value);

        void ICollection<KeyValuePair<string, double>>.Add(KeyValuePair<string, double> item) => AddTotal(item.Key, item.Value);

        void ICollection<KeyValuePair<string, double>>.Clear() => Clear();

        bool ICollection<KeyValuePair<string, double>>.Contains(KeyValuePair<string, double> item) => HasTotal(item.Key);

        bool ICollection<KeyValuePair<string, double>>.Remove(KeyValuePair<string, double> item) => RemoveTotal(item.Key);

        #endregion

    }

}
