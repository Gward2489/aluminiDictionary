using System;
using System.Collections.Generic;

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

            Cohort cohort = new Cohort();
            Instructor instructor = new Instructor();
            

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


                        int cohortId = cohort.getCohortId(dayOrNight, StudentCohort);


                        db.Insert($@"
                            INSERT INTO Students
                            (Id, Name, CohortId)
                            VALUES
                            (null, '{StudentName}','{cohortId}')
                        ");
                        break;
                        // create a new instructor and insert it to the database
                    case 3:
                         //capture data needed to create a new cohort field in the db
                        Console.WriteLine("Enter Instructor Full Name");
                        string InstructorName = Console.ReadLine();


                        //insert new Instructor to db by passing in corresponding 
                        // SQL lite syntax to the insert method.
                        db.Insert($@"
                            INSERT INTO Instructors
                            (Id, Name)
                            VALUES
                            (null, '{InstructorName}')
                        ");
                        break;
                        // Create a Join table to represent the relationship between
                        // an instructor and the cohort they taught.
                    case 4:
                        Console.WriteLine("Instructor first and last name:(ex: Steve Brownlee)");
                        string InstructorToJoin = Console.ReadLine();
                        Console.WriteLine("Evening or Day Cohort?");
                        string InstructorMeetTime = Console.ReadLine();
                        Console.WriteLine("Cohort Number?");
                        int InstructorCohort = Convert.ToInt32(Console.ReadLine());

                        (int, int) cohortInfo = instructor.JoinInfo(InstructorToJoin, InstructorMeetTime, InstructorCohort); 

                        db.Insert($@"
                            INSERT INTO CohortInstructorJoin
                            (Id, InstructorId, CohortId)
                            VALUES
                            (null, {cohortInfo.Item1}, {cohortInfo.Item2})
                        ");

                        break;
                    case 5:
                        Console.WriteLine("Evening or Day?");
                        string displayMeetTime = Console.ReadLine();
                        Console.WriteLine("Cohort Number?"); 
                        int displayCohortNumber = Convert.ToInt32(Console.ReadLine());

                        int displayCohortId = cohort.getCohortId(displayMeetTime, displayCohortNumber);

                        string cohortLanguage = cohort.getCohortLanguage(displayCohortId);

                        List<string> students = cohort.getStudents(displayCohortId);
                        
                        List<string> instructors = cohort.getInstructors(displayCohortId);

                        Console.WriteLine($"{displayMeetTime}Cohort {displayCohortNumber}");
                        break;
                }
            } while (choice !=6);


        }
    }
}
