using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TogglFrost.Core {

    public class CompositeRequestParameters : RequestParameters, IEnumerable<IRequestParameters> {

        #region Fields

        private readonly List<IRequestParameters> _requestParameters = new List<IRequestParameters>();

        #endregion

        #region Props

        public override string Query {

            get {

                StringBuilder queryBuilder = new StringBuilder();

                foreach(IRequestParameters reqParams in _requestParameters) {

                    queryBuilder.Append(reqParams.Query);
                    queryBuilder.Append(PARAMETER_DELIMITER);

                }

                if (queryBuilder.Length > 0)
                    queryBuilder.Length--;

                return queryBuilder.ToString();
                
            }
            
        }

        #endregion

        #region Ctors

        public CompositeRequestParameters(IRequestParameters requestParameters) {

            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            Append(requestParameters);

        }

        public CompositeRequestParameters(IEnumerable<IRequestParameters> requestParameters = null) {

            if(requestParameters != null) {

                foreach (IRequestParameters reqParams in requestParameters)
                    Append(reqParams);

            }

        }

        #endregion

        #region Methods

        public IEnumerator<IRequestParameters> GetEnumerator() => _requestParameters.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override IRequestParameters Append(IRequestParameters requestParameters) {

            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            _requestParameters.Add(requestParameters);

            return this;

        }

        public IRequestParameters Append(string parameterName, string parameterValue) {

            if (string.IsNullOrWhiteSpace(parameterName))
                throw new ArgumentNullException(nameof(parameterName));

            if (parameterValue == null)
                throw new ArgumentNullException(nameof(parameterValue));

            CustomRequestParameters requestParameters = new CustomRequestParameters();
            requestParameters.AddParameter(parameterName, parameterValue);

            return Append(requestParameters);

        }

        #endregion

    }


}
