using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StudentDb.Framework;
using StudentDb.Entities;
using StudentDb.UserInterface;

namespace StudentDb.DataLayer
{
    class RegistrationData
    {
        private DataAccess dataAccess = new DataAccess();

        public void Insert(Registration regObj)
        {
            string insertQuery = "INSERT INTO Registraton (STUDENTID, COURSEID) VALUES (@STUDENTID, @COURSEID)";

            SqlCommand insertCommand = new SqlCommand(insertQuery);

            SqlParameter studentIDParam = new SqlParameter("@STUDENTID", SqlDbType.Int);
            studentIDParam.Value = regObj.STUDENTID;

            SqlParameter courseIDParam = new SqlParameter("@COURSEID", SqlDbType.Int);
            courseIDParam.Value = regObj.COURSEID;

            insertCommand.Parameters.Add(studentIDParam);
            insertCommand.Parameters.Add(courseIDParam);

            dataAccess.Execute(insertCommand);
        }

        public void QueryByStudent(Student studentObje)
        {
            string studentQuery = "SELECT * FROM Student WHERE ID = @ID";
            string registrationQuery = "SELECT COURSEID FROM Registraton WHERE STUDENTID = @ID";

            SqlCommand studentCommand = new SqlCommand(studentQuery);
            SqlCommand registrationCommand = new SqlCommand(registrationQuery);

            SqlParameter studentIDParam = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter courSeIDParam = new SqlParameter("@ID", SqlDbType.Int);

            studentIDParam.Value = studentObje.ID;
            courSeIDParam.Value = studentObje.ID;

            studentCommand.Parameters.Add(studentIDParam);
            registrationCommand.Parameters.Add(courSeIDParam);

            Console.WriteLine("Studnet Info: ");
            CommonUI.ShowTable(dataAccess.Query(studentCommand));

            
            Console.WriteLine("Registration: ");
            ShowCourseName(dataAccess.Query(registrationCommand));
        }

        private void ShowCourseName(DataTable dt)
        {
            string courseCommand = "SELECT * FROM Course WHERE ID = ";

            bool start = true;

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if (start)
                {
                    start = false;
                }
                else
                {
                    courseCommand += " OR ID = ";
                }
                courseCommand += dt.Rows[i][0];
            }

            SqlCommand query = new SqlCommand(courseCommand);
            CommonUI.ShowTable(dataAccess.Query(query));
        }

        public void QueryByCourse(Course courseObj)
        {
            string courseQuery = "SELECT * FROM Course WHERE ID = @ID";
            string registraionQuery = "SELECT STUDENTID FROM Registraton WHERE COURSEID = @ID";

            SqlCommand courseCommand = new SqlCommand(courseQuery);
            SqlCommand registraionCommand = new SqlCommand(registraionQuery);

            SqlParameter courseIDParam = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter regCourseIDParam = new SqlParameter("@ID", SqlDbType.Int);

            courseIDParam.Value = courseObj.ID;
            regCourseIDParam.Value = courseObj.ID;

            courseCommand.Parameters.Add(courseIDParam);
            registraionCommand.Parameters.Add(regCourseIDParam);

            Console.WriteLine("Course Info: ");
            CommonUI.ShowTable(dataAccess.Query(courseCommand));

            Console.WriteLine("Registration Info: ");
            
            ShowStudentName(dataAccess.Query(registraionCommand));
        }

        private void ShowStudentName(DataTable dt)
        {
            string courseCommand = "SELECT * FROM Student WHERE ID = ";

            bool start = true;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (start)
                {
                    start = false;
                }
                else
                {
                    courseCommand += " OR ID = ";
                }
                courseCommand += dt.Rows[i][0];
            }

            SqlCommand query = new SqlCommand(courseCommand);
            CommonUI.ShowTable(dataAccess.Query(query));
        }

        public DataTable QueryFullTable()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Registraton");

            return dataAccess.Query(command);
        }

        public void Update(Registration regObj, int changedCourseID)
        {
            string updateQuery = "UPDATE Registraton SET COURSEID = @COURSEID WHERE STUDENTID = @STUDENTID AND COURSEID = @COURSEIDTOSET";

            SqlCommand updateCommand = new SqlCommand(updateQuery);

            SqlParameter studentIDParam = new SqlParameter("@STUDENTID", SqlDbType.Int);
            studentIDParam.Value = regObj.STUDENTID;

            SqlParameter courseToSetIDParam = new SqlParameter("@COURSEIDTOSET", SqlDbType.Int);
            courseToSetIDParam.Value = regObj.COURSEID;

            SqlParameter changedCourseIDParam = new SqlParameter("@COURSEID", SqlDbType.Int);
            changedCourseIDParam.Value = changedCourseID;

            updateCommand.Parameters.Add(courseToSetIDParam);
            updateCommand.Parameters.Add(studentIDParam);
            updateCommand.Parameters.Add(changedCourseIDParam);
            

            dataAccess.Execute(updateCommand);
        }

        public void DeleteOneRegistraion(Registration regObj)
        {
            string deleteQuery = "DELETE Registraton WHERE STUDENTID = @STUDENTID AND COURSEID = @COURSEID";

            SqlCommand deleteCommand = new SqlCommand(deleteQuery);

            SqlParameter studentIDParam = new SqlParameter("@STUDENTID", SqlDbType.Int);
            studentIDParam.Value = regObj.STUDENTID;

            SqlParameter courseIDParam = new SqlParameter("@COURSEID", SqlDbType.Int);
            courseIDParam.Value = regObj.COURSEID;

            deleteCommand.Parameters.Add(studentIDParam);
            deleteCommand.Parameters.Add(courseIDParam);

            dataAccess.Execute(deleteCommand);
        }

        public void DeleteAllRegistraion(int studentID)
        {
            string deleteAllQuery = "DELETE Registraton WHERE ID = @STUDENTID";

            SqlCommand deleteAllCommand = new SqlCommand(deleteAllQuery);

            SqlParameter studentIdParam = new SqlParameter("@STUDENTID", SqlDbType.Int);
            studentIdParam.Value = studentID;

            dataAccess.Execute(deleteAllCommand);
        }
    }
}
