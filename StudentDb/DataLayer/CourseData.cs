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
    class CourseData
    {
        private DataAccess dataAccess = new DataAccess();

        public void Insert(Course courseObj)
        {
            string insertQuery = "INSERT INTO Course (NAME) VALUES(@NAME)";

            SqlCommand insertCommand = new SqlCommand(insertQuery);

            SqlParameter nameParam = new SqlParameter("@NAME", SqlDbType.NVarChar, 50);
            nameParam.Value = courseObj.NAME;

            insertCommand.Parameters.Add(nameParam);

            dataAccess.Execute(insertCommand);
        }

        public void Delete(int id)
        {
            string deleteQuery = "DELETE Course WHERE ID = @ID";

            SqlCommand deleteCommand = new SqlCommand(deleteQuery);

            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            idParam.Value = id;

            deleteCommand.Parameters.Add(idParam);

            dataAccess.Execute(deleteCommand);
        }

        public void Update(Course courseObje)
        {
            string updateQuery = "UPDATE Course SET NAME = @NAME WHERE ID = @ID";

            SqlCommand updateCommand = new SqlCommand(updateQuery);

            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            idParam.Value = courseObje.ID;

            SqlParameter nameParam = new SqlParameter("@NAME", SqlDbType.NVarChar, 50);
            nameParam.Value = courseObje.NAME;


            updateCommand.Parameters.Add(idParam);
            updateCommand.Parameters.Add(nameParam);

            dataAccess.Execute(updateCommand);
        }

        public DataTable Query()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Course");

            return dataAccess.Query(sqlCommand);
        }
    }
}
