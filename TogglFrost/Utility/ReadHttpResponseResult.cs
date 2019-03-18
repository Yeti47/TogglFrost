using System;

namespace TogglFrost.Utility {

    public class ReadHttpResponseResult {

        private readonly bool _isError = false;

        public string Content { get; }

        public bool HasError => Exception != null || _isError;
        public bool IsEmpty => string.IsNullOrWhiteSpace(Content);

        public Exception Exception { get; }

        public ReadHttpResponseResult(string content, Exception exception = null) {

            Content = content ?? string.Empty;
            Exception = exception;

        }

        public ReadHttpResponseResult(string content, bool isError) : this(content) {
            _isError = isError;
        }

        public ReadHttpResponseResult(Exception exception) : this(null, exception) {

        }
        
    }

}
