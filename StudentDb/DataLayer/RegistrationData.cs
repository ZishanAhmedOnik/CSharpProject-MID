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
            string insertQuery = "INSERT INTO Registration (STUDENTID, COURSEID) VALUES (@STUDENTID, @COURSEID)";

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
            string registrationQuery = "SELECT * FROM Registraion WHERE STUDENTID = @ID";

            SqlCommand studentCommand = new SqlCommand(studentQuery);
            SqlCommand registrationCommand = new SqlCommand(registrationQuery);

            SqlParameter studentIDParam = new SqlParameter("@ID", SqlDbType.Int);
            studentIDParam.Value = studentObje.ID;
            studentCommand.Parameters.Add(studentIDParam);
            registrationCommand.Parameters.Add(studentIDParam);

            Console.WriteLine("Studnet Info: ");
            CommonUI.ShowTable(dataAccess.Query(studentCommand));

            
            Console.WriteLine("Registration: ");
            CommonUI.ShowTable(dataAccess.Query(registrationCommand));
        }

        public void QueryByCourse(Course courseObj)
        {
            string courseQuery = "SELECT * FROM Course WHERE ID = @ID";
            string registraionQuery = "SELECT * FROM Registration WHERE COURSEID = @ID";

            SqlCommand courseCommand = new SqlCommand(courseQuery);
            SqlCommand registraionCommand = new SqlCommand(registraionQuery);

            SqlParameter courseIDParam = new SqlParameter("@ID", SqlDbType.Int);
            courseIDParam.Value = courseObj.ID;

            courseCommand.Parameters.Add(courseIDParam);
            registraionCommand.Parameters.Add(courseIDParam);

            Console.WriteLine("Course Info: ");
            CommonUI.ShowTable(dataAccess.Query(courseCommand));

            Console.WriteLine("Registration Info: ");
            CommonUI.ShowTable(dataAccess.Query(registraionCommand));
        }

        public DataTable QueryFullTable()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM REGISTRAION");

            return dataAccess.Query(command);
        }

        public void Update(Registration regObj)
        {
            string updateQuery = "UPDATE Registration SET COURSEID = @COURSEID WHERE STUDENTID = @STUDENTID";

            SqlCommand updateCommand = new SqlCommand(updateQuery);

            SqlParameter studentIDParam = new SqlParameter("@STUDENTID", SqlDbType.Int);
            studentIDParam.Value = regObj.STUDENTID;

            SqlParameter courseIDParam = new SqlParameter("@COURSEID", SqlDbType.Int);
            courseIDParam.Value = regObj.COURSEID;

            updateCommand.Parameters.Add(courseIDParam);
            updateCommand.Parameters.Add(studentIDParam);

            dataAccess.Execute(updateCommand);
        }

        public void DeleteOneRegistraion(Registration regObj)
        {
            string deleteQuery = "DELETE Registraion WHERE STUDENTID = @STUDENTID AND COURSEID = @COURSEID";

            SqlCommand deleteCommand = new SqlCommand(deleteQuery);

            SqlParameter studentIDParam = new SqlParameter("@STUDENTID", SqlDbType.Int);
            studentIDParam.Value = regObj.STUDENTID;

            SqlParameter courseIDParam = new SqlParameter("@COURSEID", SqlDbType.Int);
            courseIDParam.Value = regObj.COURSEID;

            dataAccess.Execute(deleteCommand);
        }

        public void DeleteAllRegistraion(int studentID)
        {
            string deleteAllQuery = "DELETE Registraion WHERE ID = @STUDENTID";

            SqlCommand deleteAllCommand = new SqlCommand(deleteAllQuery);

            SqlParameter studentIdParam = new SqlParameter("@STUDENTID", SqlDbType.Int);
            studentIdParam.Value = studentID;

            dataAccess.Execute(deleteAllCommand);
        }
    }
}
