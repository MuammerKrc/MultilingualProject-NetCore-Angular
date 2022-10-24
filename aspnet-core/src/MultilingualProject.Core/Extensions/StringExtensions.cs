using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilingualProject.Extensions
{
    public static  class StringExtensions
    {
        public static string ToSeoFriendly(this string text)
        {
            text = (text ?? "").Trim().ToLower();
            var url = new StringBuilder();
            foreach (var ch in text)
            {
                switch (ch)
                {
                    case 'ş':
                        url.Append('s');
                        break;
                    case 'ç':
                        url.Append('c');
                        break;
                    case 'ö':
                        url.Append('o');
                        break;
                    case 'ü':
                        url.Append('u');
                        break;
                    case 'ğ':
                        url.Append('g');
                        break;
                    case 'ı':
                        url.Append('i');
                        break;
                    case ' ':
                        url.Append('-');
                        break;
                    case '&':
                        url.Append("ve");
                        break;
                    case '\'':
                        break;
                    default:
                        if ((ch >= '0' && ch <= '9') ||
                            (ch >= 'a' && ch <= 'z'))
                        {
                            url.Append(ch);
                        }
                        else
                        {
                            if (ch == ' ' || ch == '-')
                                url.Append('-');
                        }

                        break;
                }
            }

            return url.ToString();
        }
    }
}
