using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D00_Utility
{
    public class Utility
    {
        public static void SetUnicodeConsole()
        {
            // teste
            //Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // teste
            //Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");
        }

        public static void WriteTitle(string title, string beginTitle = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine(new string('-', title.Length));
            
            Console.WriteLine(title.ToUpper());
            
            Console.WriteLine(new string('-', title.Length));
            
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.WriteLine();
        }

        // receber 3 valores
        public static void WriteMessage(string message, string beginMessage = "", string endMessage = "")
        {
            Console.Write($"{beginMessage}{message}{endMessage}");
        }

        public static void TerminateConsole()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("\n\n\n\nPrime qualquer tecla para terminar.");

            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();

            Console.Clear();
        }

        public static void PauseConsole()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Utility.WriteMessage("\nPressione qualquer tecla para continuar...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public static void HidePassword(string password)
        {
            string hiddenPassword = new string('*', password.Length);

            Utility.WriteMessage(hiddenPassword, "", "\n");
        }
    }
}
