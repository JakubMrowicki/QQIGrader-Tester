namespace QQIGrader
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            lblResult = new Label();
            txtRes = new TextBox();
            dataResults = new DataGridView();
            testCasesBindingSource = new BindingSource(components);
            btnExport = new Button();
            btnExit = new Button();
            TestID = new DataGridViewTextBoxColumn();
            Input = new DataGridViewTextBoxColumn();
            Expected = new DataGridViewTextBoxColumn();
            Actual = new DataGridViewTextBoxColumn();
            Result = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataResults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)testCasesBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(14, 16);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(141, 55);
            btnStart.TabIndex = 0;
            btnStart.Text = "Run Tests from CSV";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(171, 36);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 15);
            lblResult.TabIndex = 1;
            // 
            // txtRes
            // 
            txtRes.Enabled = false;
            txtRes.Location = new Point(536, 28);
            txtRes.Name = "txtRes";
            txtRes.ReadOnly = true;
            txtRes.Size = new Size(71, 23);
            txtRes.TabIndex = 2;
            txtRes.Text = "0/0";
            txtRes.TextAlign = HorizontalAlignment.Center;
            // 
            // dataResults
            // 
            dataResults.AllowUserToAddRows = false;
            dataResults.AllowUserToDeleteRows = false;
            dataResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataResults.Columns.AddRange(new DataGridViewColumn[] { TestID, Input, Expected, Actual, Result });
            dataResults.Location = new Point(14, 77);
            dataResults.Name = "dataResults";
            dataResults.ReadOnly = true;
            dataResults.RowTemplate.Height = 25;
            dataResults.Size = new Size(593, 361);
            dataResults.TabIndex = 3;
            // 
            // testCasesBindingSource
            // 
            testCasesBindingSource.DataSource = typeof(TestCases);
            // 
            // btnExport
            // 
            btnExport.Location = new Point(14, 450);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(97, 23);
            btnExport.TabIndex = 4;
            btnExport.Text = "Export to CSV";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(510, 450);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(97, 23);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // TestID
            // 
            TestID.HeaderText = "Test ID";
            TestID.Name = "TestID";
            TestID.ReadOnly = true;
            TestID.Width = 50;
            // 
            // Input
            // 
            Input.HeaderText = "Input";
            Input.Name = "Input";
            Input.ReadOnly = true;
            // 
            // Expected
            // 
            Expected.HeaderText = "Expected Result";
            Expected.Name = "Expected";
            Expected.ReadOnly = true;
            Expected.Width = 150;
            // 
            // Actual
            // 
            Actual.HeaderText = "Actual Result";
            Actual.Name = "Actual";
            Actual.ReadOnly = true;
            Actual.Width = 150;
            // 
            // Result
            // 
            Result.HeaderText = "Result";
            Result.Name = "Result";
            Result.ReadOnly = true;
            Result.Width = 95;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 485);
            Controls.Add(btnExit);
            Controls.Add(btnExport);
            Controls.Add(dataResults);
            Controls.Add(txtRes);
            Controls.Add(lblResult);
            Controls.Add(btnStart);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QQI Grading System";
            ((System.ComponentModel.ISupportInitialize)dataResults).EndInit();
            ((System.ComponentModel.ISupportInitialize)testCasesBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label lblResult;
        private TextBox txtRes;
        private DataGridView dataResults;
        private BindingSource testCasesBindingSource;
        private Button btnExport;
        private Button btnExit;
        private DataGridViewTextBoxColumn TestID;
        private DataGridViewTextBoxColumn Input;
        private DataGridViewTextBoxColumn Expected;
        private DataGridViewTextBoxColumn Actual;
        private DataGridViewTextBoxColumn Result;
    }
}