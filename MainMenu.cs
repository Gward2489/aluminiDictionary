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
            Console.WriteLine ("1. Create Cohort");
            Console.WriteLine ("2. Create Student");
            Console.WriteLine ("3. Create Instructor");
            Console.WriteLine ("4. Assign Instructor to Cohort");
            Console.WriteLine ("5. View Cohort Info");

            Console.Write ("> ");
            ConsoleKeyInfo enteredKey = Console.ReadKey();
            Console.WriteLine("");
            return int.Parse(enteredKey.KeyChar.ToString());
        }
    }
}