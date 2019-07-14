using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TogglFrost.Core.Report {

    public class Summary : Report {

        #region Fields

        #endregion

        #region Props

        public override ReadOnlyCurrencyTotalMap TotalCurrencies => throw new NotImplementedException();

        public override long TotalGrand => throw new NotImplementedException();

        public override long TotalBillable => throw new NotImplementedException();

        #endregion

        #region Ctors

        #endregion

        #region Methods

        #endregion
    }

}
