

namespace StudentResultSystem
{
    partial class FormSubject
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtStudentId = new TextBox();
            txtSubjectName = new TextBox();
            txtMarksObtained = new TextBox();
            txtMaxMarks = new TextBox();
            btnSaveSubject = new Button();
            btnOpenResultForm = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(222, 52);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 0;
            label1.Text = "Student ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 95);
            label2.Name = "label2";
            label2.Size = new Size(122, 25);
            label2.TabIndex = 1;
            label2.Text = "Subject Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(222, 143);
            label4.Name = "label4";
            label4.Size = new Size(139, 25);
            label4.TabIndex = 2;
            label4.Text = "Marks Obtained";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(222, 190);
            label5.Name = "label5";
            label5.Size = new Size(144, 25);
            label5.TabIndex = 3;
            label5.Text = "Maximum Marks";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(475, 46);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(150, 31);
            txtStudentId.TabIndex = 4;
           // txtStudentId.TextChanged += txtStudentId_TextChanged_1;

            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(475, 89);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(150, 31);
            txtSubjectName.TabIndex = 5;
            // 
            // txtMarksObtained
            // 
            txtMarksObtained.Location = new Point(475, 137);
            txtMarksObtained.Name = "txtMarksObtained";
            txtMarksObtained.Size = new Size(150, 31);
            txtMarksObtained.TabIndex = 6;
            // 
            // txtMaxMarks
            // 
            txtMaxMarks.Location = new Point(475, 184);
            txtMaxMarks.Name = "txtMaxMarks";
            txtMaxMarks.Size = new Size(150, 31);
            txtMaxMarks.TabIndex = 7;
            // 
            // btnSaveSubject
            // 
            btnSaveSubject.Location = new Point(308, 240);
            btnSaveSubject.Name = "btnSaveSubject";
            btnSaveSubject.Size = new Size(150, 34);
            btnSaveSubject.TabIndex = 8;
            btnSaveSubject.Text = "Save Subject";
            btnSaveSubject.UseVisualStyleBackColor = true;
            btnSaveSubject.Click += btnSaveSubject_Click;
            // 
            // btnOpenResultForm
            // 
            btnOpenResultForm.Location = new Point(475, 240);
            btnOpenResultForm.Name = "btnOpenResultForm";
            btnOpenResultForm.Size = new Size(155, 34);
            btnOpenResultForm.TabIndex = 9;
            btnOpenResultForm.Text = "Open Result";
            btnOpenResultForm.UseVisualStyleBackColor = true;
            btnOpenResultForm.Click += btnOpenResultForm_Click;
            // 
            // FormSubject
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 557);
            Controls.Add(btnOpenResultForm);
            Controls.Add(btnSaveSubject);
            Controls.Add(txtMaxMarks);
            Controls.Add(txtMarksObtained);
            Controls.Add(txtSubjectName);
            Controls.Add(txtStudentId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormSubject";
            Text = "FormSubject";
            Load += FormSubject_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private TextBox txtStudentId;
        private TextBox txtSubjectName;
        private TextBox txtMarksObtained;
        private TextBox txtMaxMarks;
        private Button btnSaveSubject;
        private Button btnOpenResultForm;
    }
}
