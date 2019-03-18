using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core.Report.Dto {

    public class SummaryDto {

        public double TotalGrand { get; set; }
        public double TotalBillable { get; set; }

        public CurrencyDto[] TotalCurrencies { get; set; }

        public TimeEntryGroupingDto[] Data { get; set; }

    }

    public class CurrencyDto {

        public string Currency { get; set; }
        public double? Amount { get; set; }

    }

}
