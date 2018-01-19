using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace aluminiDictionary
{
    public class Cohort
    {
        public int getCohortId (string dayOrNight, int cohortNumber)
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

        public string getCohortLanguage (int cohortId)
        {
            string cohortLanguage = "";
            dbRouter dbStringGetter = new dbRouter();
            string dbstring = dbStringGetter.getDbString();
            DatabaseInterface db = new DatabaseInterface(dbstring);
            db.Query($@"SELECT Language FROM Cohort WHERE Id={cohortId}",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        cohortLanguage = reader.GetString(0);
                    }
                }
            );
            return cohortLanguage;
        }

        public List<string> getStudents(int cohortId)
        {
            List<string> students = new List<string>();
            dbRouter dbStringGetter = new dbRouter();
            string dbstring = dbStringGetter.getDbString();
            DatabaseInterface db = new DatabaseInterface(dbstring);
            db.Query($@"
            SELECT Name FROM Students WHERE CohortId={cohortId}",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        students.Add(reader.GetString(0));
                    }
                }
            );
            return students;

        }
        public List<string> getInstructors(int cohortId)
        {
            List<string> instructorIds = new List<string>();
            dbRouter dbStringGetter = new dbRouter();
            string dbstring = dbStringGetter.getDbString();
            DatabaseInterface db = new DatabaseInterface(dbstring);
            db.Query($@"
            SELECT InstructorId FROM CohortInstructorJoin WHERE CohortId={cohortId}",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        instructorIds.Add(reader.GetString(0));
                    }
                }
            );

            List<string>instructorNames = new List<string>();
            foreach (string id in instructorIds)
            {
              db.Query($@"
                SELECT Name FROM Instructors WHERE Id={id}",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        instructorNames.Add(reader.GetString(0));
                    }
                }
            );  
            }
            return instructorNames;

        }
    }
}