using Microsoft.Data.SqlClient;
using System.Data;

namespace DBWinFormsApp
{

    public partial class Form1 : Form
    {
        SqlConnection sqlCon;
        SqlCommand sqlCommand;

        public Form1()
        {
            InitializeComponent();
            string connectionString = "Data Source=.;Database=AmiraCompany;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";
            sqlCon = new(connectionString);
         
            btnAdd.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (sqlCon.State != ConnectionState.Open)
            {
                sqlCon.Open();
            }
            MessageBox.Show("The Connection is Opened");
            btnOpen.Enabled = false;
            btnAdd.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = textId.Text;
            string name = textName.Text;
            string loc = textLoc.Text;
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Department WHERE deptNo = @id", sqlCon);
            checkCmd.Parameters.AddWithValue("@id", id);
            int count = (int)checkCmd.ExecuteScalar();
            SqlCommand cmd;

            if (count > 0)
            {

                cmd = new SqlCommand(
                    "UPDATE Department SET deptName = @name, Location = @loc WHERE deptNo = @id",
                    sqlCon);
                MessageBox.Show("The Id is Already Exists, now The system is updating the values....");
            }
            else
            {
                cmd = new SqlCommand(
                    "INSERT INTO Department (deptNo, deptName, Location) VALUES (@id, @name, @loc)",
                    sqlCon);
                MessageBox.Show("The Record is inserted Successfully");
            }

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@loc", loc);

            cmd.ExecuteNonQuery();

            //btnAdd.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlCommand = new SqlCommand($"SELECT DeptName FROM Department", sqlCon);
            List<string> res = new List<string>();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    res.Add(reader.GetString(0));
                }
            }
            ListBox1.DataSource = null;
            ListBox1.DataSource = res;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Department WHERE deptNo = @id",sqlCon);
            string id = textId.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("The Id Is Deleted Sucessfully");
            textId.Text = "";
            textName.Text = "";
            textLoc.Text = "";
        }
    }
}
