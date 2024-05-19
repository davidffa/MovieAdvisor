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
            verifyDBConnection();
            loadAVContents();
            loadGenres();
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

        private void loadGenres()
        {
            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM Genre ORDER BY Name", cn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Genre g = new Genre();

                g.ID = reader["ID"].ToString();
                g.Name = reader["Name"].ToString();

                genreComboBox.Items.Add(g);
            }

            cn.Close();
        }

        private void loadAVContents()
        {
            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM AudioVisualContent ORDER BY Title", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            avList.Items.Clear();
            avList2.Items.Clear();

            while (reader.Read())
            {
                AudiovisualContent m = AudiovisualContent.FromReader(reader);
                avList.Items.Add(m);
                avList2.Items.Add(m);
            }

            cn.Close();
        }

        private void filterAVContentByGenre(Genre genre)
        {
            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM filterAVByGenre(" + genre.ID + ")", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            avList.Items.Clear();

            while (reader.Read())
            {
                AudiovisualContent m = AudiovisualContent.FromReader(reader);
                avList.Items.Add(m);
            }

            cn.Close();
        }

        private void searchMoviesBtn_Click(object sender, EventArgs e)
        {
            if (!verifyDBConnection())
            {
                return;
            }

            string searchTerm = movieSearchBox.Text;

            SqlCommand cmd = new SqlCommand("SELECT * FROM AudioVisualContent WHERE Title LIKE '%" + searchTerm + "%'", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            avList.Items.Clear();

            while (reader.Read())
            {
                AudiovisualContent m = AudiovisualContent.FromReader(reader);

                avList.Items.Add(m);
            }

            cn.Close();
        }

        private void loadReviews(string avID)
        {
            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM Review WHERE AVIdentifier =" + avID, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reviewsList.Items.Clear();

            while (reader.Read())
            {
                Review r = new Review();
                r.Id = reader["ID"].ToString();
                r.AvIdentifier = avID;
                r.Title = reader["Title"].ToString();
                r.Description = reader["Description"].ToString();
                r.Classification = reader["Classification"].ToString();
                r.CreatedAt = reader["CreatedAt"].ToString();

                reviewsList.Items.Add(r);
            }

            cn.Close();
        }

        private void avList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (avList2.SelectedItem != null)
            {
                AudiovisualContent av = (AudiovisualContent)avList2.SelectedItem;
                loadReviews(av.ID);

                if (!verifyDBConnection())
                {
                    return;
                }

                SqlCommand cmd = new SqlCommand("SELECT dbo.overallScoreByID(" + av.ID + ")", cn);
                string overallScore = cmd.ExecuteScalar().ToString();

                if (overallScore.Equals("-1.00"))
                {
                    overallScoreLabel.Text = "NA/10";
                }
                else
                {
                    overallScoreLabel.Text = overallScore + "/10";
                }

                cn.Close();
            }
        }

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (genreComboBox.SelectedIndex == 0)
            {
                loadAVContents();
                return;
            }

            Genre selectedGenre = (Genre)genreComboBox.SelectedItem;
            filterAVContentByGenre(selectedGenre);
        }

        private void movieOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
