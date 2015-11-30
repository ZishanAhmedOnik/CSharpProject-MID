using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Framework;
using Entities;

namespace DataLayer
{
    public class TeacherData
    {
        DataAccess dataAccess = new DataAccess();

        public void Insert(Teacher teacherObj)
        {
            string insertCommand = "INSERT INTO Teacher (NAME) VALUES (@NAME)";

            SqlCommand sqlCommand = new SqlCommand(insertCommand);
            SqlParameter nameParam = new SqlParameter("@NAME", SqlDbType.VarChar);
            nameParam.Value = teacherObj.NAME;

            sqlCommand.Parameters.Add(nameParam);

            dataAccess.Execute(sqlCommand);
        }

        public void Update(Teacher teacherObj)
        {
            string updateCommand = "UPDATE Teacher SET NAME = @NAME WHERE ID = @ID";

            SqlCommand sqlCommand = new SqlCommand(updateCommand);
            SqlParameter nameParam = new SqlParameter("@NAME", SqlDbType.VarChar);
            nameParam.Value = teacherObj.NAME;

            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            idParam.Value = teacherObj.ID;

            sqlCommand.Parameters.Add(nameParam);
            sqlCommand.Parameters.Add(idParam);

            dataAccess.Execute(sqlCommand);
        }

        public void Delete(int ID)
        {
            string deleteCommand = "DELETE Teacher WHERE ID = @ID";

            SqlCommand sqlCommand = new SqlCommand(deleteCommand);

            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            idParam.Value = ID;

            sqlCommand.Parameters.Add(idParam);

            dataAccess.Execute(sqlCommand);
        }

        public DataTable Query()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Teacher");
            return dataAccess.Query(sqlCommand);
        }

        public List<Teacher> getList()
        {
            List<Teacher> teacherList = new List<Teacher>();

            SqlCommand command = new SqlCommand("SELECT * FROM Teacher");


            DataTable dt = dataAccess.Query(command);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Teacher teacherObj = new Teacher();
                teacherObj.ID = (int)dt.Rows[i][0];
                teacherObj.NAME = (string)dt.Rows[i][1];

                teacherList.Add(teacherObj);
            }

            return teacherList;
        }
    }
}
