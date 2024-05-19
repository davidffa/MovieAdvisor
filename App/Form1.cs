using System.Data;
using System.Data.SqlClient;

namespace MovieAdvisor
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // verifyDBConnection();
        }

        private SqlConnection getDBConnection()
        {
            return new SqlConnection("data source= 192.168.64.1,1433; uid=sa; password=Password123;initial catalog=MovieAdvisor");
        }

        private bool verifyDBConnection()
        {
            if (cn == null)
                cn = getDBConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
    }
}
