using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using Entities;

namespace UI
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void studentInsertButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length != 0)
            {
                Student studentObj = new Student();
                studentObj.Name = nameTextBox.Text;

                StudentData studentData = new StudentData();
                studentData.Insert(studentObj);

                populate();
            }
        }

        private void populate()
        {
            StudentData studentData = new StudentData();
            studentDataGrid.DataSource = studentData.GetList();
        }
    }
}
