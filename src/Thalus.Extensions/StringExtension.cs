using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Thalus.Extensions
{
    public static class StringExtension
    {
        public static bool EqualsInvariantIgnore(this string st, string compar)
        {
            return st.Equals(compar, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool EqualsInvariant(this string st, string compar)
        {
            return st.Equals(compar, StringComparison.InvariantCulture);

        }

        public static string ToBase64(this string st)
        {
            byte[] bts = Encoding.Default.GetBytes(st);

           return Convert.ToBase64String(bts, Base64FormattingOptions.None);

          


        }
    }

    public static class FileCompressExtension
    {
        public static string ReadAllTextCompressed(this FileInfo f)
        {
            using (FileStream stm = f.OpenWrite())
            using (GZipStream gZipStm = new GZipStream(stm, CompressionLevel.Optimal, false))
            {
                byte[] ts = new byte[f.Length];
                gZipStm.Read(ts, 0, ts.Length);

                return Encoding.Default.GetString(ts);
            }
        }

        public static byte[] ReadAllBytesCompressed(this FileInfo f, byte[] bts)
        {
            using (FileStream stm = f.OpenWrite())
            using (GZipStream gZipStm = new GZipStream(stm, CompressionLevel.Optimal, false))
            {
                byte[] ts = new byte[f.Length];
                gZipStm.Read(ts, 0, ts.Length);

                return ts;
            }
        }

        public static string ReadAllText(this FileInfo f)
        {
            return File.ReadAllText(f.FullName);
        }

        public static byte[] ReadAllBytes(this FileInfo f)
        {
            return File.ReadAllBytes(f.FullName);
        }

        public static void WriteAllTextCompressed(this FileInfo f, string text)
        {
            using (FileStream stm = f.OpenWrite())
            using (GZipStream gZipStm = new GZipStream(stm,CompressionLevel.Optimal,false))
            {
                gZipStm.Write(text);
            }
        }

        public static void WriteAllBytesCompressed(this FileInfo f, byte[] bts)
        {
            using (FileStream stm = f.OpenWrite())
            using (GZipStream gZipStm = new GZipStream(stm, CompressionLevel.Optimal, false))
            {
                gZipStm.Write(bts, 0, bts.Length);
            }
        }

        public static void WriteAllText(this FileInfo f, string text)
        {
            File.WriteAllText(f.FullName, text);
        }

        public static void WriteAllBytes(this FileInfo f, byte[] bts)
        {
            File.WriteAllBytes(f.FullName, bts);
        }
    }

    public static class GZipStreamExtension
    {
        public static void Write(this GZipStream stm, string st)
        {
            var bts = Encoding.Default.GetBytes(st);

            stm.Write(bts, 0, bts.Length);
        }

      
    }
}