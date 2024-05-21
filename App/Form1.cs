using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieAdvisor
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        private bool adding;
        private int currentAVContent;

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
            return new SqlConnection("data source= DESKTOP-DBAHH3N\\SQLEXPRESS; Integrated Security=SSPI;initial catalog=MovieAdvisor");
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

        private void filterAVContentByType(string type)
        {
            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd;

            if (type.Equals("all"))
            {
                cmd = new SqlCommand("SELECT * FROM AudioVisualContent ORDER BY Title", cn);
            }
            else if (type.Equals("movies"))
            {
                cmd = new SqlCommand("SELECT * FROM Movie JOIN AudioVisualContent ON Movie.ID = AudioVisualContent.ID ORDER BY Title", cn);
            }
            else if (type.Equals("series"))
            {
                cmd = new SqlCommand("SELECT * FROM TVSeries JOIN AudioVisualContent ON TVSeries.ID = AudioVisualContent.ID ORDER BY Title", cn);
            }
            else
            {
                throw new Exception("Unreachable");
            }

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

                if (overallScore.Equals("-1,00"))
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

        private void movieRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (movieRadio.Checked)
            {
                filterAVContentByType("movies");
            }
        }

        private void seriesRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (seriesRadio.Checked)
            {
                filterAVContentByType("series");
            }
        }

        private void allRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (allRadio.Checked)
            {
                filterAVContentByType("all");
            }
        }

        public void LockControls()
        {
            NameBox.ReadOnly = true;
            SynopsisBox.ReadOnly = true;

        }

        public void UnlockControls()
        {
            NameBox.ReadOnly = false;
            SynopsisBox.ReadOnly = false;

        }

        public void ShowButtons()
        {
            LockControls();
            AddButton.Visible = true;
            cancelButton.Visible = false;
            confirmButton.Visible = false;
        }

        public void HideButtons()
        {
            UnlockControls();
            AddButton.Visible = false;
            cancelButton.Visible = true;
            confirmButton.Visible = true;

        }

        public void ClearFields()
        {
            NameBox.Text = "";
            SynopsisBox.Text = "";

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            adding = true;
            ClearFields();
            HideButtons();
            avList.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            currentAVContent = avList.SelectedIndex;
            if (currentAVContent <= 0)
            {
                MessageBox.Show("Please select a movie or serie to edit");
                return;
            }
            adding = false;
            HideButtons();
            avList.Enabled = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (avList.SelectedIndex > -1)
            {
                try
                {
                    DELETEAVContent(((AudiovisualContent)avList.SelectedItem).ID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                avList.Items.RemoveAt(avList.SelectedIndex);
                if (currentAVContent == avList.Items.Count)
                    currentAVContent = avList.Items.Count - 1;
                if (currentAVContent == -1)
                {
                    ClearFields();
                    MessageBox.Show("There are no more");
                }
                else
                {
                    ShowAVContent();
                }
            }
        }

        private void DELETEAVContent(string ID)
        {
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE AudiovisualContent WHERE ID=@ID ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            adding = false;
            ClearFields();
            ShowButtons();
            avList.Enabled = true;
            groupBox1.Enabled = false;
            movieRadioDetails.Checked = true;
            ageRate.Checked = true;

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            adding = false;
            ClearFields();
            ShowButtons();
            avList.Enabled = true;
            groupBox1.Enabled = false;
        }

        private void SynopsisBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ageRate2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void avList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (avList.SelectedIndex > 0)
            {
                currentAVContent = avList.SelectedIndex;
                ShowAVContent();
            }
        }
        public void ShowAVContent()
        {
            if (avList.Items.Count == 0 | currentAVContent < 0)
                return;

            AudiovisualContent av = (AudiovisualContent)avList.SelectedItem;

            /*
        private String _popularity;
        private String _trailerURL;
        private String _budget;
        private String _revenue;
        private String _photo;
        private String _ageRate;
        private String _releaseDate;
             */
            NameBox.Text = av.Title;
            SynopsisBox.Text = av.Synopsis;


            if (!verifyDBConnection()) return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Movie WHERE ID = " + av.ID, cn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Movie m = Movie.FromReader(reader);
                movieRadioDetails.Checked = true;
                // runtime
            }
            else
            {
                reader.Close();
                cmd = new SqlCommand("SELECT * FROM TVSeries WHERE ID = " + av.ID, cn);
                reader = cmd.ExecuteReader();

                reader.Read();
                TVSeries m = TVSeries.FromReader(reader);
                seriesRadioDetails.Checked = true;

                // state & finish date
            }

            cn.Close();

        }


    }
}
