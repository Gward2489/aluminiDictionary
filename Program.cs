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



        }
    }
}
