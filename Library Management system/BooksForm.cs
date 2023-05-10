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
    public partial class BooksForm : Form
    {
        public BooksForm()
        {
            InitializeComponent();
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'booksDBv1DataSet.BooksV1' table. You can move, or remove it, as needed.
            this.booksV1TableAdapter.Fill(this.booksDBv1DataSet.BooksV1);

            timer1.Start();
        }

        private void productsV1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text != "" && kryptonTextBox3.Text != "" && kryptonTextBox4.Text != "")
            {
                this.Validate();
                this.booksV1BindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.booksDBv1DataSet);

                MessageBox.Show("Data saved successfully", "Saved");
            }
            else
            {
                MessageBox.Show("Important field is empty", "Error");
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in itemsV2KryptonDataGridView.SelectedRows)
            {
                itemsV2KryptonDataGridView.Rows.RemoveAt(row.Index);
            }

            this.Validate();
            this.booksV1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.booksDBv1DataSet);

            MessageBox.Show("Data saved successfully", "Saved");
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            kryptonTextBox1.Enabled = true;
            kryptonTextBox2.Enabled = true;
            kryptonTextBox3.Enabled = true;
            kryptonTextBox4.Enabled = true;
        }

        private void itemsV2KryptonDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemsV2KryptonDataGridView.CurrentRow.Selected = true;
        }

        private void search_KryptonTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(search_KryptonTextBox.Text))
                {
                    booksV1BindingSource.Filter = string.Format("Name LIKE '%" + search_KryptonTextBox.Text + "%'");
                }
                else
                {
                    booksV1BindingSource.Filter = string.Empty;
                }
            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            search_KryptonTextBox.Text = "";
            booksV1BindingSource.Filter = string.Format("Name LIKE '%" + search_KryptonTextBox.Text + "%'");

        }

        private void kryptonTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && !char.IsPunctuation(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void kryptonTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("T");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            kryptonTextBox1.MaxLength = 49;
            kryptonTextBox2.MaxLength = 49;
            kryptonTextBox3.MaxLength = 49;
            kryptonTextBox4.MaxLength = 15;

            int c = itemsV2KryptonDataGridView.Rows.Count;
            c = c - 1;
            label4.Text = "" + c + "";
        }
    }
}
