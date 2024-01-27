using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            display();
            DisplayWritings();
            displayArts();
            displayNotebooks();
            subpanel.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subpanel.Hide();
            mainPanel.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            subpanel.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool sidebarExpand = true;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
           timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                sidePanel.Width += 10;
                top1Panel.Width += 10;
                top2Panel.Width += 10;
                top3Panel.Width += 10;  
                top4panel.Width += 10;  
                top5Panel.Width += 10;
                if (sidebar.Width <= 54)
                {
                    sidebarExpand = false;
                    timer1.Stop();
                }
            }
            else {
                sidebar.Width += 10;
                sidePanel.Width -= 10;
                top1Panel.Width -= 10;
                top2Panel.Width -= 10;
                top3Panel.Width -= 10;
                top4panel.Width -= 10;
                top5Panel.Width -= 10;
                if (sidebar.Width >= 251) { 
                    sidebarExpand= true;
                    timer1.Stop();
                
                }
            }
        }

        private void sidebarTransition_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }
        private void DisplayWritings()
        {
            string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Rendon;Integrated Security=True";
            string query = "select * from WritingInstruments";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                    for (int i = 0; i < dataGridView2.Columns.Count; i++)
                    {
                        dataGridView2.Columns[i].Width = 111;
                    }

                }
            }
        }

        private void displayNotebooks()
        {
            string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Rendon;Integrated Security=True";
            string query = "select * from NotebooksAndPaper";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView3.DataSource = dataTable;
                    for (int i = 0; i < dataGridView3.Columns.Count; i++)
                    {
                        dataGridView3.Columns[i].Width = 111;
                    }

                }
            }
        }
        private void displayArts()
        {
            string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Rendon;Integrated Security=True";
            string query = "select * from ArtsAndCraftsSupplies";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView4.DataSource = dataTable;
                    for (int i = 0; i < dataGridView4.Columns.Count; i++)
                    {
                        dataGridView4.Columns[i].Width = 80;
                    }

                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
        private void display()
        {
            string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Rendon;Integrated Security=True";
            string query = "SELECT \r\n    category_id,\r\n    category_name,\r\n    SUM(quantity) AS total_quantity,\r\n    SUM(quantity * price) AS total_price\r\nFROM (\r\n    SELECT \r\n        Category.category_id,\r\n        category_name,\r\n        quantity,\r\n        price\r\n    FROM WritingInstruments\r\n    INNER JOIN Category ON WritingInstruments.category_id = Category.category_id\r\n\r\n    UNION ALL\r\n\r\n    SELECT \r\n        Category.category_id,\r\n        category_name,\r\n        quantity,\r\n        price\r\n    FROM NotebooksAndPaper\r\n    INNER JOIN Category ON NotebooksAndPaper.category_id = Category.category_id\r\n\r\n    UNION ALL\r\n\r\n    SELECT \r\n        Category.category_id,\r\n        category_name,\r\n        quantity,\r\n        price\r\n    FROM ArtsAndCraftsSupplies\r\n    INNER JOIN Category ON ArtsAndCraftsSupplies.category_id = Category.category_id\r\n) AS combined_data\r\nGROUP BY category_id, category_name;\r\n";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].Width = 151;
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.ShowDialog();
        }
    }
}
