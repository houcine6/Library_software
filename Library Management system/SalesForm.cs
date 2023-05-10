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
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'salesDBv1DataSet.SalesV1' table. You can move, or remove it, as needed.
            this.salesV1TableAdapter.Fill(this.salesDBv1DataSet.SalesV1);
            // TODO: This line of code loads data into the 'booksDBv1DataSet.BooksV1' table. You can move, or remove it, as needed.
            this.booksV1TableAdapter.Fill(this.booksDBv1DataSet.BooksV1);

            timer1.Start();

            panel3.SendToBack();
            panel3.Hide();
            panel5.SendToBack();
            panel5.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("T");
        }

        Double TP = 0;
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            kryptonTextBox1.Text = "";
            booksV1BindingSource.Filter = string.Format("Name LIKE '%" + kryptonTextBox1.Text + "%'");

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
        }

        dynamic Q, p, n;
        int qq;

        private void kryptonTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel1.Hide();
            panel3.BringToFront();
            panel3.Show();
        }

        double pp;

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            label5.Text = "0";
            kryptonTextBox3.Text = "";
            TP = 0;
            TI = 0;
            kryptonDataGridView1.Rows.Clear();
            printList.Clear();
        }
        int TI = 0;
        dynamic q;
        int q2;

        private void kryptonButton9_Click_1(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text != "")
            {
                //quantity
                q = kryptonTextBox3.Text;
                q2 = Int32.Parse(q);

                if (q2 > qq)
                {
                    MessageBox.Show("There are not enough in stock", "Error");
                }
                else
                {
                    TP = TP + (pp * q2);

                    int rest;
                    rest = qq - q2;
                    itemsV1KryptonDataGridView.CurrentRow.Cells[2].Value = rest;

                    TI = TI + q2;

                    label5.Text = "" + TP;

                    kryptonDataGridView1.Rows.Add(n, q, pp);

                    this.salesV1BindingSource.AddNew();
                    book_NameTextBox.Text = n;
                    quantityTextBox.Text = q;
                    priceTextBox.Text = pp.ToString();

                    this.Validate();
                    this.salesV1BindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.salesDBv1DataSet);

                    this.Validate();
                    this.booksV1BindingSource.EndEdit();
                    this.tableAdapterManager1.UpdateAll(this.booksDBv1DataSet);

                    itemsV1KryptonDataGridView.CurrentRow.Selected = false;
                    kryptonTextBox3.Text = "";

                    quantity = Convert.ToString(q);
                    price = Convert.ToString(pp);

                    printList.Add(n);
                    printList.Add(quantity);
                    printList.Add(price);
                }
            }
            else
            {

            }
        }

        private void itemsV1KryptonDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (itemsV1KryptonDataGridView.CurrentRow.Cells[0].Value.ToString() != "" && itemsV1KryptonDataGridView.CurrentRow.Cells[3].Value.ToString() != "" && itemsV1KryptonDataGridView.CurrentRow.Cells[2].Value.ToString() != "")
            {
                itemsV1KryptonDataGridView.CurrentRow.Selected = true;

                n = itemsV1KryptonDataGridView.CurrentRow.Cells[0].Value.ToString();

                p = itemsV1KryptonDataGridView.CurrentRow.Cells[3].Value.ToString();
                pp = Convert.ToDouble(String.Format("{0:0.00}", p));

                Q = itemsV1KryptonDataGridView.CurrentRow.Cells[2].Value.ToString();
                qq = Int32.Parse(Q);
            }
            else
            {

            }
        }
        String today = DateTime.Now.ToString("d");

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;

            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);

            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("===== Library =====", new Font("Abeezee", 15, FontStyle.Bold), Brushes.Black, new Point(30, 20));

            e.Graphics.DrawString("" + today, new Font("Abeezee", 13), Brushes.Black, new Point(2, 50));

            e.Graphics.DrawString("Item                 QTE             item Price", new Font("Abeezee", 12), Brushes.Black, new Point(2, 80));

            e.Graphics.DrawString("--------------------------------------------------", new Font("Abeezee", 12), Brushes.Black, new Point(2, 90));
            int H = 101;
            int W = 0;
            for (int i = 0; i < printList.Count; i++)
            {
                int j = i;
                e.Graphics.DrawString("" + printList[j], new Font("Abeezee", 12), Brushes.Black, new Point(W, H));
                j++;
                W = W + 120;
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
                    W = 10;
                    H = H + 17;
                    e.Graphics.DrawString("Total Price : " + TP, new Font("Abeezee", 12), Brushes.Black, new Point(W, H));
                }
                H = H + 17;
                W = 0;
            }
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            panel3.SendToBack();
            panel3.Hide();
            panel1.BringToFront();
            panel1.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            kryptonTextBox2.Text = "";
            salesV1BindingSource.Filter = string.Format("[Book Name] LIKE '%" + kryptonTextBox2.Text + "%'");

        }

        private void kryptonTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(kryptonTextBox2.Text))
                {
                    salesV1BindingSource.Filter = string.Format("[Book Name] LIKE '%" + kryptonTextBox2.Text + "%'");
                }
                else
                {
                    salesV1BindingSource.Filter = string.Empty;
                }
            }
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < kryptonDataGridView12.Rows.Count - 1; i++)
            {
                kryptonDataGridView12.Rows[i].Selected = true;
                foreach (DataGridViewRow row in kryptonDataGridView12.SelectedRows)
                {
                    kryptonDataGridView12.Rows.RemoveAt(row.Index);
                }
            }
            
            this.Validate();
            this.salesV1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.salesDBv1DataSet);
        }

        String quantity, price;
        List<string> printList = new List<string>();
    }
}
