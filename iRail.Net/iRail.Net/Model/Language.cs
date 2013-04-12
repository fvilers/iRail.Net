using System;

namespace iRail.Net.Model
{
    public class Language
    {
        public static readonly Language French = new Language("FR");
        public static readonly Language English = new Language("EN");
        public static readonly Language Dutch = new Language("NL");
        public static readonly Language German = new Language("DE");

        private readonly string _language;

        private Language(string language)
        {
            if (language == null) throw new ArgumentNullException("language");
            _language = language;
        }

        public override string ToString()
        {
            return _language;
        }
    }
}
