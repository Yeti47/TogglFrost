using System;

namespace TogglFrost.Core.Report {

    public class GroupingSubGroupingMismatchException : Exception {

        private const string DEFAULT_MSG = "The given subgrouping is not compatible with the selected grouping.";

        public Grouping Grouping { get; private set; }
        public SubGrouping SubGrouping { get; private set; }
        
        public GroupingSubGroupingMismatchException(Grouping grouping, SubGrouping subGrouping, string message = DEFAULT_MSG) : base(message) {

            Grouping = grouping;
            SubGrouping = subGrouping;

        }

        public GroupingSubGroupingMismatchException(SubGrouping subGrouping, Grouping grouping) : this(grouping, subGrouping, $"The grouping {grouping} is incomtabible with the subgrouping {subGrouping}."){
            
        }

    }

}
