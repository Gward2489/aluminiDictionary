using Microsoft.Data.Sqlite;

namespace aluminiDictionary
{
    public class Student
    {
        public int getStudentsCohortId (string dayOrNight, int cohortNumber)
        {
            int cohortId = 0;
            dbRouter dbStringGetter = new dbRouter();
            string dbstring = dbStringGetter.getDbString();
            DatabaseInterface db = new DatabaseInterface(dbstring);

            db.Query($@"SELECT Id FROM Cohort WHERE MeetTime='{dayOrNight}' AND Name={cohortNumber}",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        cohortId = reader.GetInt32(0);
                    }
                }
            );
            return cohortId;
        }
    }
}