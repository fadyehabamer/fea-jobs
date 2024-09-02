using System.Text;
using System.Text.RegularExpressions;

namespace JobPortal.Common
{
    public class TextHelper
    {
        public static string ToUnsignString(string input)
        {
            // TRIM INPUT
            input = input.Trim();


            input = input.Replace("+", "p");
            input = input.Replace("#", "sharp");
            input = input.Replace(".", "dot");

            // special chars : ! , "" , # , $ , ....
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }


            input = input.Replace(" ", "-");
            input = input.Replace(",", "-");
            input = input.Replace(";", "-");
            input = input.Replace(":", "-");
            input = input.Replace("  ", "-");

            // \p --> unicode chars
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);

            // DiacriticalMarks
            // é -- e - accent
            // ü -- u - diaeresis
            // ñ -- n - tilde
            // No handle for đ and Đ
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');

            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            while (str2.Contains("--"))
            {
                str2 = str2.Replace("--", "-").ToLower();
            }
            return str2;
        }
        public static String GetFullTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("mmssffff");
        }

        // 2000-11-11 11:00:00.1234
        // 20001111
        // 1100001234

    }
}