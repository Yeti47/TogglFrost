using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core.Report {

    public class SummaryItem {

        #region Fields

        //private readonly List<Sum>

        #endregion

        #region Props

        public long Id { get; }

        public Grouping Grouping { get; set; } = Grouping.Projects;
        public SubGrouping SubGrouping { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        #endregion

        #region Ctors

        public SummaryItem(long id, DateTime startDate, DateTime endDate, Grouping grouping = Grouping.Projects, SubGrouping subGrouping = SubGrouping.TimeEntries) {

            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Grouping = grouping;
            SubGrouping = subGrouping;

        }

        #endregion

        #region Methods

        #endregion

    }

    public class SummarySubItem {



    }

}
