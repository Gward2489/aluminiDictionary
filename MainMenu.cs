using System;

namespace aluminiDictionary
{
    public class MainMenu
    {
        public static int Show()
        {
                        Console.Clear();
            Console.WriteLine ("WELCOME TO NSS ALUMINI DICTIONARY");
            Console.WriteLine ("*********************************");
            Console.Write ("> ");
            ConsoleKeyInfo enteredKey = Console.ReadKey();
            Console.WriteLine("");
            return int.Parse(enteredKey.KeyChar.ToString());
        }
    }
}