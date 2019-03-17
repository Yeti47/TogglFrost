using Newtonsoft.Json;
using System;

namespace TogglFrost.Core {

    public class WorkspaceCacheItem : IEquatable<WorkspaceCacheItem>, IIdentifyable {

        [JsonProperty("id")]
        public string ID { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        public WorkspaceCacheItem(string id, string name) {
            ID = id; 
            Name = name;
        }

        public bool Equals(WorkspaceCacheItem other) => other != null && other.ID == ID;

        public override string ToString() => $"ID: {ID} | Name: {Name}";

    }

}
