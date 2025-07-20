using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Utilities
{
    public static class MessageHandler
    {
        static MessageHandler() { } 

        public static void DisplayProjectHeader() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine(" -------------------------------------------------------------------------------------");
            CenterText(" *************************************************************************************");
            CenterText(" *                   L I B R A R Y   M A N A G E M E N T   S Y S T E M               *");
            CenterText(" *                             B Y  S A H I L   T R I V E D I                        *");
            CenterText(" *************************************************************************************");
            CenterText("");
            //Console.WriteLine(" -------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void ShowLibraryMenu() {

            Console.ForegroundColor = ConsoleColor.Green;
            CenterText("");
            CenterText(" --------------------------");
            CenterText(" | 1 . Add Book           |");
            CenterText(" | 2 . Remove Book        |");
            CenterText(" | 3 . Search Book        |");
            CenterText(" | 4 . Check Out Book     |");
            CenterText(" | 5 . Return Book        |");
            CenterText(" | 6 . View All Book      |");
            CenterText(" | 7 . Exit               |");
            CenterText(" --------------------------");
            CenterText(" --------------------------");
            CenterText("");
            Console.ForegroundColor = ConsoleColor.Green;

        }

        public static void DisplayExitMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine(" -------------------------------------------------------------------------------------");
            CenterText("");
            CenterText("");
            CenterText(" *************************************************************************************");
            CenterText(" *                          T H A N K   Y O U   F O R  U S I N G                     *");
            CenterText(" *                                                                                   *");
            CenterText(" *                   L I B R A R Y   M A N A G E M E N T   S Y S T E M               *");
            CenterText(" *                                                                                   *");
            CenterText(" *                             B Y  S A H I L   T R I V E D I                        *");
            CenterText(" *************************************************************************************");
            CenterText("");
            CenterText("");
            CenterText("");
            //Console.WriteLine(" -------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void CenterText(string text)
        {
            // Get the width of the console
            int consoleWidth = Console.WindowWidth;

            // Calculate the starting position for the text
            int padding = (consoleWidth - text.Length) / 2;

            // Ensure padding is not negative
            padding = Math.Max(0, padding);

            // Print the text with padding
            Console.WriteLine(new string(' ', padding) + text);
        }
    }
}
