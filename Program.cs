using System;

namespace aluminiDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            // create new instance of database router class.
            // this class is used to retreive the adress of the 
            // database the user's computer.
            dbRouter dbStringGetter = new dbRouter();

            // create string to hold the return value of the 
            // get dbString method.
            string dbstring = dbStringGetter.getDbString();

            // create a new instance of the Database Interface class,
            // which hold all of the primary methods for exchanging
            // data with the database.
            DatabaseInterface db = new DatabaseInterface(dbstring);

            // call a method for each table needed in the database.
            // the method will check the database to see if it already
            // has the table, if it does not, it will create the table
            db.CheckCohortTable();
            db.CheckStudentsTable();
            db.CheckInstructorsTable();
            db.CheckCohortInstructorJoinTable();

            // create an empty int variable to hold the value returned
            // from MainMenu.Show() This value will reflect the users menu choice.
            int choice;

            // invoke a do while loop that will run as long as the user's choice
            // in menu.show() is 1-5.
            do
            {
                // Invoke the Main Menu.Show() method which will write 
                // the menu options to the console and return the integer
                // value reflecting the user's selection
                choice = MainMenu.Show();

                // Use the switch() method to pass in the user's menu choice
                // and initiate the logic that correspond's to that menu option.
                switch(choice)
                {
                    // case 1 will create a new cohort
                    case 1:
                        //capture data needed to create a new cohort field in the db
                        Console.WriteLine("Evening or  Day Cohort?");
                        string MeetTime = Console.ReadLine();
                        Console.WriteLine("Cohort Number?");
                        int CohortName = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Back End Language");
                        string CohortLanguage = Console.ReadLine();

                        //insert new cohort to db by passing in corresponding 
                        // SQL lite syntax to the insert method.
                        db.Insert($@"
                            INSERT INTO Cohort
                            (Id, Name, Language, MeetTime)
                            VALUES
                            (null, {CohortName},'{CohortLanguage}', '{MeetTime}')
                        ");

                        break;
                    case 2:
                        Console.WriteLine("Enter Student Name");
                        string StudentName = Console.ReadLine();
                        Console.WriteLine("Evening or Day student?");
                        string dayOrNight = Console.ReadLine();
                        Console.WriteLine("Cohort Number?");
                        int StudentCohort = Convert.ToInt32(Console.ReadLine());

                        Student student = new Student();

                        int cohortId = student.getStudentsCohortId(dayOrNight, StudentCohort);


                        db.Insert($@"
                            INSERT INTO Students
                            (Id, Name, CohortId)
                            VALUES
                            (null, '{StudentName}','{cohortId}')
                        ");
                        break;
                }
            } while (choice !=6);


        }
    }
}
