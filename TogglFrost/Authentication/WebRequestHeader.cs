using System;

namespace TogglFrost.Authentication {
    public class WebRequestHeader : IRequestHeader {

        private const string NAME_BLANK_EXCEPTION_MSG = "The header's name must not be null or blank.";

        private string _name;

        public string Name {
            get => _name;
            set => _name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException(NAME_BLANK_EXCEPTION_MSG);
        }

        public string Value { get; set; }

        public string Header => $"{Name}:{Value}";

        public WebRequestHeader(string name, string value) {

            Name = name;
            Value = value;
            
        }

        public override string ToString() => $"Name: {Name} | Value: {Value}";

    }

}
