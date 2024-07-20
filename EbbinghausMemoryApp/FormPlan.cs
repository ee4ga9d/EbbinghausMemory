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
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
