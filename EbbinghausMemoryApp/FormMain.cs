/******************************************************************************
 * 作者:      ee4ga9d@gmail.com
 * 日期:      2024-07-18
 * 描述:      主窗体。可增删书籍、课程，提醒每日应复习的课程。
 * 版本:      1.0
 * 版权:      x.com/0EE4GA9d © 2024
 ******************************************************************************/
using System;
using System.Timers;
using System.Windows.Forms;

namespace EbbinghausMemoryApp
{
    using EbbinghausMemoryApp.Controls;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class FormMain : Form
    {
        private System.Timers.Timer reviewTimer;

        const int IDX_IMG_CATEGORY = 0;
        const int IDX_IMG_BOOK = 1;
        const int IDX_IMG_LESSON = 2;

        Dictionary<int, Category> _DicCategory = null;
        Dictionary<int, BookItem> _DicBookItem = null;
        Dictionary<int, StudyItem> _DicStudyItem = null;

        long CONST_TIMER_GAP = 30 * 60 * 1000;// 每30分钟检查一次

        private CustomCalendar calendar;
        public FormMain()
        {
            InitializeComponent();
#if Release
            toolStripButton3.Visible = false;
#endif
            this.WindowState = FormWindowState.Maximized;

            PopulateTreeView();
#if !Release
            CONST_TIMER_GAP = 10 * 60 * 1000;
#endif
            reviewTimer = new System.Timers.Timer(CONST_TIMER_GAP);
            reviewTimer.Elapsed += ReviewTimer_Elapsed;
            reviewTimer.Start();

            calendar = new CustomCalendar
            {
                Dock = DockStyle.Fill,
                Width = 400
            };

            calendar.DateChanged += Calendar_DateChanged;
            calendar.DateClicked += Calendar_DateClicked;
            calendar.DateDoubleClicked += Calendar_DateDoubleClicked;

            panel1.Controls.Add(calendar);

            RefreshCalendar(DateTime.Today);

        }

        void RefreshCalendar(DateTime date)
        {
            // 初始化待办事项
            InitializeToDoItems(date);

            ShowToDoItemsForDate(date);
        }
        private void Calendar_DateDoubleClicked(object sender, DateDoubleClickedEventArgs e)
        {
            if (AddLesson(e.ClickedDate))
            {
                PopulateTreeView();
                RefreshCalendar(e.ClickedDate);
            }
        }

        private void InitializeToDoItems(DateTime date)
        {
            using (HelperClass h = new HelperClass())
            {
                var toDoItems = h.QueryMouthTask(date);
                calendar.SetToDoItems(toDoItems);
            }
        }

        private void Calendar_DateChanged(object sender, DateChangedEventArgs e)
        {
            InitializeToDoItems(e.NewDate);
            ShowToDoItemsForDate(e.NewDate);
        }

        private void Calendar_DateClicked(object sender, DateClickedEventArgs e)
        {
            // 处理日期点击事件，更新选中日期
            calendar.SelectedDate = e.ClickedDate;
            calendar.Invalidate();

            ShowToDoItemsForDate(e.ClickedDate);
        }

        private void ShowToDoItemsForDate(DateTime date)
        {
            clbTodoList.Items.Clear();
            if (calendar.ToDoItems.ContainsKey(date))
            {
                foreach (var item in calendar.ToDoItems[date])
                {
                    clbTodoList.Items.Add(item);
                    clbTodoList.SetItemCheckState(clbTodoList.Items.Count - 1, item.IsCompleted ? CheckState.Checked : CheckState.Unchecked);
                }
            }
        }

        private void ReviewTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            NotifyTask();
        }

