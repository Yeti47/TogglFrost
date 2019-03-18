using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core.Report.Dto {

    public class TimeEntryGroupingDto {

        public int ID { get; set; }

        public TitleDto Title { get; set; }

        public int Time { get; set; }

        public CurrencyDto[] TotalCurrencies { get; set; }

        public TimeEntryDto[] Items { get; set; }

    }

    public class TimeEntryDto {

        public TimeEntryTitleDto Title { get; set; }

        public int Time { get; set; }

        public string Cur { get; set; }

        public double? Sum { get; set; }

        public double? Rate { get; set; }

    }

}
