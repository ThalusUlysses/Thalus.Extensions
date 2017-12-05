using System.Text;

namespace Thalus.Extensions
{
    public static class CsvStringBuilderExtension

    {
        public static CsvStringBuilderFluent Csv(this StringBuilder b)
        {
            return new CsvStringBuilderFluent(b);
        }
    }
}