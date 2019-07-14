namespace TogglFrost.Core.Report.Dto {

    internal class ReportGroupingItem {

        public long ID { get; set; }

        public TitleDto Title { get; set; }

        public int Time { get; set; }

        public CurrencyDto[] TotalCurrencies { get; set; }

        public ReportSubGroupingItem[] Items { get; set; }

    }

}
