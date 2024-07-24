namespace EbbinghausMemoryApp
{
    partial class FormPlan
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLessonDay = new System.Windows.Forms.TextBox();
            this.tbLessonTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbLessonBegin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "教材";
            // 
            // cmbBook
            // 
            this.cmbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBook.FormattingEnabled = true;
            this.cmbBook.Location = new System.Drawing.Point(95, 22);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.Size = new System.Drawing.Size(203, 20);
            this.cmbBook.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "每天课时";
            // 
            // tbLessonDay
            // 
            this.tbLessonDay.Location = new System.Drawing.Point(95, 51);
            this.tbLessonDay.Name = "tbLessonDay";
            this.tbLessonDay.Size = new System.Drawing.Size(203, 21);
            this.tbLessonDay.TabIndex = 3;
            this.tbLessonDay.Text = "4";
            this.tbLessonDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLessonDay_KeyPress);
            // 
            // tbLessonTotal
            // 
            this.tbLessonTotal.Location = new System.Drawing.Point(95, 82);
            this.tbLessonTotal.Name = "tbLessonTotal";
            this.tbLessonTotal.Size = new System.Drawing.Size(203, 21);
            this.tbLessonTotal.TabIndex = 5;
            this.tbLessonTotal.Text = "144";
            this.tbLessonTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLessonDay_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "总课时";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(220, 190);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "生成计划";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(139, 190);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "取消";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // tbLessonBegin
            // 
            this.tbLessonBegin.Location = new System.Drawing.Point(95, 118);
            this.tbLessonBegin.Name = "tbLessonBegin";
            this.tbLessonBegin.Size = new System.Drawing.Size(203, 21);
            this.tbLessonBegin.TabIndex = 9;
            this.tbLessonBegin.Text = "45";
            this.tbLessonBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLessonDay_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "开始课时";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "开始日期";
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBeginDate.Location = new System.Drawing.Point(95, 148);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(200, 21);
            this.dtpBeginDate.TabIndex = 11;
            // 
            // FormPlan
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(320, 226);
            this.Controls.Add(this.dtpBeginDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbLessonBegin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbLessonTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLessonDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBook);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "计划";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLessonDay;
        private System.Windows.Forms.TextBox tbLessonTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox tbLessonBegin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
    }
}