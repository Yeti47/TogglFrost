using System;
using System.Collections.Generic;
using System.Text;

namespace TogglFrost.Core {

    public class CustomRequestParameters : RequestParameters {

        #region Fields

        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        #endregion

        #region Props

        public IEnumerable<string> ParameterNames => _parameters.Keys;
        public IEnumerable<string> Values => _parameters.Values;

        public override string Query {

            get {

                StringBuilder queryBuilder = new StringBuilder();

                foreach (KeyValuePair<string, string> kvp in _parameters) {

                    queryBuilder.Append(Uri.EscapeUriString(kvp.Key));
                    queryBuilder.Append('=');
                    queryBuilder.Append(Uri.EscapeUriString(kvp.Value));
                    queryBuilder.Append(PARAMETER_DELIMITER);

                }

                if (queryBuilder.Length > 0)
                    queryBuilder.Length = queryBuilder.Length - 1;

                return queryBuilder.ToString();

            }

        }

        #endregion

        #region Ctors

        public CustomRequestParameters(IReadOnlyDictionary<string, string> parameters = null) {

            if(parameters != null) {

                foreach (KeyValuePair<string, string> kvp in parameters)
                    AddParameter(kvp.Key, kvp.Value);

            }

        }

        #endregion

        #region Methods
        
        public void AddParameter(string parameterName, string value) {

            if (string.IsNullOrWhiteSpace(parameterName))
                throw new ArgumentNullException(nameof(parameterName));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _parameters.Add(parameterName, value);

        }

        public bool HasParameter(string parameterName) => _parameters.ContainsKey(parameterName ?? throw new ArgumentNullException(nameof(parameterName)));

        public bool RemoveParameter(string parameterName) {

            if (string.IsNullOrWhiteSpace(parameterName))
                throw new ArgumentNullException(nameof(parameterName));

            return _parameters.Remove(parameterName);

        }

        public void Clear() => _parameters.Clear();

        public override string ToString() => Query;

        #endregion

    }
    
}
