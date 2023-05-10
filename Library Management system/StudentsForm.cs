using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_system
{
    public partial class StudentsForm : Form
    {
        public StudentsForm()
        {
            InitializeComponent();
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentsDBv1DataSet.StudentsV1' table. You can move, or remove it, as needed.
            this.studentsV1TableAdapter.Fill(this.studentsDBv1DataSet.StudentsV1);

            timer1.Start();
        }

        private void productsV1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text != "" && (kryptonTextBox3.Text != "" || kryptonTextBox4.Text != ""))
            {
                this.Validate();
                this.studentsV1BindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.studentsDBv1DataSet);

                MessageBox.Show("Data saved successfully", "Saved");
            }
            else
            {
                MessageBox.Show("Important field is empty", "Error");
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            kryptonTextBox1.Enabled = true;
            kryptonTextBox2.Enabled = true;
            kryptonTextBox3.Enabled = true;
            kryptonTextBox4.Enabled = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in itemsV2KryptonDataGridView.SelectedRows)
            {
                itemsV2KryptonDataGridView.Rows.RemoveAt(row.Index);
            }

            this.Validate();
            this.studentsV1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.studentsDBv1DataSet);

            MessageBox.Show("Data saved successfully", "Saved");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            kryptonTextBox1.MaxLength = 49;
            kryptonTextBox2.MaxLength = 49;
            kryptonTextBox3.MaxLength = 49;

            int c = itemsV2KryptonDataGridView.Rows.Count;
            c = c - 1;
            label4.Text = "" + c + "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("T");
        }

        private void kryptonTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            search_KryptonTextBox.Text = "";
            studentsV1BindingSource.Filter = string.Format("Name LIKE '%" + search_KryptonTextBox.Text + "%'");

        }

        private void search_KryptonTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(search_KryptonTextBox.Text))
                {
                    studentsV1BindingSource.Filter = string.Format("Name LIKE '%" + search_KryptonTextBox.Text + "%'");
                }
                else
                {
                    studentsV1BindingSource.Filter = string.Empty;
                }
            }
        }

        private void itemsV2KryptonDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemsV2KryptonDataGridView.CurrentRow.Selected = true;
        }

        private void kryptonTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsLetter(ch) && ch != 8 && !char.IsWhiteSpace(ch))
            {
                e.Handled = true;
            }
        }
    }
}
