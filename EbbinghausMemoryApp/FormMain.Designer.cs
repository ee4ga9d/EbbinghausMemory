namespace EbbinghausMemoryApp
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_AddBook = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_ClearAllLesson = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_delBook = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_AddLesson = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_delLesson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_Modify = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ppm_TodayTask = new System.Windows.Forms.ToolStripMenuItem();
            this.ppm_AddLesson = new System.Windows.Forms.ToolStripMenuItem();
            this.ppm_ExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsm_Task = new System.Windows.Forms.ToolStripMenuItem();
            this.mmi_Study = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_Review = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mm_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Tool = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_StudyPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_StudyFinish = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_Feedback = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsp_AddBook = new System.Windows.Forms.ToolStripButton();
            this.tsp_addLesson = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbTodoList = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbExp = new System.Windows.Forms.TextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList1;
            this.treeView.Location = new System.Drawing.Point(0, 63);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(211, 549);
            this.treeView.TabIndex = 1;
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyDown);
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_AddBook,
            this.mi_ClearAllLesson,
            this.mi_delBook,
            this.toolStripMenuItem2,
            this.mi_AddLesson,
            this.mi_delLesson,
            this.toolStripMenuItem3,
            this.mi_Modify});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 148);
            // 
            // mi_AddBook
            // 
            this.mi_AddBook.Image = global::EbbinghausMemoryApp.Properties.Resources.培训学习;
            this.mi_AddBook.Name = "mi_AddBook";
            this.mi_AddBook.Size = new System.Drawing.Size(126, 22);
            this.mi_AddBook.Text = "增加教材";
            this.mi_AddBook.Click += new System.EventHandler(this.mi_AddBook_Click);
            // 
            // mi_ClearAllLesson
            // 
            this.mi_ClearAllLesson.Name = "mi_ClearAllLesson";
            this.mi_ClearAllLesson.Size = new System.Drawing.Size(126, 22);
            this.mi_ClearAllLesson.Text = "清空课程";
            this.mi_ClearAllLesson.Click += new System.EventHandler(this.mi_ClearAllLesson_Click);
            // 
            // mi_delBook
            // 
            this.mi_delBook.Name = "mi_delBook";
            this.mi_delBook.Size = new System.Drawing.Size(126, 22);
            this.mi_delBook.Text = "删除教材";
            this.mi_delBook.Click += new System.EventHandler(this.mi_delBook_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(123, 6);
            // 
            // mi_AddLesson
            // 
            this.mi_AddLesson.Image = global::EbbinghausMemoryApp.Properties.Resources.增加;
            this.mi_AddLesson.Name = "mi_AddLesson";
            this.mi_AddLesson.Size = new System.Drawing.Size(126, 22);
            this.mi_AddLesson.Text = "学习课程";
            this.mi_AddLesson.Click += new System.EventHandler(this.mi_AddLesson_Click);
            // 
            // mi_delLesson
            // 
            this.mi_delLesson.Name = "mi_delLesson";
            this.mi_delLesson.Size = new System.Drawing.Size(126, 22);
            this.mi_delLesson.Text = "删除课程";
            this.mi_delLesson.Click += new System.EventHandler(this.mi_delLesson_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(123, 6);
            // 
            // mi_Modify
            // 
            this.mi_Modify.Name = "mi_Modify";
            this.mi_Modify.Size = new System.Drawing.Size(126, 22);
            this.mi_Modify.Text = "修改";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "学习管理 (1).png");
            this.imageList1.Images.SetKeyName(1, "培训学习.png");
            this.imageList1.Images.SetKeyName(2, "课程任务.png");
            this.imageList1.Images.SetKeyName(3, "智能复习.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(211, 63);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 549);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip2;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "记忆曲线";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ppm_TodayTask,
            this.ppm_AddLesson,
            this.ppm_ExitApp});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(127, 70);
            // 
            // ppm_TodayTask
            // 
            this.ppm_TodayTask.Name = "ppm_TodayTask";
            this.ppm_TodayTask.Size = new System.Drawing.Size(126, 22);
            this.ppm_TodayTask.Text = "今日复习";
            this.ppm_TodayTask.Click += new System.EventHandler(this.mm_Review_Click);
            // 
            // ppm_AddLesson
            // 
            this.ppm_AddLesson.Image = global::EbbinghausMemoryApp.Properties.Resources.增加;
            this.ppm_AddLesson.Name = "ppm_AddLesson";
            this.ppm_AddLesson.Size = new System.Drawing.Size(126, 22);
            this.ppm_AddLesson.Text = "学习课程";
            this.ppm_AddLesson.Click += new System.EventHandler(this.mi_AddLesson_Click);
            // 
            // ppm_ExitApp
            // 
            this.ppm_ExitApp.Name = "ppm_ExitApp";
            this.ppm_ExitApp.Size = new System.Drawing.Size(126, 22);
            this.ppm_ExitApp.Text = "退出";
            this.ppm_ExitApp.Click += new System.EventHandler(this.mm_Exit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_Task,
            this.tsm_Tool,
            this.tsm_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1017, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsm_Task
            // 
            this.tsm_Task.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmi_Study,
            this.mm_Review,
            this.toolStripMenuItem6,
            this.mm_Exit});
            this.tsm_Task.Name = "tsm_Task";
            this.tsm_Task.Size = new System.Drawing.Size(45, 20);
            this.tsm_Task.Text = "任务";
            // 
            // mmi_Study
            // 
            this.mmi_Study.Image = global::EbbinghausMemoryApp.Properties.Resources.增加;
            this.mmi_Study.Name = "mmi_Study";
            this.mmi_Study.Size = new System.Drawing.Size(100, 22);
            this.mmi_Study.Text = "学习";
            this.mmi_Study.Click += new System.EventHandler(this.mi_AddLesson_Click);
            // 
            // mm_Review
            // 
            this.mm_Review.Name = "mm_Review";
            this.mm_Review.Size = new System.Drawing.Size(100, 22);
            this.mm_Review.Text = "复习";
            this.mm_Review.Click += new System.EventHandler(this.mm_Review_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(97, 6);
            // 
            // mm_Exit
            // 
            this.mm_Exit.Name = "mm_Exit";
            this.mm_Exit.Size = new System.Drawing.Size(100, 22);
            this.mm_Exit.Text = "退出";
            this.mm_Exit.Click += new System.EventHandler(this.mm_Exit_Click);
            // 
            // tsm_Tool
            // 
            this.tsm_Tool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mm_StudyPlan,
            this.mm_StudyFinish});
            this.tsm_Tool.Name = "tsm_Tool";
            this.tsm_Tool.Size = new System.Drawing.Size(45, 20);
            this.tsm_Tool.Text = "工具";
            // 
            // mm_StudyPlan
            // 
            this.mm_StudyPlan.Name = "mm_StudyPlan";
            this.mm_StudyPlan.Size = new System.Drawing.Size(126, 22);
            this.mm_StudyPlan.Text = "学习规划";
            this.mm_StudyPlan.Click += new System.EventHandler(this.mm_StudyPlan_Click);
            // 
            // mm_StudyFinish
            // 
            this.mm_StudyFinish.Name = "mm_StudyFinish";
            this.mm_StudyFinish.Size = new System.Drawing.Size(126, 22);
            this.mm_StudyFinish.Text = "完成率";
            this.mm_StudyFinish.Visible = false;
            // 
            // tsm_Help
            // 
            this.tsm_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mm_Help,
            this.mm_Feedback});
            this.tsm_Help.Name = "tsm_Help";
            this.tsm_Help.Size = new System.Drawing.Size(45, 20);
            this.tsm_Help.Text = "帮助";
            // 
            // mm_Help
            // 
            this.mm_Help.Name = "mm_Help";
            this.mm_Help.Size = new System.Drawing.Size(100, 22);
            this.mm_Help.Text = "帮助";
            this.mm_Help.Click += new System.EventHandler(this.mm_Help_Click);
            // 
            // mm_Feedback
            // 
            this.mm_Feedback.Name = "mm_Feedback";
            this.mm_Feedback.Size = new System.Drawing.Size(100, 22);
            this.mm_Feedback.Text = "反馈";
            this.mm_Feedback.Click += new System.EventHandler(this.mm_Feedback_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsp_AddBook,
            this.tsp_addLesson,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1017, 39);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsp_AddBook
            // 
            this.tsp_AddBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsp_AddBook.Image = ((System.Drawing.Image)(resources.GetObject("tsp_AddBook.Image")));
            this.tsp_AddBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsp_AddBook.Name = "tsp_AddBook";
            this.tsp_AddBook.Size = new System.Drawing.Size(36, 36);
            this.tsp_AddBook.Text = "toolStripButton3";
            this.tsp_AddBook.ToolTipText = "增加教材\r\n";
            this.tsp_AddBook.Click += new System.EventHandler(this.mi_AddBook_Click);
            // 
            // tsp_addLesson
            // 
            this.tsp_addLesson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsp_addLesson.Image = ((System.Drawing.Image)(resources.GetObject("tsp_addLesson.Image")));
            this.tsp_addLesson.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsp_addLesson.Name = "tsp_addLesson";
            this.tsp_addLesson.Size = new System.Drawing.Size(36, 36);
            this.tsp_addLesson.Text = "toolStripButton1";
            this.tsp_addLesson.ToolTipText = "增加今天学习任务";
            this.tsp_addLesson.Click += new System.EventHandler(this.mi_AddLesson_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(216, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 549);
            this.panel1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbTodoList);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(803, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 549);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "今日复习";
            // 
            // clbTodoList
            // 
            this.clbTodoList.CheckOnClick = true;
            this.clbTodoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbTodoList.FormattingEnabled = true;
            this.clbTodoList.Items.AddRange(new object[] {
            "111",
            "123123"});
            this.clbTodoList.Location = new System.Drawing.Point(3, 162);
            this.clbTodoList.Name = "clbTodoList";
            this.clbTodoList.Size = new System.Drawing.Size(208, 384);
            this.clbTodoList.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.tbExp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 145);
            this.panel2.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(72, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbExp
            // 
            this.tbExp.Location = new System.Drawing.Point(3, 3);
            this.tbExp.Multiline = true;
            this.tbExp.Name = "tbExp";
            this.tbExp.Size = new System.Drawing.Size(202, 110);
            this.tbExp.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(798, 63);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 549);
            this.splitter2.TabIndex = 14;
            this.splitter2.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 612);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "记忆曲线";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mi_AddBook;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mi_AddLesson;
        private System.Windows.Forms.ToolStripMenuItem mi_delBook;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem mi_ClearAllLesson;
        private System.Windows.Forms.ToolStripMenuItem mi_delLesson;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mi_Modify;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ppm_TodayTask;
        private System.Windows.Forms.ToolStripMenuItem ppm_AddLesson;
        private System.Windows.Forms.ToolStripMenuItem ppm_ExitApp;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsm_Task;
        private System.Windows.Forms.ToolStripMenuItem mmi_Study;
        private System.Windows.Forms.ToolStripMenuItem mm_Review;
        private System.Windows.Forms.ToolStripMenuItem tsm_Tool;
        private System.Windows.Forms.ToolStripMenuItem mm_StudyFinish;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsp_addLesson;
        private System.Windows.Forms.ToolStripButton tsp_AddBook;
        private System.Windows.Forms.ToolStripMenuItem mm_StudyPlan;
        private System.Windows.Forms.ToolStripMenuItem tsm_Help;
        private System.Windows.Forms.ToolStripMenuItem mm_Help;
        private System.Windows.Forms.ToolStripMenuItem mm_Feedback;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.CheckedListBox clbTodoList;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem mm_Exit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbExp;
    }
}

