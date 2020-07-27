using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.DataAccess.HandleSqlMap.MapProvider
{
    public class MapOption
    {
        public MapOption(char openQuote, char closeQuote, char parameterPrefix)
        {
            OpenQuote = openQuote;
            CloseQuote = closeQuote;
            ParameterPrefix = parameterPrefix;
        }

        public char OpenQuote { get; set; }

        public char CloseQuote { get; set; }

        public char ParameterPrefix { get; set; }

        public string CombineFieldName(string field)
        {
            return OpenQuote + field + CloseQuote;
        }
    }
}
