using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TogglFrost.Core.Report {

    public abstract class CurrencyTotalMapBase : ICurrencyTotalMap, IReadOnlyCurrencyTotalMap {

        #region Fields

        protected readonly IDictionary<string, double> _totals = new Dictionary<string, double>();

        #endregion

        #region Indexers

        double IReadOnlyCurrencyTotalMap.this[string currency] => GetTotal(currency);

        #endregion

        #region Props

        public IEnumerable<string> Currencies => _totals.Keys;
        public IEnumerable<double> Totals => _totals.Values;

        public int Count => _totals.Count;

        #endregion

        #region Ctors

        protected CurrencyTotalMapBase(IDictionary<string, double> totalMap = null) {

            if(totalMap != null) {

                foreach (var kvp in totalMap.Where(x => !HasTotal(x.Key)))
                    _totals.Add(kvp.Key, kvp.Value);
               
            }

        }

        #endregion

        #region Methods

        public bool HasTotal(string currency) => _totals.ContainsKey(currency ?? throw new ArgumentNullException(nameof(currency)));

        public double GetTotal(string currency) {

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentNullException(nameof(currency));

            if (!HasTotal(currency))
                throw new IndexOutOfRangeException();

            return _totals[currency];

        }

        public bool TryGetTotal(string currency, out double total) {

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentNullException(nameof(currency));

            bool hasTotal = HasTotal(currency);

            total = hasTotal ? _totals[currency] : 0;

            return hasTotal;
            
        }

        public void CopyTo(KeyValuePair<string, double>[] array, int arrayIndex) => _totals.CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<string, double>> GetEnumerator() => _totals.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => $"Count: {Count}";
        
        #endregion


    }

    
}