using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core.Report.Dto {

    public class TitleDto {
        
        public string Project { get; set; }
        public string Client { get; set; }
        public string User { get; set; }

        public TitleDto(string project, string client, string user) {
            Project = project;
            Client = client;
            User = user;
        }

        public TitleDto() {

        }
        
    }

    public class TimeEntryTitleDto : TitleDto {

        public string Task { get; set; }
        public string TimeEntry { get; set; }

        public TimeEntryTitleDto(string project, string client, string user, string task, string timeEntry) : base(project, client, user) {

            Task = task;
            TimeEntry = timeEntry;
            
        }

        public TimeEntryTitleDto() {

        }

    }

}
