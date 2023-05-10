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
    public partial class BorrowsForm : Form
    {
        public BorrowsForm()
        {
            InitializeComponent();
        }

        private void BorrowsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'borrowsDBv2DataSet.BorrowsV2' table. You can move, or remove it, as needed.
            this.borrowsV2TableAdapter.Fill(this.borrowsDBv2DataSet.BorrowsV2);

            // TODO: This line of code loads data into the 'studentsDBv1DataSet.StudentsV1' table. You can move, or remove it, as needed.
            this.studentsV1TableAdapter.Fill(this.studentsDBv1DataSet.StudentsV1);
            
            // TODO: This line of code loads data into the 'booksDBv1DataSet.BooksV1' table. You can move, or remove it, as needed.
            this.booksV1TableAdapter.Fill(this.booksDBv1DataSet.BooksV1);

            timer1.Start();

            panel5.SendToBack();
            panel5.Hide();

            kryptonDataGridView3.Visible = false;
            kryptonButton6.Enabled = false;
            kryptonButton7.Enabled = false;

            return_DateDateTimePicker.Value = return_DateDateTimePicker.MinDate;
            return_DateDateTimePicker.Value = day;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        dynamic Q;
        private void itemsV2KryptonDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (itemsV2KryptonDataGridView.CurrentRow.Cells[0].Value.ToString() != "" && (itemsV2KryptonDataGridView.CurrentRow.Cells[2].Value.ToString() != "" || itemsV2KryptonDataGridView.CurrentRow.Cells[1].Value.ToString() != "") )
            {
                itemsV2KryptonDataGridView.CurrentRow.Selected = true;

                if (itemsV2KryptonDataGridView.CurrentRow.Cells[1].Value.ToString() != "" && itemsV2KryptonDataGridView.CurrentRow.Cells[2].Value.ToString() != "")
                {
                    studentname = itemsV2KryptonDataGridView.CurrentRow.Cells[0].Value.ToString();
                    phone = itemsV2KryptonDataGridView.CurrentRow.Cells[1].Value.ToString();
                    email = itemsV2KryptonDataGridView.CurrentRow.Cells[2].Value.ToString();
                }

                if(itemsV2KryptonDataGridView.CurrentRow.Cells[1].Value.ToString() == "")
                {
                    studentname = itemsV2KryptonDataGridView.CurrentRow.Cells[0].Value.ToString();
                    email = itemsV2KryptonDataGridView.CurrentRow.Cells[2].Value.ToString();
                }
                else if (itemsV2KryptonDataGridView.CurrentRow.Cells[2].Value.ToString() == "")
                {
                    studentname = itemsV2KryptonDataGridView.CurrentRow.Cells[0].Value.ToString();
                    phone = itemsV2KryptonDataGridView.CurrentRow.Cells[1].Value.ToString();
                }
            }
            else
            {

            }
        }

        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (kryptonDataGridView1.CurrentRow.Cells[0].Value.ToString() != "" && kryptonDataGridView1.CurrentRow.Cells[2].Value.ToString() != "")
            {
                kryptonDataGridView1.CurrentRow.Selected = true;

                bookname = kryptonDataGridView1.CurrentRow.Cells[0].Value.ToString();

                Q = kryptonDataGridView1.CurrentRow.Cells[2].Value.ToString();
                quantity = Int32.Parse(Q);
            }
            else
            {

            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            search_KryptonTextBox.Text = "";
            studentsV1BindingSource.Filter = string.Format("Name LIKE '%" + search_KryptonTextBox.Text + "%'");

            search_KryptonTextBox.Text = "";
            borrowsV2BindingSource.Filter = string.Format("[Student Name] LIKE '%" + search_KryptonTextBox.Text + "%'");

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
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(search_KryptonTextBox.Text))
                {
                    borrowsV2BindingSource.Filter = string.Format("[Student Name] LIKE '%" + search_KryptonTextBox.Text + "%'");
                }
                else
                {
                    borrowsV2BindingSource.Filter = string.Empty;
                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            kryptonTextBox1.Text = "";
            booksV1BindingSource.Filter = string.Format("Name LIKE '%" + kryptonTextBox1.Text + "%'");

            kryptonTextBox1.Text = "";
            borrowsV2BindingSource.Filter = string.Format("[Book Name] LIKE '%" + kryptonTextBox1.Text + "%'");

        }

        private void kryptonTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(kryptonTextBox1.Text))
                {
                    booksV1BindingSource.Filter = string.Format("Name LIKE '%" + kryptonTextBox1.Text + "%'");
                }
                else
                {
                    booksV1BindingSource.Filter = string.Empty;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(kryptonTextBox1.Text))
                {
                    borrowsV2BindingSource.Filter = string.Format("[Book Name] LIKE '%" + kryptonTextBox1.Text + "%'");
                }
                else
                {
                    borrowsV2BindingSource.Filter = string.Empty;
                }
            }
        }

        String studentname, phone, email, bookname;

        private void productsV1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.borrowsV2BindingSource.EndEdit();
            this.tableAdapterManager2.UpdateAll(this.borrowsDBv2DataSet);
        }

        dynamic d;
        int TI = 0;
        private void kryptonButton3_Click(object sender, EventArgs e)
        {

            TI = 0;
            printList.Clear();
            kryptonDataGridView2.Rows.Clear();
            studentname = "";
            phone = "";
            email = "";
            bookname = "";
            return_DateDateTimePicker.Value = return_DateDateTimePicker.MinDate;
            return_DateDateTimePicker.Value = day;
            kryptonDataGridView1.CurrentRow.Selected = false;
            itemsV2KryptonDataGridView.CurrentRow.Selected = false;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            itemsV2KryptonDataGridView.Visible = false;
            kryptonDataGridView1.Visible = false;
            kryptonDataGridView2.Visible = false;
            kryptonButton2.Visible = false;
            kryptonButton3.Visible = false;
            kryptonButton5.Visible = false;
            return_DateDateTimePicker.Visible = false;

            kryptonDataGridView3.Visible = true;
            kryptonButton6.Enabled = true;
            kryptonButton7.Enabled = true;
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            itemsV2KryptonDataGridView.Visible = true;
            kryptonDataGridView1.Visible = true;
            kryptonDataGridView2.Visible = true;
            kryptonButton2.Visible = true;
            kryptonButton3.Visible = true;
            kryptonButton5.Visible = true;
            return_DateDateTimePicker.Visible = true;

            kryptonDataGridView3.Visible = false;
            kryptonButton6.Enabled = false;
            kryptonButton7.Enabled = false;
        }

        private void kryptonButton5_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;

            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);

            printPreviewDialog1.ShowDialog();
        }

        String today = DateTime.Now.ToString("d");
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("===== Library =====", new Font("Abeezee", 15, FontStyle.Bold), Brushes.Black, new Point(30, 20));

            e.Graphics.DrawString("" + today, new Font("Abeezee", 13), Brushes.Black, new Point(2, 50));

            e.Graphics.DrawString("student name | book name | return date", new Font("Abeezee", 11), Brushes.Black, new Point(5, 80));

            e.Graphics.DrawString("--------------------------------------------------", new Font("Abeezee", 12), Brushes.Black, new Point(2, 90));
            int H = 101;
            int W = 0;
            for (int i = 0; i < printList.Count; i++)
            {
                int j = i;
                e.Graphics.DrawString("" + printList[j], new Font("Abeezee", 12), Brushes.Black, new Point(W, H));
                j++;
                W = W + 100;
                e.Graphics.DrawString("" + printList[j], new Font("Abeezee", 12), Brushes.Black, new Point(W, H));
                j++;
                W = W + 100;
                e.Graphics.DrawString("" + printList[j], new Font("Abeezee", 12), Brushes.Black, new Point(W, H));
                i = i + 2;
                if (i == printList.Count - 1)
                {
                    W = 0;
                    H = H + 17;
                    e.Graphics.DrawString("--------------------------------------------------", new Font("Abeezee", 12), Brushes.Black, new Point(W, H));
                    W = 10;
                    H = H + 17;
                    e.Graphics.DrawString("Total Books : " + TI, new Font("Abeezee", 12), Brushes.Black, new Point(W, H));
                    /*W = 10;
                    H = H + 17;
                    e.Graphics.DrawString("Total Price : " + TP, new Font("Abeezee", 12), Brushes.Black, new Point(W, H));*/
                }
                H = H + 17;
                W = 0;
            }
        }

        int quantity;

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in kryptonDataGridView3.SelectedRows)
            {
                kryptonDataGridView3.Rows.RemoveAt(row.Index);
            }

            this.Validate();
            this.borrowsV2BindingSource.EndEdit();
            this.tableAdapterManager2.UpdateAll(this.borrowsDBv2DataSet);

            MessageBox.Show("Data Deleted successfully", "Saved");
        }

        private void kryptonDataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            kryptonDataGridView3.CurrentRow.Selected = true;
        }

        DateTime day = DateTime.Today;
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if(studentname != "" && bookname != "")
            {
                quantity = quantity - 1;

                if (quantity < 0)
                {
                    MessageBox.Show("There is not enough in stock", "Error");
                }
                else
                {
                    int rest;
                    rest = quantity;
                    kryptonDataGridView1.CurrentRow.Cells[2].Value = rest;

                    TI = TI + 1;

                    this.borrowsV2BindingSource.AddNew();

                    d = return_DateDateTimePicker.Value.ToString();
                    d = Convert.ToDateTime(d).ToString("dd/MM/yyyy");

                    kryptonDataGridView2.Rows.Add(studentname, phone, email, bookname, d);

                    student_NameTextBox.Text = studentname;
                    if(phone != "" && email != "")
                    {
                        phoneTextBox.Text = phone;
                        e_mailTextBox.Text = email;
                    }
                    else if(phone == "")
                    {
                        e_mailTextBox.Text = email;
                    }
                    else if(email == "")
                    {
                        phoneTextBox.Text = phone;
                    }
                    book_NameTextBox.Text = bookname;
                    return_DateTextBox.Text = d;
                    /*d = Convert.ToDateTime(d);
                    return_DateDateTimePicker.Value = d;
                    Console.WriteLine("date is: " + d);

                    borrowsV1DataGridView.CurrentRow.Cells[5].Value = d;*/

                    this.Validate();
                    this.borrowsV2BindingSource.EndEdit();
                    this.tableAdapterManager2.UpdateAll(this.borrowsDBv2DataSet);

                    this.Validate();
                    this.booksV1BindingSource.EndEdit();
                    this.tableAdapterManager1.UpdateAll(this.booksDBv1DataSet);

                    kryptonDataGridView1.CurrentRow.Selected = false;
                    itemsV2KryptonDataGridView.CurrentRow.Selected = false;

                    printList.Add(studentname);
                    printList.Add(bookname);
                    printList.Add(d);

                    studentname = "";
                    phone = "";
                    email = "";
                    bookname = "";
                    return_DateDateTimePicker.Value = return_DateDateTimePicker.MinDate;
                    return_DateDateTimePicker.Value = day;
                }
            }
            else
            {

            }
        }
        List<string> printList = new List<string>();
    }
}
