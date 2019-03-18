using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using TogglFrost.Core.Report;
using TogglFrost.Utility;

namespace TogglFrost.Core {

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

            string url = SUMMARY_URL + "?" + AuthenticationQuery + $"&workspace_id={workspaceCacheItem.ID}&since={from.ToString("yyyy-MM-dd")}&until={to.ToString("yyyy-MM-dd")}";

            WebRequest webRequest = CreateRequest(url);

            ReadHttpResponseResult result = webRequest.ReadHttpResponse();

            if(result != null && !result.HasError) {

                JObject jObj = JObject.Parse(result.Content);

                JArray jArr = jObj["data"] as JArray;

                Summary summary = new Summary();

                foreach (JToken token in jArr) {

                    //TimeEntry entry = CreateTimeEnty(token);
                    //summary.AddTimeEntry(entry);

                    TimeEntry entry = token.ToObject<TimeEntry>();
                    summary.AddTimeEntry(entry);

                }


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

        private TimeEntry CreateTimeEnty(JToken jToken) {

            TimeSpan timeSpan = TimeSpan.FromMilliseconds(Convert.ToInt32(jToken["time"]));

            return new TimeEntry {
                Time = timeSpan
            };

        }

    }

}
