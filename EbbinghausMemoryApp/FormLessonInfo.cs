/******************************************************************************
 * 作者:      ee4ga9d@gmail.com
 * 日期:      2024-07-18
 * 描述:      课程信息窗体。
 * 版本:      1.0
 * 版权:      x.com/0EE4GA9d © 2024
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EbbinghausMemoryApp
{
    public partial class FormLessonInfo : Form
    {
        private List<string> existingBooks;

        public string LessonName { get; private set; }

        public FormLessonInfo(List<string> books)
        {
            InitializeComponent();
            this.tbLesson.Text = "";

            existingBooks = books;
            this.cmbBook.Items.AddRange(existingBooks.ToArray());
            if (this.cmbBook.Items.Count > 0)
                this.cmbBook.SelectedIndex = 0;
        }
        public string BookName
        {
            get
            { return cmbBook.Text; }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            var newLessony = tbLesson.Text.Trim();
            if (string.IsNullOrEmpty(newLessony))
            {
                MessageBox.Show("学习内容不能为空！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cmbBook.SelectedIndex == -1)
            {
                MessageBox.Show("教材不能为空！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LessonName = newLessony;
            DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
