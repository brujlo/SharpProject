using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VelikaMalaSlova
{
    class Metode
    {
        public static string ProvjeriString(string testiraj)
        {
            int separatorFlag = 0;
            String[] obrada = Regex.Split(testiraj, @"(?<=[.?!\r\n])");

            testiraj = "";

            for (int i = 0; i < obrada.Length; ++i)
            {
                if (obrada[i] == "") continue;

                StringBuilder charCmp = new StringBuilder(obrada[i]);

                if (Char.IsLetter(charCmp[0]) && separatorFlag == 1)
                    obrada[i] = " " + obrada[i].First().ToString().ToUpper() + obrada[i].Substring(1);
                else if (Char.IsLetter(charCmp[0]))
                    obrada[i] = obrada[i].First().ToString().ToUpper() + obrada[i].Substring(1);
                else if (Char.IsSeparator(charCmp[0]))
                {
                    obrada[i] = obrada[i].Trim();
                    obrada[i] = " " + obrada[i].First().ToString().ToUpper() + obrada[i].Substring(1);
                }

                if (obrada[i].EndsWith("!") || obrada[i].EndsWith("?") || obrada[i].EndsWith("."))
                    separatorFlag = 1;
                else
                    separatorFlag = 0;
            }

            foreach (string element in obrada)
            {
                testiraj += element;
            }

            return testiraj;

        }
    }
}
