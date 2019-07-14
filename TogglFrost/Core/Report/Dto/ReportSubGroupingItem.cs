using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core.Report.Dto {

    internal class ReportSubGroupingItem {

        public SubGroupingItemTitleDto Title { get; set; }

        public int Time { get; set; }

        public string Cur { get; set; }

        public double? Sum { get; set; }

        public double? Rate { get; set; }

    }

}
