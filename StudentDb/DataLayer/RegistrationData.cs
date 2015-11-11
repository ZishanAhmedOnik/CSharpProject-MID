using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StudentDb.Framework;
using StudentDb.Entities;

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
