/******************************************************************************
 * 作者:      ee4ga9d@gmail.com
 * 日期:      2024-07-18
 * 描述:      书籍信息。
 * 版本:      1.0
 * 版权:      x.com/0EE4GA9d © 2024
 ******************************************************************************/
using System.Collections.Generic;
using System.Windows.Forms;

namespace EbbinghausMemoryApp
{
    public partial class FormBookInfo : Form
    {
        public FormBookInfo(List<string> listCatlog)
        {
            InitializeComponent();
            if (listCatlog != null)
                this.cmbCatlog.Items.AddRange(listCatlog.ToArray());
        }

        public string BookName
        {
            get
            {
                return txtLessonName.Text;
            }
        }

        public string CatlogName
        {
            get { return cmbCatlog.Text; }
        }
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(this.BookName))
            {
                MessageBox.Show("书本名称不能为空！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbCatlog.Text))
            {
                cmbCatlog.Text = "未命名";
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
