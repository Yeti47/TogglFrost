using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using TogglFrost.Core.Report;
using TogglFrost.Core.Report.Dto;
using TogglFrost.Utility;

namespace TogglFrost.Core.Report {

    public class TogglReportDataAccessor : TogglDataAccessor {

        private const string SUMMARY_URL = "summary";

        private readonly WorkspaceCache _workspaceCache = new WorkspaceCache();

        public override string BaseUrl => BASE_URL + $"/reports/api/v{ApiVerson}";

        public string SummaryUrl => BaseUrl + $"/{SUMMARY_URL}";

        public IWorkspaceProvider WorkspaceProvider { get; }

        public TogglReportDataAccessor(string userAgent, string apiToken, uint apiVersion, IWorkspaceProvider workspaceProvider) : base(userAgent, apiToken, apiVersion) {

            WorkspaceProvider = workspaceProvider ?? throw new ArgumentNullException(nameof(workspaceProvider));

        }

        public Summary GetSummary(string workspaceName, DateTime from, DateTime to) {

            WorkspaceCacheItem workspaceCacheItem = UpdateWorkspaceCache(workspaceName);

            if (workspaceCacheItem == null)
                return null;

            WebRequest webRequest = CreateRequest(SUMMARY_URL, new ReportRequestParameters(UserAgent, workspaceCacheItem.ID));

            ReadHttpResponseResult result = webRequest.ReadHttpResponse();

            if(result != null && !result.HasError) {

                JObject jObj = JObject.Parse(result.Content);

                SummaryDto summaryDto = jObj.ToObject<SummaryDto>();


            }

            return null;

        }

        private WorkspaceCacheItem UpdateWorkspaceCache(string workspaceName) {

            if (string.IsNullOrWhiteSpace(workspaceName))
                throw new ArgumentNullException(nameof(workspaceName));

            if (_workspaceCache.Find(workspaceName) is WorkspaceCacheItem item)
                return item;

            WorkspaceCacheItem cacheItem = null;

            if(WorkspaceProvider != null) {

                cacheItem = WorkspaceProvider.LoadWorkspaceCacheItemByName(workspaceName);

                if (cacheItem != null)
                    _workspaceCache.Add(cacheItem);

            }

            return cacheItem;

        }


    }

}
