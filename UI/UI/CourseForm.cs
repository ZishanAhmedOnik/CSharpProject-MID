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
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (courseNameTextBox.Text.Length != 0)
            {
                Course courseObj = new Course();
                courseObj.NAME = courseNameTextBox.Text;

                CourseData courseData = new CourseData();
                courseData.Insert(courseObj);

                populate();
            }
        }

        private void populate()
        {
            CourseData courseData = new CourseData();
            coureDataGrid.DataSource = courseData.getList();
        }
    }
}
