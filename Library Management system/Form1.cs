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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void loadForm(object Form)
        {
            if (this.main_panel.Controls.Count > 0)
            {
                this.main_panel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.main_panel.Controls.Add(f);
            this.main_panel.Tag = f;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new HomeScreenForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            loadForm(new SalesForm());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadForm(new BorrowsForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadForm(new BooksForm());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadForm(new StudentsForm());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'booksDBv1DataSet.BooksV1' table. You can move, or remove it, as needed.
            this.booksV1TableAdapter.Fill(this.booksDBv1DataSet.BooksV1);
            
            // TODO: This line of code loads data into the 'studentsDBv1DataSet.StudentsV1' table. You can move, or remove it, as needed.
            this.studentsV1TableAdapter.Fill(this.studentsDBv1DataSet.StudentsV1);

            // TODO: This line of code loads data into the 'borrowsDBv2DataSet.BorrowsV2' table. You can move, or remove it, as needed.
            this.borrowsV2TableAdapter.Fill(this.borrowsDBv2DataSet.BorrowsV2);

            // TODO: This line of code loads data into the 'salesDBv1DataSet.SalesV1' table. You can move, or remove it, as needed.
            this.salesV1TableAdapter.Fill(this.salesDBv1DataSet.SalesV1);

            loadForm(new HomeScreenForm());

            timer1.Start();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // TODO: This line of code loads data into the 'booksDBv1DataSet.BooksV1' table. You can move, or remove it, as needed.
            this.booksV1TableAdapter.Fill(this.booksDBv1DataSet.BooksV1);

            // TODO: This line of code loads data into the 'studentsDBv1DataSet.StudentsV1' table. You can move, or remove it, as needed.
            this.studentsV1TableAdapter.Fill(this.studentsDBv1DataSet.StudentsV1);

            // TODO: This line of code loads data into the 'borrowsDBv2DataSet.BorrowsV2' table. You can move, or remove it, as needed.
            this.borrowsV2TableAdapter.Fill(this.borrowsDBv2DataSet.BorrowsV2);

            // TODO: This line of code loads data into the 'salesDBv1DataSet.SalesV1' table. You can move, or remove it, as needed.
            this.salesV1TableAdapter.Fill(this.salesDBv1DataSet.SalesV1);

        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            //Console.WriteLine("i= : " + i);
            if (i == 60)
            {
                // TODO: This line of code loads data into the 'booksDBv1DataSet.BooksV1' table. You can move, or remove it, as needed.
                this.booksV1TableAdapter.Fill(this.booksDBv1DataSet.BooksV1);

                // TODO: This line of code loads data into the 'studentsDBv1DataSet.StudentsV1' table. You can move, or remove it, as needed.
                this.studentsV1TableAdapter.Fill(this.studentsDBv1DataSet.StudentsV1);

                // TODO: This line of code loads data into the 'borrowsDBv2DataSet.BorrowsV2' table. You can move, or remove it, as needed.
                this.borrowsV2TableAdapter.Fill(this.borrowsDBv2DataSet.BorrowsV2);

                // TODO: This line of code loads data into the 'salesDBv1DataSet.SalesV1' table. You can move, or remove it, as needed.
                this.salesV1TableAdapter.Fill(this.salesDBv1DataSet.SalesV1);

                i = 0;
            }
        }
    }
}
