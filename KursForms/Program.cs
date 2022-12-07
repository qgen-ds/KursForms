using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursForms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));
        }
        /// <summary>
        /// определяет, является ли символ пробелом
        /// </summary>
        public static bool IsSpace(char c)
        {
            switch (c)
            {
                case ' ':
                case '\n':
                case '\t':
                case '\r':
                case '\v':
                case '\f':
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// определяет, является ли символ символом пунктуации
        /// </summary>
        public static bool IsPunct(char c)
        {
            //!"#$%&'()*+,-./:;<=>?@[\]^_`{|}~
            switch (c)
            {
                case '!':
                case '\"':
                case '#':
                case '$':
                case '%':
                case '&':
                case '\'':
                case '(':
                case ')':
                case '*':
                case '+':
                case ',':
                case '-':
                case '.':
                case '/':
                case ':':
                case ';':
                case '<':
                case '=':
                case '>':
                case '?':
                case '@':
                case '[':
                case '\\':
                case ']':
                case '^':
                case '_':
                case '`':
                case '{':
                case '|':
                case '}':
                case '~':
                    return true;
                default:
                    return false;
            }
        }
    }
}
