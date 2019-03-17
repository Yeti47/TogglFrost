using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core {

    public class WorkspaceCache : IList<WorkspaceCacheItem> {

        private readonly List<WorkspaceCacheItem> _cacheItems = new List<WorkspaceCacheItem>();

        public WorkspaceCacheItem this[int index] {
            get => _cacheItems[index];
            set {

                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                _cacheItems[index] = value;

            }
        }

        public WorkspaceCacheItem this[string name] => _cacheItems.FirstOrDefault(i => i.Name == name);

        public int Count => _cacheItems.Count;

        public bool IsReadOnly => false;

        public void Add(WorkspaceCacheItem item) {

            if (Contains(item))
                return;

            _cacheItems.Add(item ?? throw new ArgumentNullException(nameof(item)));

        }

        public void AddRange(IEnumerable<WorkspaceCacheItem> items) {

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (WorkspaceCacheItem item in items)
                Add(item);

        }

        public void Clear() => _cacheItems.Clear();

        public bool Contains(WorkspaceCacheItem item) => item != null && _cacheItems.Contains(item);

        public void CopyTo(WorkspaceCacheItem[] array, int arrayIndex) => _cacheItems.CopyTo(array ?? throw new ArgumentNullException(nameof(array)), arrayIndex);

        public IEnumerator<WorkspaceCacheItem> GetEnumerator() => _cacheItems.GetEnumerator();

        public int IndexOf(WorkspaceCacheItem item) => _cacheItems.IndexOf(item ?? throw new ArgumentNullException(nameof(item)));

        public void Insert(int index, WorkspaceCacheItem item) {

            if (Contains(item))
                return;

            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException();

            _cacheItems.Insert(index, item);

        }

        public bool Remove(WorkspaceCacheItem item) => _cacheItems.Remove(item ?? throw new ArgumentNullException(nameof(item)));

        public void RemoveAt(int index) { 
            
            if (index< 0 || index >= Count)
                throw new IndexOutOfRangeException();

        _cacheItems.RemoveAt(index);

        }

        IEnumerator IEnumerable.GetEnumerator() => _cacheItems.GetEnumerator();

        public WorkspaceCacheItem Find(string name) => this[name];

    }

}
