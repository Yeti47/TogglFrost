using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TogglFrost.Core;
using TogglFrost.Core.Report;

namespace TogglFrost.Test {

    [TestClass]
    public class TogglGeneralDataAccessorTest {

        private TestAuthenticationSettings _testCredentials;

        public TestContext TestContext { get; set; }

        private string ApiToken => _testCredentials.ApiToken;
        private string UserAgent => _testCredentials.UserAgent;
        private string DefaultWorkspaceName => _testCredentials.DefaultWorkspaceName;

        private uint GeneralApiVersion => Convert.ToUInt32(TestContext.Properties["generalApiVersion"]);
        private uint ReportApiVersion => Convert.ToUInt32(TestContext.Properties["reportApiVersion"]);

        [TestInitialize]
        public void SetupTest() {

            _testCredentials = TestAuthenticationSettings.Load(TestContext.Properties["testCredPath"].ToString());

        }

        [TestMethod]
        public void LoadWorkspaceCacheReturnsOneItem() {

            TogglGeneralDataAccessor dataAccessor = new TogglGeneralDataAccessor(UserAgent, ApiToken, (uint)GeneralApiVersion);

            WorkspaceCache cache = dataAccessor.LoadWorkspaceCache();

            Assert.IsTrue(cache != null && cache.Any(c => c.ID == DefaultWorkspaceName));

        }

        [TestMethod]
        public void LoadDefaultWorkspaceCacheItem() {

            TogglGeneralDataAccessor dataAccessor = new TogglGeneralDataAccessor(UserAgent, ApiToken, GeneralApiVersion);

            string workspaceId = DefaultWorkspaceName;

            WorkspaceCacheItem cacheItem = dataAccessor.LoadWorkspaceCacheItemById(workspaceId);

            Assert.IsTrue(cacheItem != null && cacheItem.ID ==  workspaceId);

        }

        [TestMethod]
        public void GetSummary() {

            TogglGeneralDataAccessor dataAccessor = new TogglGeneralDataAccessor(UserAgent, ApiToken, GeneralApiVersion);

            string workspaceName = DefaultWorkspaceName;

            TogglReportDataAccessor reportDataAccessor = new TogglReportDataAccessor(UserAgent, ApiToken, ReportApiVersion, dataAccessor);

            Summary summary = reportDataAccessor.GetSummary(workspaceName, DateTime.Now.AddDays(-7), DateTime.Now);

            string t = "";

        }


    }

}
