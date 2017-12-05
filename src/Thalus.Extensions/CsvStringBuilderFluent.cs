using System.Globalization;
using System.Text;

namespace Thalus.Extensions
{
    public class CsvStringBuilderFluent
    {
        private StringBuilder _builder;
        private char _charSepChar = ',';


        public CsvStringBuilderFluent(): this(new StringBuilder())
        {
        }
        public CsvStringBuilderFluent(StringBuilder builder)
        {
            _builder = builder;
        }

        public CsvStringBuilderFluent UseSeperator(char sep = ',')
        {
            _charSepChar = sep;
            return this;
        }

        public CsvStringBuilderFluent Append(object c)
        {
            if (_builder == null)
            {
                _builder = new StringBuilder();
            }

            if (_builder.Length > 0)
            {
                _builder.Append(_charSepChar);
            }
            _builder.Append(c);
            return this;
        }

        public CsvStringBuilderFluent AppendFormat(object append, string format, CultureInfo cu = null)
        {
            if (_builder == null)
            {
                _builder = new StringBuilder();
            }

            if (_builder.Length > 0)
            {
                _builder.Append(_charSepChar);
            }

            _builder.AppendFormat(cu ?? CultureInfo.CurrentUICulture, format, append);

            return this;
        }

        public string Build()
        {

            var  b =  _builder.ToString();

            _builder = null;

            return b;
        }

        public StringBuilder Clone()
        {
            var b = new  StringBuilder(_builder.ToString());

            _builder = null;

            return b;
        }
    }
}