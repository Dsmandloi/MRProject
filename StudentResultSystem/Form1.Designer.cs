

namespace StudentResultSystem
{
    partial class Form1
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

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtRoll = new TextBox();
            txtClass = new TextBox();
            txtSection = new TextBox();
            btnSave = new Button();
            dgvStudents = new DataGridView();
            lblName = new Label();
            lblRoll = new Label();
            lblClass = new Label();
            lblSection = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(171, 33);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(255, 31);
            txtName.TabIndex = 0;
            // 
            // txtRoll
            // 
            txtRoll.Location = new Point(171, 100);
            txtRoll.Margin = new Padding(4, 5, 4, 5);
            txtRoll.Name = "txtRoll";
            txtRoll.Size = new Size(255, 31);
            txtRoll.TabIndex = 1;
            // 
            // txtClass
            // 
            txtClass.Location = new Point(171, 167);
            txtClass.Margin = new Padding(4, 5, 4, 5);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(255, 31);
            txtClass.TabIndex = 2;
            // 
            // txtSection
            // 
            txtSection.Location = new Point(171, 233);
            txtSection.Margin = new Padding(4, 5, 4, 5);
            txtSection.Name = "txtSection";
            txtSection.Size = new Size(255, 31);
            txtSection.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(171, 300);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 50);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save Student";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += button1_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(29, 383);
            dgvStudents.Margin = new Padding(4, 5, 4, 5);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 62;
            dgvStudents.RowTemplate.Height = 25;
            dgvStudents.Size = new Size(857, 417);
            dgvStudents.TabIndex = 6;
            dgvStudents.CellContentClick += dgvStudents_CellContentClick;
            dgvStudents.CellDoubleClick += dgvStudents_CellDoubleClick;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(29, 38);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(63, 25);
            lblName.TabIndex = 7;
            lblName.Text = "Name:";
            // 
            // lblRoll
            // 
            lblRoll.AutoSize = true;
            lblRoll.Location = new Point(29, 105);
            lblRoll.Margin = new Padding(4, 0, 4, 0);
            lblRoll.Name = "lblRoll";
            lblRoll.Size = new Size(115, 25);
            lblRoll.TabIndex = 8;
            lblRoll.Text = "Roll Number:";
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(29, 172);
            lblClass.Margin = new Padding(4, 0, 4, 0);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(56, 25);
            lblClass.TabIndex = 9;
            lblClass.Text = "Class:";
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Location = new Point(29, 238);
            lblSection.Margin = new Padding(4, 0, 4, 0);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(74, 25);
            lblSection.TabIndex = 10;
            lblSection.Text = "Section:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 833);
            Controls.Add(lblSection);
            Controls.Add(lblClass);
            Controls.Add(lblRoll);
            Controls.Add(lblName);
            Controls.Add(dgvStudents);
            Controls.Add(btnSave);
            Controls.Add(txtSection);
            Controls.Add(txtClass);
            Controls.Add(txtRoll);
            Controls.Add(txtName);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Student Management";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtRoll;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpenSubjectForm;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblSection;
    }
}

