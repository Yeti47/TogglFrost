using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TogglFrost.Core;

namespace TogglFrost.Authentication {

    public class Credentials {

        private string _userName;
        private string _password;

        public string UserName {
            get => _userName;
            set => _userName = !string.IsNullOrWhiteSpace(value) ? value : throw new StringBlankException(nameof(UserName));
        }

        public string Password {
            get => _password;
            set => _password = !string.IsNullOrWhiteSpace(value) ? value : throw new StringBlankException(nameof(Password));
        }

        public Credentials(string userName, string password) {

            UserName = userName;
            Password = password;

        }

        public override string ToString() => $"{UserName}:{Password}";
        
    }

}
