
namespace StudentResultSystem
{
    partial class FormResult
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
        private Button btnUpdateResult;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtStudentId = new TextBox();
            txtTotalMarks = new TextBox();
            txtMarksObtained = new TextBox();
            txtPercentage = new TextBox();
            txtGrade = new TextBox();
            txtStatus = new TextBox();
            rtbComments = new RichTextBox();
            btnGenerateResult = new Button();
            btnSaveResult = new Button();
            btnExportPdf = new Button();
            dgvResultHistory = new DataGridView();
            btnUpdateResult = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResultHistory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 30);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 0;
            label1.Text = "Student ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 70);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 2;
            label2.Text = "Total Marks";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 110);
            label3.Name = "label3";
            label3.Size = new Size(139, 25);
            label3.TabIndex = 4;
            label3.Text = "Obtained Marks";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 150);
            label4.Name = "label4";
            label4.Size = new Size(98, 25);
            label4.TabIndex = 6;
            label4.Text = "Percentage";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 190);
            label5.Name = "label5";
            label5.Size = new Size(100, 25);
            label5.TabIndex = 8;
            label5.Text = "Final Grade";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(50, 230);
            label6.Name = "label6";
            label6.Size = new Size(112, 25);
            label6.TabIndex = 10;
            label6.Text = "Result Status";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(50, 270);
            label7.Name = "label7";
            label7.Size = new Size(99, 25);
            label7.TabIndex = 12;
            label7.Text = "Comments";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(200, 25);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(150, 31);
            txtStudentId.TabIndex = 1;
            txtStudentId.TextChanged += txtStudentId_TextChanged;
            // 
            // txtTotalMarks
            // 
            txtTotalMarks.Location = new Point(200, 65);
            txtTotalMarks.Name = "txtTotalMarks";
            txtTotalMarks.Size = new Size(150, 31);
            txtTotalMarks.TabIndex = 3;
            // 
            // txtMarksObtained
            // 
            txtMarksObtained.Location = new Point(200, 105);
            txtMarksObtained.Name = "txtMarksObtained";
            txtMarksObtained.Size = new Size(150, 31);
            txtMarksObtained.TabIndex = 5;
            // 
            // txtPercentage
            // 
            txtPercentage.Location = new Point(200, 145);
            txtPercentage.Name = "txtPercentage";
            txtPercentage.Size = new Size(150, 31);
            txtPercentage.TabIndex = 7;
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(200, 185);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(150, 31);
            txtGrade.TabIndex = 9;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(200, 225);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(150, 31);
            txtStatus.TabIndex = 11;
            // 
            // rtbComments
            // 
            rtbComments.Location = new Point(200, 265);
            rtbComments.Name = "rtbComments";
            rtbComments.Size = new Size(370, 100);
            rtbComments.TabIndex = 13;
            rtbComments.Text = "";
            // 
            // btnGenerateResult
            // 
            btnGenerateResult.Location = new Point(370, 25);
            btnGenerateResult.Name = "btnGenerateResult";
            btnGenerateResult.Size = new Size(150, 34);
            btnGenerateResult.TabIndex = 14;
            btnGenerateResult.Text = "Generate Result";
            btnGenerateResult.Click += btnGenerateResult_Click;
            // 
            // btnSaveResult
            // 
            btnSaveResult.Location = new Point(200, 384);
            btnSaveResult.Name = "btnSaveResult";
            btnSaveResult.Size = new Size(150, 40);
            btnSaveResult.TabIndex = 15;
            btnSaveResult.Text = "Save Result";
            //btnSaveResult.Click += btnSaveResult_Click;
            // 
            // btnExportPdf
            // 
            btnExportPdf.Location = new Point(394, 384);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(157, 40);
            btnExportPdf.TabIndex = 16;
            btnExportPdf.Text = "Export to PDF";
            btnExportPdf.UseVisualStyleBackColor = true;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // dgvResultHistory
            // 
            dgvResultHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultHistory.Location = new Point(12, 430);
            dgvResultHistory.Name = "dgvResultHistory";
            dgvResultHistory.RowHeadersWidth = 62;
            dgvResultHistory.Size = new Size(1095, 234);
            dgvResultHistory.TabIndex = 17;
            // 
            // btnUpdateResult
            // 
            btnUpdateResult.Location = new Point(580, 384);
            btnUpdateResult.Name = "btnUpdateResult";
            btnUpdateResult.Size = new Size(157, 40);
            btnUpdateResult.TabIndex = 18;
            btnUpdateResult.Text = "Update Result";
            btnUpdateResult.UseVisualStyleBackColor = true;
            // 
            // FormResult
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 692);
            Controls.Add(dgvResultHistory);
            Controls.Add(btnExportPdf);
            Controls.Add(label1);
            Controls.Add(txtStudentId);
            Controls.Add(label2);
            Controls.Add(txtTotalMarks);
            Controls.Add(label3);
            Controls.Add(txtMarksObtained);
            Controls.Add(label4);
            Controls.Add(txtPercentage);
            Controls.Add(label5);
            Controls.Add(txtGrade);
            Controls.Add(label6);
            Controls.Add(txtStatus);
            Controls.Add(label7);
            Controls.Add(rtbComments);
            Controls.Add(btnGenerateResult);
            Controls.Add(btnSaveResult);
            Controls.Add(btnUpdateResult);
            Name = "FormResult";
            Text = "FormResult";
            Load += FormResult_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResultHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtStudentId;
        private TextBox txtTotalMarks;
        private TextBox txtObtainedMarks;
        private TextBox txtPercentage;
        private TextBox txtGrade;
        private TextBox txtStatus;
        private RichTextBox rtbComments;
        private Button btnGenerateResult;
        private Button btnSaveResult;
        private Button btnExportPdf;
        private DataGridView dgvResultHistory;
        private TextBox txtMarksObtained;
    }
}

