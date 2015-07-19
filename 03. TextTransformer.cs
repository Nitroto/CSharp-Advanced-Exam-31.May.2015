using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


class TextTransformer
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        StringBuilder nakovWrite = new StringBuilder();
        string line;
        while ((line = Console.ReadLine()) != "burp")
        {
            nakovWrite.Append(line);

        }
        string nakovWords = nakovWrite.ToString();
        nakovWords = Regex.Replace(nakovWords, @"\s+", " ");
        Regex pattern = new Regex(@"([$%&'])([^$%&']+)\1", RegexOptions.Compiled);
        MatchCollection words = pattern.Matches(nakovWords);
        nakovWrite.Clear();
        foreach (Match word in words)
        {
            string translate = word.Value;
            char specialChar = translate[0];
            char[] converted = new char[translate.Length - 2];
            int specialCharValue = 0;
            switch (specialChar)
            {
                case '$': specialCharValue = 1; break;
                case '%': specialCharValue = 2; break;
                case '&': specialCharValue = 3; break;
                case '\'': specialCharValue = 4; break;
                default: break;
            }
            for (int i = 1; i < translate.Length - 1; i++)
            {
                converted[i - 1] = translate[i];
            }
            for (int i = 0; i < converted.Length; i++)
            {
                if (i % 2 == 0)
                {
                    converted[i] = (char)(converted[i] + specialCharValue);
                }
                else
                {
                    converted[i] = (char)(converted[i] - specialCharValue);
                }
                nakovWrite.Append(converted[i]);
            }
            nakovWrite.Append(" ");
        }
        Console.WriteLine(nakovWrite.ToString().Trim());
    }
}

