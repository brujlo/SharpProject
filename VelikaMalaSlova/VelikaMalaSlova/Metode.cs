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
            bool separatorFlag = false;
            String[] obrada = Regex.Split(testiraj, @"(?<=[.?!\r\n])");

            testiraj = "";

            for (int i = 0; i < obrada.Length; ++i)
            {
                if (obrada[i] == "") continue;

                StringBuilder charCmp = new StringBuilder(obrada[i]);

                if (Char.IsLetter(charCmp[0]) && separatorFlag)
                    obrada[i] = " " + obrada[i].First().ToString().ToUpper() + obrada[i].Substring(1);
                else if (Char.IsLetter(charCmp[0]))
                    obrada[i] = obrada[i].First().ToString().ToUpper() + obrada[i].Substring(1);
                else if (Char.IsSeparator(charCmp[0]))
                {
                    obrada[i] = obrada[i].Trim();
                    obrada[i] = " " + obrada[i].First().ToString().ToUpper() + obrada[i].Substring(1);
                }

                if (obrada[i].EndsWith("!") || obrada[i].EndsWith("?") || obrada[i].EndsWith("."))
                    separatorFlag = true;
                else
                    separatorFlag = false;
            }

            foreach (string element in obrada)
            {
                testiraj += element;
            }

            return testiraj;
        }

        public static bool ProvjeriSelektiraniTekst (int textSelected)
        {
            return textSelected > 1 ? true : false; 
        }
    }
}
