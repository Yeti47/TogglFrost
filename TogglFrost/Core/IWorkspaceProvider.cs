using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core {

    public interface IWorkspaceProvider {

        WorkspaceCache LoadWorkspaceCache();

        WorkspaceCacheItem LoadWorkspaceCacheItemByName(string name);

        WorkspaceCacheItem LoadWorkspaceCacheItemById(string id);

    }
    
}
