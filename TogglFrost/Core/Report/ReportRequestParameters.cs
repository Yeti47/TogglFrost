using System;
using System.Text;

namespace TogglFrost.Core.Report {

    public class ReportRequestParameters : TogglRequestParameters {

        public const string WORKSPACE_ID_PARAM_NAME = "workspace_id";

        public string WorkspaceId { get; set; }

        public override string Query {

            get {

                StringBuilder queryBuilder = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(UserAgent)) {

                    queryBuilder.Append(USER_AGENT_PARAM_NAME);
                    queryBuilder.Append('=');
                    queryBuilder.Append(Uri.EscapeUriString(UserAgent));
                    
                }

                if(!string.IsNullOrWhiteSpace(WorkspaceId)) {

                    if (queryBuilder.Length > 0)
                        queryBuilder.Append(PARAMETER_DELIMITER);

                    queryBuilder.Append(WORKSPACE_ID_PARAM_NAME);
                    queryBuilder.Append('=');
                    queryBuilder.Append(Uri.EscapeUriString(WorkspaceId));

                }

                return queryBuilder.ToString();

            }

        }

        public ReportRequestParameters(string userAgent, string workspaceId) : base(userAgent) {

            WorkspaceId = workspaceId;

        }

        public override string ToString() => Query;
        
    }


}
