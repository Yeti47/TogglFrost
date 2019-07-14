using System;

namespace TogglFrost.Core {

    public class TogglRequestParameters : RequestParameters {

        public const string USER_AGENT_PARAM_NAME = "user_agent";
        
        public string UserAgent { get; set; }

        public override string Query => $"{USER_AGENT_PARAM_NAME}={Uri.EscapeUriString(UserAgent)}";

        public TogglRequestParameters(string userAgent) {

            UserAgent = userAgent;

        }

        public override string ToString() => Query;

    }


}
