using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;

namespace UI
{
    public partial class RegstrationForm : Form
    {
        public RegstrationForm()
        {
            InitializeComponent();
        }

        private void RegstrationForm_Load(object sender, EventArgs e)
        {
            RegistrationData regData = new RegistrationData();
            registraionDataGrid.DataSource = regData.getList();
        }
    }
}
