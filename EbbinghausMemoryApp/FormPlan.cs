using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EbbinghausMemoryApp
{
    public partial class FormPlan : Form
    {
        public FormPlan(List<string> books)
        {
            InitializeComponent();
            this.cmbBook.Items.AddRange(books.ToArray());
            if (this.cmbBook.Items.Count > 0)
                this.cmbBook.SelectedIndex = 0;

            dtpBeginDate.Value = DateTime.Today;
        }

        #region prop
        public string BookName { get { return this.cmbBook.Text; } }
        public int LessonDay { get { return Convert.ToInt32(tbLessonDay.Text); } }
        public int LessonTotal { get { return Convert.ToInt32(tbLessonTotal.Text); } }
        public int LessonBegin { get { return Convert.ToInt32(tbLessonBegin.Text); } }
        public DateTime BeginDate { get { return dtpBeginDate.Value; } }
        #endregion
        private void btnOK_Click(object sender, EventArgs e)
        {
            //check
            if (string.IsNullOrEmpty(this.cmbBook.Text))
            {
                MessageBox.Show("教材不能为空！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.tbLessonDay.Text))
            {
                MessageBox.Show("请输入每天课时！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.tbLessonTotal.Text))
            {
                MessageBox.Show("请输入教材的总课时！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.tbLessonBegin.Text))
            {
                MessageBox.Show("请输入开始课时！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //logic
            if (this.LessonDay > this.LessonTotal)
            {
                MessageBox.Show("每日课程不能大于总课时！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.LessonBegin > this.LessonTotal)
            {
                MessageBox.Show("开始课时不能大于总课时！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void tbLessonDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
