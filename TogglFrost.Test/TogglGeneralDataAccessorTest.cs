using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TogglFrost.Core;
using TogglFrost.Core.Report;

namespace TogglFrost.Test {

    [TestClass]
    public class TogglGeneralDataAccessorTest {

        public TestContext TestContext { get; set; }

        private string ApiToken => TestContext.Properties["apiToken"]?.ToString();
        private uint GeneralApiVersion => Convert.ToUInt32(TestContext.Properties["generalApiVersion"]);
        private uint ReportApiVersion => Convert.ToUInt32(TestContext.Properties["reportApiVersion"]);
        private string UserAgent => TestContext.Properties["userAgent"]?.ToString();
        private string DefaultWorkspaceId => TestContext.Properties["defaultWorkspaceId"]?.ToString();

        [TestInitialize]
        public void SetupTest() { }

        [TestMethod]
        public void LoadWorkspaceCacheReturnsOneItem() {

            TogglGeneralDataAccessor dataAccessor = new TogglGeneralDataAccessor(UserAgent, ApiToken, (uint)GeneralApiVersion);

            WorkspaceCache cache = dataAccessor.LoadWorkspaceCache();

            Assert.IsTrue(cache != null && cache.Any(c => c.ID == DefaultWorkspaceId));

        }

        [TestMethod]
        public void LoadDefaultWorkspaceCacheItem() {

            TogglGeneralDataAccessor dataAccessor = new TogglGeneralDataAccessor(UserAgent, ApiToken, (uint)GeneralApiVersion);

            string workspaceId = DefaultWorkspaceId;

            WorkspaceCacheItem cacheItem = dataAccessor.LoadWorkspaceCacheItem(workspaceId);

            Assert.IsTrue(cacheItem != null && cacheItem.ID ==  workspaceId);

        }

        [TestMethod]
        public void GetSummary() {

            TogglGeneralDataAccessor dataAccessor = new TogglGeneralDataAccessor(UserAgent, ApiToken, (uint)GeneralApiVersion);

            string workspaceId = DefaultWorkspaceId;

            TogglReportDataAccessor reportDataAccessor = new TogglReportDataAccessor(UserAgent, ApiToken, ReportApiVersion, dataAccessor);

            Summary summary = reportDataAccessor.GetSummary(workspaceId, DateTime.Now.AddDays(-7), DateTime.Now);

            string t = "";

        }


    }

}
