using System.IO;

namespace TogglFrost.Test {

    public class TestAuthenticationSettings {

        public string UserAgent { get; private set; }
        public string DefaultWorkspaceName { get; private set; }
        public string ApiToken { get; private set; }

        public TestAuthenticationSettings(string userAgent, string defaultWorkspaceName, string apiToken) {
            UserAgent = userAgent;
            DefaultWorkspaceName = defaultWorkspaceName;
            ApiToken = apiToken;
        }

        public override string ToString() => $"UserAgent: {UserAgent} | DefaultWorkspaceId: {DefaultWorkspaceName} | ApiToken: {ApiToken}";

        public static TestAuthenticationSettings Load(string path) {

            int ctr = 0;

            string userAgent = null;
            string apiToken = null;
            string workspaceName = null;

            foreach(string line in File.ReadAllLines(path)) {

                if (ctr == 0)
                    userAgent = line;
                else if (ctr == 1)
                    apiToken = line;
                else if (ctr == 2)
                    workspaceName = line;

                ctr++;
                
            }

            return new TestAuthenticationSettings(userAgent, workspaceName, apiToken);

        }

    }

}
