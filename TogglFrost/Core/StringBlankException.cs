using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Core {

    public class StringBlankException : Exception {

        public string Identifier { get; }

        public StringBlankException(string identifier, Exception innerException = null) : this(identifier, $"{identifier} must not be null or blank.", innerException) {

        }

        public StringBlankException(string identifier, string message, Exception innerException = null) : base(message, innerException) {

            Identifier = identifier;

        }

    }

}
