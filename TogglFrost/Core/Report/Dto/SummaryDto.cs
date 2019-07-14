using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core.Report.Dto {

    internal class SummaryDto {

        public double TotalGrand { get; set; }
        public double TotalBillable { get; set; }

        public CurrencyDto[] TotalCurrencies { get; set; }

        public ReportGroupingItem[] Data { get; set; }

    }

}
