using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TogglFrost.Authentication;
using TogglFrost.Utility;

namespace TogglFrost.Core {

    public abstract class TogglDataAccessor {

        public const string BASE_URL = "https://toggl.com";
        protected const string AUTHENTICATION_PASSWORD = "api_token";
        protected const string CONTENT_TYPE_JSON = "application/json";

        protected const string USER_AGENT_PARAM_NAME = "user_agent";

        private const string API_TOKEN_MISSING_EXCEPTION_MSG = "The operation cannot be performed since no API token has been provided.";

        public uint ApiVerson { get; set; }

        public string ApiToken { get; set; }

        public string UserAgent { get; set; }
        
        public abstract string BaseUrl { get; }

        public virtual string AuthenticationQuery => string.IsNullOrEmpty(UserAgent) ? string.Empty : $"{USER_AGENT_PARAM_NAME}={Uri.EscapeUriString(UserAgent)}";

        protected TogglDataAccessor(string userAgent, string apiToken, uint apiVersion) {

            UserAgent = userAgent;
            ApiToken = apiToken;
            ApiVerson = apiVersion;

        }

        public ReadHttpResponseResult TestConnection() {

            WebRequest request = CreateRequest();

            return request.ReadHttpResponse();

        }

        protected virtual WebRequest CreateRequest(string url = null, HttpRequestMethod requestMethod = HttpRequestMethod.GET) {

            if (string.IsNullOrWhiteSpace(ApiToken))
                throw new InvalidOperationException(API_TOKEN_MISSING_EXCEPTION_MSG);

            url = url?.Trim(new char[] { ' ', '/' }) ?? string.Empty;

            WebRequest request = WebRequest.Create(BaseUrl + "/" + url);
            request.ContentType = CONTENT_TYPE_JSON;
            request.PreAuthenticate = true;
            request.Method = requestMethod.ToString();
            request.Headers.AddBasicAuthenticationHeader(ApiToken, AUTHENTICATION_PASSWORD);
            return request;
            
        }

    }

}
