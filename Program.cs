using System;

namespace aluminiDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            dbRouter dbStringGetter = new dbRouter();

            string dbstring = dbStringGetter.getDbString();

            DatabaseInterface db = new DatabaseInterface(dbstring);

            db.CheckCohortTable();
            db.CheckStudentsTable();
            db.CheckInstructorsTable();
            db.CheckCohortInstructorJoinTable();

            int choice;

            do
            {
                choice = MainMenu.Show();
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter Cohort Name");
                        string CohortName = Console.ReadLine();
                        Console.WriteLine("Enter Back End Language");
                        string CohortLanguage = Console.ReadLine();
                        Console.WriteLine("Evening or  Day Cohort?");
                        string MeetTime = Console.ReadLine();

                        // Insert customer account into database
                        db.Insert($@"
                            INSERT INTO Cohort
                            (Id, Name, Language, MeetTime)
                            VALUES
                            (null, '{CohortName}','{CohortLanguage}', '{MeetTime}')
                        ");

                        break;
                    case 2:
                        Console.WriteLine("Enter Student Name");
                        string StudentName = Console.ReadLine();
                        Console.WriteLine("Which Cohort did Student attend?");
                        string StudentCohort = Console.ReadLine();

                        // Insert customer account into database
                        db.Insert($@"
                            INSERT INTO Students
                            (Id, Name, Cohort)
                            VALUES
                            (null, '{StudentName}','{StudentCohort}')
                        ");
                        break;
                }
            } while (choice !=6);


        }
    }
}