        private void NotifyTask()
        {
            using (HelperClass h = new HelperClass())
            {
                bool b = h.QueryTaskCountByDate(DateTime.Today);
                if (!b)
                {
                    try
                    {
                        var contentBuilder = new Microsoft.Toolkit.Uwp.Notifications.ToastContentBuilder()
                            .AddArgument("action", "viewConversation")
                            .AddArgument("conversationId", 9813)
                            .AddText(this.Text)
                            .AddText("今天尚有复习任务未完成");
                        contentBuilder.Show();
                    }
                    catch (Exception ex)
                    {
                        LoggingService.Error(ex);
                        MessageBox.Show("今天尚有复习任务未完成！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void PopulateTreeView()
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            try
            {
                using (HelperClass h = new HelperClass())
                {
                    if (h.PopulateTreeView(ref _DicCategory, ref _DicBookItem, ref _DicStudyItem))
                    {
                        Dictionary<int, TreeNode> nodeBooks = new Dictionary<int, TreeNode>();
                        foreach (var bookitem in _DicBookItem.Values)
                        {
                            int icatId = (int)bookitem.CategoryId;
                            string sNodeText = bookitem.Content;
                            if (_DicCategory.ContainsKey(icatId))
                                sNodeText = $"{bookitem.Content}-{_DicCategory[icatId].Name}";
                            var bookNode = new TreeNode(sNodeText)
                            {
                                Tag = bookitem,
                                ImageIndex = IDX_IMG_BOOK,
                                SelectedImageIndex = IDX_IMG_BOOK
                            };
                            treeView.Nodes.Add(bookNode);
                            nodeBooks.Add((int)bookitem.Id, bookNode);
                        }

                        foreach (var item in _DicStudyItem.Values)
                        {
                            var itemNode = new TreeNode(item.Content)
                            {
                                Tag = item,
                                ImageIndex = IDX_IMG_LESSON,
                                SelectedImageIndex = IDX_IMG_LESSON
                            };
                            int ibookId = (int)item.BookId;
                            if (nodeBooks.ContainsKey(ibookId))
                                nodeBooks[ibookId].Nodes.Add(itemNode);
                        }
                        nodeBooks.Clear(); nodeBooks = null;
                    }
                }
            }
            finally
            {
                treeView.ExpandAll();
                treeView.EndUpdate();
            }

        }


        void AddBook()
        {
            using (HelperClass h = new HelperClass())
            {
                BookItem c = h.AddBook();
                if (c == null) return;

                TreeNode tNode = new TreeNode()
                {
                    ImageIndex = IDX_IMG_BOOK,
                    SelectedImageIndex = IDX_IMG_BOOK,
                    Text = c.Content,
                    Tag = c
                };
                this.treeView.Nodes.Add(tNode);
            }
        }

        bool AddLesson(DateTime date)
        {
            using (HelperClass h = new HelperClass())
            {
                if (!h.HasBooks)
                {
                    MessageBox.Show("当前尚未有教材，请先添加！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                StudyItem c = h.AddLesson(date);
                if (c == null) return false;
            }
            return true;
        }


        private void mi_AddBook_Click(object sender, EventArgs e)
        {
            AddBook();
        }

        private void mi_AddLesson_Click(object sender, EventArgs e)
        {
            if (AddLesson(DateTime.Today))
            {
                PopulateTreeView();
                RefreshCalendar(DateTime.Today);
            }
        }

        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            var node = this.treeView.GetNodeAt(e.X, e.Y);
            if (node == null) return;
            this.treeView.SelectedNode = node;

            //if (node.Tag is Category categoryItem)
            //{

            //}
            //else if (node.Tag is BookItem bookItem)
            //{

            //}
            //else if (node.Tag is StudyItem studyItem)
            //{

            //}
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            NotifyTask();
            ////test
            HelperClass h = new HelperClass();

            //h.AddLesson4Test(1, "L1-6", System.DateTime.Parse("2024-07-02"));
            //h.AddLesson4Test(1, "L7-14", System.DateTime.Parse("2024-07-03"));
            //h.AddLesson4Test(1, "L15-19", System.DateTime.Parse("2024-07-04"));
            //h.AddLesson4Test(1, "L20-26", System.DateTime.Parse("2024-07-05"));
            //h.AddLesson4Test(1, "L27-30", System.DateTime.Parse("2024-07-06"));
            //h.AddLesson4Test(1, "L31-32", System.DateTime.Parse("2024-07-07"));
            //h.AddLesson4Test(1, "L33-35", System.DateTime.Parse("2024-07-08"));
            //h.AddLesson4Test(1, "L36", System.DateTime.Parse("2024-07-10"));
            //h.AddLesson4Test(1, "L37", System.DateTime.Parse("2024-07-11"));
            //h.AddLesson4Test(1, "L38", System.DateTime.Parse("2024-07-12"));
            //h.AddLesson4Test(1, "L39", System.DateTime.Parse("2024-07-13"));
            //h.AddLesson4Test(1, "L40", System.DateTime.Parse("2024-07-14"));
            //h.AddLesson4Test(1, "L41", System.DateTime.Parse("2024-07-15"));

            h.DeleteAllStudy4Test();
            PopulateTreeView();
            RefreshCalendar(this.calendar.CurrentMonth);
        }

        private void mi_delBook_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView.SelectedNode;
            if (selectedNode != null && selectedNode.Tag is BookItem selectedItem)
            {
                int bookId = (int)selectedItem.Id;
                using (HelperClass h = new HelperClass())
                {
                    if (h.HasLessons(bookId))
                    {
                        MessageBox.Show("此教材下尚有课程，不能删除！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("确定删除此教材吗？", "确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //del 
                        if (h.DeleteBookItem(bookId))
                        {
                            PopulateTreeView();
                        }
                    }
                }
            }
        }

        private void mi_delLesson_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView.SelectedNode;
            if (selectedNode != null && selectedNode.Tag is StudyItem selectedItem)
            {
                int studyId = (int)selectedItem.Id;


                if (MessageBox.Show("确定删除此课程吗？", "确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (HelperClass h = new HelperClass())
                    {
                        if (h.DeleteLesson(studyId))
                        {
                            PopulateTreeView();
                            RefreshCalendar(this.calendar.CurrentMonth);
                        }
                    }
                }
            }
        }

        private void mi_ClearAllLesson_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView.SelectedNode;
            if (selectedNode != null && selectedNode.Tag is BookItem selectedItem)
            {
                if (selectedNode.Nodes.Count == 0) return;
                int bookId = (int)selectedItem.Id;
                if (MessageBox.Show("确定清空全部课程吗？", "确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (HelperClass h = new HelperClass())
                    {
                        if (h.DeleteLessonByBookId(bookId))
                        {
                            PopulateTreeView();
                            RefreshCalendar(this.calendar.CurrentMonth);
                        }
                    }
                }
            }
        }
        private void mm_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
#if Release
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;  
                this.WindowState = FormWindowState.Minimized; 
                this.Hide(); 
            }
           // base.OnFormClosing(e);
#endif
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void mm_Review_Click(object sender, EventArgs e)
        {
            NotifyTask();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //检查是否发生变化
            Dictionary<int, ToDoItem> dicOfChanged = new Dictionary<int, ToDoItem>();
            for (int i = 0; i < clbTodoList.Items.Count; i++)
            {
                ToDoItem item = this.clbTodoList.Items[i] as ToDoItem;
                CheckState cs = clbTodoList.GetItemCheckState(i);
                bool bNewState = Convert.ToBoolean((int)cs);
                if (bNewState != item.IsCompleted)
                {
                    item.IsCompleted = bNewState;
                    item.Experience = this.tbExp.Text;
                    dicOfChanged.Add(item.Id, item);
                }
            }
            if (dicOfChanged.Count == 0)
                return;
            //save
            using (HelperClass h = new HelperClass())
            {
                bool b = h.SaveReviewStates(dicOfChanged);
                if (b)
                    calendar.Invalidate();
                MessageBox.Show(b ? "保存成功！" : "保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dicOfChanged = null;
        }

        private void mm_Feedback_Click(object sender, EventArgs e)
        {
            string url = "https://x.com/0EE4GA9d";
            OpenUrl(url);
        }
        void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    }
                    catch (Exception innerEx)
                    {
                        MessageBox.Show($"无法打开浏览器: {innerEx.Message}");
                    }
                }
                else
                {
                    MessageBox.Show($"无法打开浏览器: {ex.Message}");
                }
            }
        }

        private void mm_Help_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/ee4ga9d";
            OpenUrl(url);
        }

        private void mm_StudyPlan_Click(object sender, EventArgs e)
        {
            using (HelperClass h = new HelperClass())
            {
                bool b = h.LessonPlan();
                if (b)
                {
                    RefreshCalendar(DateTime.Today);
                    this.PopulateTreeView();
                }
            }
        }
    }
}
