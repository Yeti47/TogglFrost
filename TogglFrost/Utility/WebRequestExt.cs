using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using TogglFrost.Authentication;

namespace TogglFrost.Utility {

    public static class WebRequestExt {

        public static void Add(this WebHeaderCollection headerCollection, IRequestHeader header) {

            if (headerCollection == null)
                throw new ArgumentNullException(nameof(headerCollection));

            if (header == null)
                throw new ArgumentNullException(nameof(header));

            headerCollection.Add(header.Header);

        }

        public static void AddBasicAuthenticationHeader(this WebHeaderCollection headerCollection, string userName, string password) {

            if (headerCollection == null)
                throw new ArgumentNullException(nameof(headerCollection));

            headerCollection.Add(new BasicAuthenticationHeader(userName, password).Header);

        }

        public static void AddBasicAuthenticationHeader(this WebHeaderCollection headerCollection, Credentials credentials) {

            if (headerCollection == null)
                throw new ArgumentNullException(nameof(headerCollection));

            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            headerCollection.Add(new BasicAuthenticationHeader(credentials).Header);

        }

        public static ReadHttpResponseResult ReadHttpResponse(this WebRequest webRequest) {

            if (webRequest == null)
                throw new ArgumentNullException(nameof(webRequest));

            string content = string.Empty;

            try {

                using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse) {

                    using(Stream stream = response.GetResponseStream()) {

                        using(StreamReader reader = new StreamReader(stream)) {

                            content = reader.ReadToEnd();

                        }

                    }

                }

            }
            catch(Exception ex) {

                return new ReadHttpResponseResult(ex);

            }

            return new ReadHttpResponseResult(content);

        }

    }

}
