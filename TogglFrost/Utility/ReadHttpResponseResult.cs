using System;

namespace TogglFrost.Utility {

    public class ReadHttpResponseResult {

        public string Content { get; }

        public bool HasError => Exception != null;
        public bool IsEmpty => string.IsNullOrWhiteSpace(Content);

        public Exception Exception { get; }

        public ReadHttpResponseResult(string content, Exception exception = null) {

            Content = content ?? string.Empty;
            Exception = exception;

        }

        public ReadHttpResponseResult(Exception exception) : this(null, exception) {

        }
        
    }

}
