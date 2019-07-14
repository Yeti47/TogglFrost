using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core {

    public interface IRequestParameters {

        string Query { get; }

        IRequestParameters Append(IRequestParameters requestParameters);

        string CreateUrl(string url);

    }


}
