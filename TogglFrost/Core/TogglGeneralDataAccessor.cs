using System.Net;
using TogglFrost.Utility;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace TogglFrost.Core {

    public class TogglGeneralDataAccessor : TogglDataAccessor, IWorkspaceProvider {

        private const string WORKSPACE_URL = "workspaces";

        public override string BaseUrl => BASE_URL + $"/api/v{ApiVerson}";

        public TogglGeneralDataAccessor(string userAgent, string apiToken, uint apiVersion) : base(userAgent, apiToken, apiVersion) {

        }

        public WorkspaceCache LoadWorkspaceCache() {

            WorkspaceCache cache = new WorkspaceCache();

            WebRequest webRequest = CreateRequest(WORKSPACE_URL);

            ReadHttpResponseResult result = webRequest.ReadHttpResponse();

            if(result != null && !result.HasError) {

                JArray jsonArray = JArray.Parse(result.Content);
                
                cache.AddRange(jsonArray.Select(i => i.ToObject<WorkspaceCacheItem>()));

            }

            return cache;

        }

        public WorkspaceCacheItem LoadWorkspaceCacheItem(string id) {

            WorkspaceCacheItem item = null;

            WebRequest webRequest = CreateRequest(WORKSPACE_URL + $"/{id}");

            ReadHttpResponseResult result = webRequest.ReadHttpResponse();

            if (result != null && !result.HasError) {

                JObject jObj = JObject.Parse(result.Content);

                item = jObj["data"].ToObject<WorkspaceCacheItem>();

            }

            return item;
            
        }
        
    }

}
