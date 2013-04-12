using System;

namespace iRail.Net.Model
{
    public class Lang
    {
        public static readonly Lang Fr = new Lang("FR");
        public static readonly Lang En = new Lang("EN");
        public static readonly Lang Nl = new Lang("NL");
        public static readonly Lang De = new Lang("DE");

        private readonly string _lang;

        private Lang(string lang)
        {
            if (lang == null) throw new ArgumentNullException("lang");
            _lang = lang;
        }

        public override string ToString()
        {
            return _lang;
        }
    }
}
