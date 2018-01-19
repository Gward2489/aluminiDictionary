using Microsoft.Data.Sqlite;

namespace aluminiDictionary
{
    public class Instructor
    {
        public (int, int) JoinInfo (string instructorName, string instructorMeetTime, int cohortNumber)
        {
            int instructorId = 0;
            Cohort cohort = new Cohort();
            int cohortId = cohort.getCohortId(instructorMeetTime, cohortNumber);
            dbRouter dbStringGetter = new dbRouter();   
            string dbstring = dbStringGetter.getDbString();
            DatabaseInterface db = new DatabaseInterface(dbstring);

            db.Query($@"
                SELECT Id FROM Instructors WHERE Name='{instructorName}'",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        instructorId = reader.GetInt32(0);
                    }
                }
            );

            (int, int) joinIds = (instructorId, cohortId); 
            return joinIds;
            

        }
    }
}