using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoedukaCLI
{
    internal class ConsoleUtils
    {
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo input;

            do
            {
                input = Console.ReadKey(intercept: true);
                if (input.Key != ConsoleKey.Backspace && input.KeyChar != '\r')
                {
                    password += input.KeyChar;
                    Console.Write("*");
                }
                else if (input.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (input.KeyChar != '\r');

            Console.WriteLine();
            return password;
        }
    }
}
