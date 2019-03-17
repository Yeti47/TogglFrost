using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglFrost.Authentication {

    public class BasicAuthenticationHeader : IRequestHeader {

        private const string HEADER_NAME = "Authorization";
        public const string ENCODING_NAME = "ISO-8859-1";
        public const string AUTHENTICATION_SCHEME = "Basic";

        private Credentials _credentials;

        public string Name => HEADER_NAME;

        public string Value {

            get {

                string encodedValue = Convert.ToBase64String(Encoding.GetEncoding(ENCODING_NAME).GetBytes(Credentials?.ToString() ?? string.Empty));

                return $"{AUTHENTICATION_SCHEME} {encodedValue}";

            }

        }

        public string Header => $"{Name}:{Value}";

        public Credentials Credentials {
            get => _credentials;
            set => _credentials = value ?? throw new ArgumentNullException(nameof(value));
        }

        public BasicAuthenticationHeader(string userName, string password) : this(new Credentials(userName, password)) {

        }

        public BasicAuthenticationHeader(Credentials credentials) {

            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));

        }

        public override string ToString() => $"Name: {Name} | UserName: {Credentials.UserName} | Password: {Credentials.Password} | Value: {Value}";

    }

}
