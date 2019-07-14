using Newtonsoft.Json;

namespace TogglFrost.Core.Report.Dto {

    internal class SubGroupingItemTitleDto : TitleDto {

        public string Task { get; set; }

        [JsonProperty("time_entry")]
        public string TimeEntry { get; set; }

        public SubGroupingItemTitleDto(string project, string client, string user, string task, string timeEntry) : base(project, client) {

            User = user;
            Task = task;
            TimeEntry = timeEntry;
            
        }

        public SubGroupingItemTitleDto() {

        }

    }

}
