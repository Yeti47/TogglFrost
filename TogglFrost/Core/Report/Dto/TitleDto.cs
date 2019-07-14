using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core.Report.Dto {

    internal class TitleDto {
        
        public string Project { get; set; }
        public string Client { get; set; }
        public string User { get; set; }

        public TitleDto(string project, string client) {
            Project = project;
            Client = client;
        }

        public TitleDto(string user) {

            User = user;

        }

        public TitleDto() {

        }
        
    }

}
