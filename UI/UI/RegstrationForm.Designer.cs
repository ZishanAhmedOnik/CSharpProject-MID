namespace UI
{
    partial class RegstrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registraionDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.registraionDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // registraionDataGrid
            // 
            this.registraionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registraionDataGrid.Location = new System.Drawing.Point(13, 13);
            this.registraionDataGrid.Name = "registraionDataGrid";
            this.registraionDataGrid.Size = new System.Drawing.Size(240, 318);
            this.registraionDataGrid.TabIndex = 0;
            // 
            // RegstrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 343);
            this.Controls.Add(this.registraionDataGrid);
            this.Name = "RegstrationForm";
            this.Text = "RegstrationForm";
            this.Load += new System.EventHandler(this.RegstrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.registraionDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView registraionDataGrid;
    }
}