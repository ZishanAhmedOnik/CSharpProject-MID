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
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (teacherNameTextBox.Text.Length != 0)
            {
                Teacher teacherObj = new Teacher();
                teacherObj.NAME = teacherNameTextBox.Text;

                TeacherData teacherData = new TeacherData();
                teacherData.Insert(teacherObj);

                populate();
            }
        }

        private void populate()
        {
            TeacherData teacherData = new TeacherData();
            TeacherDataGrid.DataSource = teacherData.getList();
        }
    }
}
