using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Framework;
using Entities;

namespace DataLayer
{
    public class StudentData
    {
        DataAccess _da = new DataAccess();
        public void Insert(Student obj)
        {
            string insertCommand = "INSERT INTO Student (Name) " +
                                   "VALUES (@Name)";
            SqlCommand command = new SqlCommand(insertCommand);
            
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            nameParameter.Value = obj.Name;
            command.Parameters.Add(nameParameter);

            _da.Execute(command);
        }

        public void Delete(int id)
        {
            string insertCommand = "DELETE Student " +
                                   "WHERE ID = @ID";
            SqlCommand command = new SqlCommand(insertCommand);
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;

            command.Parameters.Add(idParameter);

            _da.Execute(command);
        }

        public void Update(Student obj)
        {
            string insertCommand = "UPDATE Student SET Name = @Name " +
                                   "WHERE ID = @ID";
            SqlCommand command = new SqlCommand(insertCommand);
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = obj.ID;
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            nameParameter.Value = obj.Name;
            command.Parameters.Add(idParameter);
            command.Parameters.Add(nameParameter);

            _da.Execute(command);
        }

        public DataTable Query()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student");
            return _da.Query(command);
        }

        public List<Student> GetList()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student");
            DataTable dt = _da.Query(command);

            List<Student> studentList = new List<Student>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student obj = new Student();
                obj.ID = int.Parse(dt.Rows[i][0].ToString());
                obj.Name = dt.Rows[i][1].ToString();

                studentList.Add(obj);
            }

            return studentList;
        }
    }
}
