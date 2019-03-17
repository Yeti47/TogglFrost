using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TogglFrost.Core.Report {

    public class Summary {

        private readonly List<TimeEntry> _timeEntries = new List<TimeEntry>();

        public IEnumerable<TimeEntry> TimeEntries => new ReadOnlyCollection<TimeEntry>(_timeEntries);

        public void AddTimeEntry(TimeEntry timeEntry) {
            
            _timeEntries.Add(timeEntry);

        }

    }

    public class TimeEntry {

        public string ID { get; set; }

        public string Title { get; set; }

        public TimeSpan Time { get; set; }
        
        public string Currency { get; set; }

        public double Sum { get; set; }
        public double Rate { get; set; }

    }

    public class TimeSpanConverter : JsonConverter {

        public override bool CanConvert(Type objectType) => throw new NotImplementedException();
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => throw new NotImplementedException();
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }

}
