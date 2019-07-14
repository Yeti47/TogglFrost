using System;

namespace TogglFrost.Core {

    public abstract class RequestParameters : IRequestParameters {

        public const char PARAMETER_PREFIX = '?';
        public const char PARAMETER_DELIMITER = '&';

        public static IRequestParameters Empty => new CustomRequestParameters();

        public abstract string Query { get; }

        protected RequestParameters() { }

        public virtual IRequestParameters Append(IRequestParameters requestParameters) {

            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            return new CompositeRequestParameters(requestParameters);

        }

        public virtual string CreateUrl(string url) => $"{url}{PARAMETER_PREFIX}{Query}";


    }


}
