using MovieAdvisor;
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

        private string avOrderBy = "";
        private int typeSelector = 0; // 0 -> all 1 -> movies 2 -> series
        private string selectedGenreID = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            verifyDBConnection();
            loadAVContents(true);
            loadGenres();
            ClearFields();
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
                GenresChecked.Items.Add(g);
            }

            cn.Close();
        }

        private void loadAVContents(bool first = false)
        {
            if (!verifyDBConnection())
            {
                return;
            }

            string query = "SELECT * ";

            if (selectedGenreID == null)
            {
                if (typeSelector == 0) query += "FROM AudioVisualContent ";
                else if (typeSelector == 1) query += "FROM AllMovies ";
                else if (typeSelector == 2) query += "FROM AllSeries ";
                else throw new Exception("Unreachable");
            }
            else
            {
                if (typeSelector == 0) query += "FROM filterAVByGenre(" + selectedGenreID + ")";
                else if (typeSelector == 1) query += "FROM filterMoviesByGenre(" + selectedGenreID + ")";
                else if (typeSelector == 2) query += "FROM filterSeriesByGenre(" + selectedGenreID + ")";
                else throw new Exception("Unreachable");
            }

            SqlCommand cmd = new SqlCommand(query + avOrderBy, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            avList.Items.Clear();

            if (first)
                avList2.Items.Clear();

            while (reader.Read())
            {
                AudiovisualContent m = AudiovisualContent.FromReader(reader);
                avList.Items.Add(m);

                if (first) avList2.Items.Add(m);
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
            // TODO: Limpar filtragens / sort ( ou nao )

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
                selectedGenreID = null;
                loadAVContents();
                return;
            }

            Genre selectedGenre = (Genre)genreComboBox.SelectedItem;
            selectedGenreID = selectedGenre.ID;
            loadAVContents();
        }

        private void movieOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (movieOrderBy.SelectedIndex == 0)
            {
                avOrderBy = "ORDER BY Title";
                loadAVContents();
            }
            else if (movieOrderBy.SelectedIndex == 1)
            {
                avOrderBy = "ORDER BY Title DESC";
                loadAVContents();
            }
            else if (movieOrderBy.SelectedIndex == 2)
            {
                avOrderBy = "ORDER BY ReleaseDate";
                loadAVContents();
            }
            else if (movieOrderBy.SelectedIndex == 3)
            {
                avOrderBy = "ORDER BY ReleaseDate DESC";
                loadAVContents();
            }
        }

        private void movieRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (movieRadio.Checked)
            {
                typeSelector = 1;
                loadAVContents();
            }
        }

        private void seriesRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (seriesRadio.Checked)
            {
                typeSelector = 2;
                loadAVContents();
            }
        }

        private void allRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (allRadio.Checked)
            {
                typeSelector = 0;
                loadAVContents();
            }
        }

        public void ShowButtons()
        {
            AddButton.Visible = true;
            EditButton.Visible = true;
            DeleteButton.Visible = true;
            cancelButton.Visible = false;
            confirmButton.Visible = false;
        }

        public void HideButtons()
        {
            AddButton.Visible = false;
            EditButton.Visible = false;
            DeleteButton.Visible = false;
            cancelButton.Visible = true;
            confirmButton.Visible = true;

        }

        public void ClearFields()
        {
            NameBox.Text = "";
            SynopsisBox.Text = "";
            TrailerBox.Text = "";
            PhotoBox.Text = "";
            BudgetBox.Text = "";
            RevenueBox.Text = "";
            ReleaseDatePicker.Text = "";

            ageRate.Checked = true;
            movieRadioDetails.Checked = true;
            StateLabel.Visible = false;
            StateComboBox.Visible = false;
            StateComboBox.SelectedIndex = 0;
            FinishDateLabel.Visible = false;
            FinishDatePicker.Visible = false;
            RuntimeBox.Visible = true;

            RuntimeBox.Text = "";
            GenresChecked.ClearSelected();

            SeasonBox.Items.Clear();
            SeasonBox.Text = "Seasons";
            ReleaseDateSeasonLabel.Text = "";
            TrailerSeason.Text = "";
            PhotoSeason.Text = "";

            EpisodeBox.Items.Clear();
            EpisodeBox.Text = "Episodes";
            SynopsisEpisode.Text = "";
            RuntimeEpisode.Text = "";

            foreach (int idx in GenresChecked.CheckedIndices)
            {
                GenresChecked.SetItemChecked(idx, false);
            }


        }

        private void addButton_Click(object sender, EventArgs e)
        {
            avList.SelectedIndex = -1;
            adding = true;
            ClearFields();
            HideButtons();
            avList.Enabled = false;
            avadd.Enabled = true;
            groupBox1.Enabled = true;
            SeasonGroup.Enabled = true;
            EpisodeGroup.Enabled = true;
            AddEpisode.Visible = false;
            DeleteEpisode.Visible = false;
            AddSeason.Visible = false;
            DeleteSeason.Visible = false;
            SeasonBox.SelectedIndex = -1;
            EpisodeBox.SelectedIndex = -1;
            SeasonBox.Items.Clear();
            EpisodeBox.Items.Clear();

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
            avadd.Enabled = false;
            panel1.Enabled = true;
            groupBox1.Enabled = true;
            SeasonGroup.Enabled = true;
            EpisodeGroup.Enabled = true;
            AddEpisode.Visible = true;
            DeleteEpisode.Visible = true;
            AddSeason.Visible = true;
            DeleteSeason.Visible = true;

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            currentAVContent = avList.SelectedIndex;
            if (currentAVContent <= 0)
            {
                MessageBox.Show("Please select a movie or serie to delete!");
                return;
            }
            if (avList.SelectedIndex > -1)
            {
                try
                {
                    AudiovisualContent item = (AudiovisualContent)avList.SelectedItem;
                    avList.Items.Remove(item);
                    avList2.Items.Remove(item);
                    avList.SelectedIndex = -1;
                    DELETEAVContent(item.ID);
                    ClearFields();
                    MessageBox.Show("Item apagado com sucesso!");
                    groupBox1.Enabled = false;
                    SeasonGroup.Enabled = false;
                    EpisodeGroup.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
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
            if (adding == true)
            {
                ClearFields();
            }
            ShowButtons();
            avList.Enabled = true;
            groupBox1.Enabled = false;
            ageRate.Checked = true;
            adding = false;
            SeasonGroup.Enabled = false;
            EpisodeGroup.Enabled = false;
            AddEpisode.Visible = false;
            DeleteEpisode.Visible = false;
            AddSeason.Visible = false;
            DeleteSeason.Visible = false;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (SaveAVContent())
            {
                avList.Enabled = true;
                int idx = avList.FindString(NameBox.Text);
                avList.SelectedIndex = idx;
                ShowButtons();
                groupBox1.Enabled = false;
                SeasonGroup.Enabled = false;
                EpisodeGroup.Enabled = false;
            }
        }


        private void avList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (avList.SelectedIndex >= 0)
            {
                SeasonBox.Items.Clear();
                EpisodeBox.Items.Clear();
                currentAVContent = avList.SelectedIndex;
                foreach (int idx in GenresChecked.CheckedIndices)
                {
                    GenresChecked.SetItemChecked(idx, false);
                }
                ShowAVContent();
            }
        }

        private void CreateMovie(Movie m, Genre[] genres)
        {
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DECLARE @Genres GenreList;";

            if (genres.Length > 0)
            {
                cmd.CommandText += "INSERT INTO @Genres VALUES ";

                foreach (Genre g in genres)
                {
                    cmd.CommandText += "(" + g.ID + "),";
                }

                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);

                cmd.CommandText += ";";
            }

            cmd.CommandText += "EXEC CreateMovie @Title, @Synopsis, @TrailerURL, @Budget, @Revenue, @Photo, @AgeRate, @ReleaseDate, @Runtime, @Genres";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Title", m.Title);
            cmd.Parameters.AddWithValue("@Synopsis", m.Synopsis);
            cmd.Parameters.AddWithValue("@TrailerURL", m.TrailerURL);
            cmd.Parameters.AddWithValue("@Budget", m.Budget);
            cmd.Parameters.AddWithValue("@Revenue", m.Revenue);
            cmd.Parameters.AddWithValue("@Photo", m.Photo);
            cmd.Parameters.AddWithValue("@AgeRate", m.AgeRate);
            cmd.Parameters.AddWithValue("@ReleaseDate", m.ReleaseDate);
            cmd.Parameters.AddWithValue("@Runtime", m.Runtime);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to insert Movie in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void UpdateMovie(Movie m, Genre[] genres)
        {
            int rows = 0;

            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DECLARE @Genres GenreList;";

            if (genres.Length > 0)
            {
                cmd.CommandText += "INSERT INTO @Genres VALUES ";

                foreach (Genre g in genres)
                {
                    cmd.CommandText += "(" + g.ID + "),";
                }

                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);

                cmd.CommandText += ";";
            }

            cmd.CommandText += "EXEC UpdateMovie @ID, @Title, @Synopsis, @TrailerURL, @Budget, @Revenue, @Photo, @AgeRate, @ReleaseDate, @Runtime, @Genres";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", m.ID);
            cmd.Parameters.AddWithValue("@Title", m.Title);
            cmd.Parameters.AddWithValue("@Synopsis", m.Synopsis);
            cmd.Parameters.AddWithValue("@TrailerURL", m.TrailerURL);
            cmd.Parameters.AddWithValue("@Budget", m.Budget);
            cmd.Parameters.AddWithValue("@Revenue", m.Revenue);
            cmd.Parameters.AddWithValue("@Photo", m.Photo);
            cmd.Parameters.AddWithValue("@AgeRate", m.AgeRate);
            cmd.Parameters.AddWithValue("@ReleaseDate", m.ReleaseDate);
            cmd.Parameters.AddWithValue("@Runtime", m.Runtime);
            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
                MessageBox.Show("Update OK");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update Movie in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void CreateSerie(TVSeries m, Genre[] genres, Season s, Episode e)
        {
            if (!verifyDBConnection())
                return;

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DECLARE @Genres GenreList;";

            if (genres.Length > 0)
            {
                cmd.CommandText += "INSERT INTO @Genres VALUES ";

                foreach (Genre g in genres)
                {
                    cmd.CommandText += "(" + g.ID + "),";
                }

                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);

                cmd.CommandText += ";";
            }

            cmd.CommandText += "EXEC CreateSerie @Title, @Synopsis, @TrailerURL, @Budget, @Revenue, @Photo, @AgeRate, @ReleaseDate, @State, @FinishDate,@Genres, @SeasonNumber, @SeasonPhoto, @SeasonTrailerURL, @SeasonReleaseDate, @EpisodeNumber, @EpisodeRuntime, @EpisodeSynopsis";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Title", m.Title);
            cmd.Parameters.AddWithValue("@Synopsis", m.Synopsis);
            cmd.Parameters.AddWithValue("@TrailerURL", m.TrailerURL);
            cmd.Parameters.AddWithValue("@Budget", m.Budget);
            cmd.Parameters.AddWithValue("@Revenue", m.Revenue);
            cmd.Parameters.AddWithValue("@Photo", m.Photo);
            cmd.Parameters.AddWithValue("@AgeRate", m.AgeRate);
            cmd.Parameters.AddWithValue("@ReleaseDate", m.ReleaseDate);
            cmd.Parameters.AddWithValue("@State", m.State);
            if (m.State == "Active")
            {
                cmd.Parameters.AddWithValue("@FinishDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FinishDate", m.FinishDate);
            }
            cmd.Parameters.AddWithValue("@SeasonNumber", "1");
            cmd.Parameters.AddWithValue("@SeasonPhoto", s.Photo);
            cmd.Parameters.AddWithValue("@SeasonTrailerURL", s.TrailerURL);
            cmd.Parameters.AddWithValue("@SeasonReleaseDate", s.ReleaseDate);
            cmd.Parameters.AddWithValue("@EpisodeNumber", "1");
            cmd.Parameters.AddWithValue("@EpisodeRuntime", e.Runtime);
            cmd.Parameters.AddWithValue("@EpisodeSynopsis", e.Synopsis);

            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create TVSerie in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void UpdateSerie(TVSeries m, Genre[] genres)
        {
            int rows = 0;

            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DECLARE @Genres GenreList;";

            if (genres.Length > 0)
            {
                cmd.CommandText += "INSERT INTO @Genres VALUES ";

                foreach (Genre g in genres)
                {
                    cmd.CommandText += "(" + g.ID + "),";
                }

                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);

                cmd.CommandText += ";";
            }

            cmd.CommandText += "EXEC UpdateSerie @ID, @Title, @Synopsis, @TrailerURL, @Budget, @Revenue, @Photo, @AgeRate, @ReleaseDate, @State, @FinishDate, @Genres ";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", m.ID);
            cmd.Parameters.AddWithValue("@Title", m.Title);
            cmd.Parameters.AddWithValue("@Synopsis", m.Synopsis);
            cmd.Parameters.AddWithValue("@TrailerURL", m.TrailerURL);
            cmd.Parameters.AddWithValue("@Budget", m.Budget);
            cmd.Parameters.AddWithValue("@Revenue", m.Revenue);
            cmd.Parameters.AddWithValue("@Photo", m.Photo);
            cmd.Parameters.AddWithValue("@AgeRate", m.AgeRate);
            cmd.Parameters.AddWithValue("@ReleaseDate", m.ReleaseDate);
            cmd.Parameters.AddWithValue("@State", m.State);
            if (m.State == "Active")
            {
                cmd.Parameters.AddWithValue("@FinishDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FinishDate", m.FinishDate);
            }

            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
                MessageBox.Show("Update OK");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update TVSeries in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        private void CreateSeason(TVSeries m, Season s, Episode e)
        {
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC CreateSeason @SerieId, @SeasonNumber, @SeasonPhoto, @SeasonTrailerURL, @SeasonReleaseDate, @EpisodeNumber, @EpisodeRuntime, @EpisodeSynopsis";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@SerieId", m.ID);
            cmd.Parameters.AddWithValue("@SeasonNumber", s.Number);
            cmd.Parameters.AddWithValue("@SeasonPhoto", s.Photo);
            cmd.Parameters.AddWithValue("@SeasonTrailerURL", s.TrailerURL);
            cmd.Parameters.AddWithValue("@SeasonReleaseDate", s.ReleaseDate);
            cmd.Parameters.AddWithValue("@EpisodeNumber", e.Number);
            cmd.Parameters.AddWithValue("@EpisodeRuntime", e.Runtime);
            cmd.Parameters.AddWithValue("@EpisodeSynopsis", e.Synopsis);

            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create Season in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void UpdateSeason(TVSeries m, Season s, Episode e)
        {
            int rows = 0;
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC UpdateSeason @SerieId, @SeasonNumber, @SeasonPhoto, @SeasonTrailerURL, @SeasonReleaseDate";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@SerieId", m.ID);
            cmd.Parameters.AddWithValue("@SeasonNumber", s.Number);
            cmd.Parameters.AddWithValue("@SeasonPhoto", s.Photo);
            cmd.Parameters.AddWithValue("@SeasonTrailerURL", s.TrailerURL);
            cmd.Parameters.AddWithValue("@SeasonReleaseDate", s.ReleaseDate);
            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
                MessageBox.Show("Update OK");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update TVSeries in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void CreateEpisode(TVSeries m, Season s, Episode e)
        {
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC CreateEpisode @SerieId, @SeasonNumber, @EpisodeNumber, @EpisodeRuntime, @EpisodeSynopsis";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@SerieId", m.ID);
            cmd.Parameters.AddWithValue("@SeasonNumber", s.Number);
            cmd.Parameters.AddWithValue("@EpisodeNumber", e.Number);
            cmd.Parameters.AddWithValue("@EpisodeRuntime", e.Runtime);
            cmd.Parameters.AddWithValue("@EpisodeSynopsis", e.Synopsis);

            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create Season in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void UpdateEpisode(TVSeries m, Season s, Episode e)
        {
            int rows = 0;
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC UpdateEpisode @SerieId, @SeasonNumber, @EpisodeNumber, @EpisodeRuntime, @EpisodeSynopsis";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@SerieId", m.ID);
            cmd.Parameters.AddWithValue("@SeasonNumber", s.Number);
            cmd.Parameters.AddWithValue("@EpisodeNumber", e.Number);
            cmd.Parameters.AddWithValue("@EpisodeRuntime", e.Runtime);
            cmd.Parameters.AddWithValue("@EpisodeSynopsis", e.Synopsis);
            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
                MessageBox.Show("Update OK");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update TVSeries in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void ShowAVContent()
        {
            StateComboBox.SelectedIndex = -1;
            if (avList.Items.Count == 0 | currentAVContent < 0)
                return;

            AudiovisualContent av = (AudiovisualContent)avList.SelectedItem;

            NameBox.Text = av.Title;
            SynopsisBox.Text = av.Synopsis;
            TrailerBox.Text = av.TrailerURL;
            PhotoBox.Text = av.Photo;
            BudgetBox.Text = av.Budget;
            RevenueBox.Text = av.Revenue;
            ReleaseDatePicker.Text = av.ReleaseDate;
            if (av.AgeRate.Equals("0"))
            {
                ageRate.Checked = true;
            }
            else if (av.AgeRate.Equals("12"))
            {
                ageRate2.Checked = true;
            }
            else if (av.AgeRate.Equals("15"))
            {
                ageRate3.Checked = true;
            }
            else
            {
                ageRate4.Checked = true;
            }



            if (!verifyDBConnection()) return;

            SqlCommand cmd = new SqlCommand("SELECT ID FROM getAVContentGenres (" + av.ID + ")", cn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GenresChecked.SetItemChecked(int.Parse(reader["ID"].ToString()) - 1, true);
            }



            reader.Close();


            cmd = new SqlCommand("SELECT * FROM Movie WHERE ID = " + av.ID, cn);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Movie m = Movie.FromAV(av);
                movieRadioDetails.Checked = true;
                StateLabel.Visible = false;
                StateComboBox.Visible = false;
                FinishDateLabel.Visible = false;
                FinishDatePicker.Visible = false;
                RuntimeBox.Visible = true;

                m.Runtime = reader["Runtime"].ToString();
                RuntimeBox.Text = m.Runtime;


            }
            else
            {
                reader.Close();
                cmd = new SqlCommand("SELECT * FROM TVSeries WHERE ID = " + av.ID, cn);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    TVSeries m = TVSeries.FromAV(av);
                    seriesRadioDetails.Checked = true;
                    StateLabel.Visible = true;
                    StateComboBox.Visible = true;
                    FinishDateLabel.Visible = true;
                    FinishDatePicker.Visible = true;
                    RuntimeBox.Visible = false;
                    m.State = reader["State"].ToString();
                    m.FinishDate = reader["FinishDate"].ToString();
                    if (m.State.Equals("Active"))
                    {
                        StateComboBox.SelectedIndex = 0;
                    }
                    else if (m.State.Equals("Finished"))
                    {
                        StateComboBox.SelectedIndex = 1;
                    }
                    else
                    {
                        StateComboBox.SelectedIndex = 2;
                    }

                    StateComboBox.SelectedItem = m.State;
                    FinishDatePicker.Text = m.FinishDate;

                }
                reader.Close();

                cmd = new SqlCommand("SELECT * FROM getAllSeasonsOfSerie(" + av.ID + ") ", cn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Season s = new Season();

                    s.Number = reader["Number"].ToString();
                    s.Photo = reader["Photo"].ToString();
                    s.TrailerURL = reader["TrailerURL"].ToString();
                    s.ReleaseDate = reader["ReleaseDate"].ToString();

                    SeasonBox.Items.Add(s);
                    PhotoSeason.Text = s.Photo;
                    TrailerSeason.Text = s.TrailerURL;
                    ReleaseDateSeasonPicker.Text = s.ReleaseDate;
                }
                SeasonBox.SelectedIndex = 0;
                reader.Close();
                cmd = new SqlCommand("SELECT * FROM getAllEpisodesOfSeason(" + av.ID + "," + ((SeasonBox.SelectedIndex) + 1) + ") ", cn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Episode s = new Episode();

                    s.Number = reader["Number"].ToString();
                    s.Runtime = reader["Runtime"].ToString();
                    s.Synopsis = reader["Synopsis"].ToString();

                    EpisodeBox.Items.Add(s);
                    SynopsisEpisode.Text = s.Synopsis;
                    RuntimeEpisode.Text = s.Runtime;
                }
                EpisodeBox.SelectedIndex = 0;
                reader.Close();
            }

            cn.Close();

        }

        private bool SaveAVContent()
        {
            AudiovisualContent av = new AudiovisualContent();
            av.Title = NameBox.Text;
            av.Synopsis = SynopsisBox.Text;
            av.TrailerURL = TrailerBox.Text;
            av.Photo = PhotoBox.Text;
            av.Budget = BudgetBox.Text;
            av.Revenue = RevenueBox.Text;
            string date = ReleaseDatePicker.Value.ToString("yyyy-MM-dd");
            av.ReleaseDate = date;
            if (ageRate.Checked)
            {
                av.AgeRate = "0";
            }
            else if (ageRate4.Checked)
            {
                av.AgeRate = "12";
            }
            else if (ageRate3.Checked)
            {
                av.AgeRate = "15";
            }
            else
            {
                av.AgeRate = "18";
            }

            if (movieRadioDetails.Checked)
            {
                Movie m = Movie.FromAV(av);
                m.Runtime = RuntimeBox.Text;
                if (av.Title == "")
                {
                    MessageBox.Show("Invalid Title!");
                    return false;
                }
                if (m.Runtime == "")
                {
                    MessageBox.Show("Invalid Runtime!");
                    return false;
                }
                Genre[] genres = GenresChecked.CheckedItems.Cast<Genre>().ToArray();
                if (adding)
                {
                    try
                    {

                        CreateMovie(m, genres);
                        loadAVContents();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                else
                {
                    m.ID = ((AudiovisualContent)avList.SelectedItem).ID;
                    UpdateMovie(m, genres);
                    loadAVContents();
                }

            }
            else
            {
                TVSeries m = TVSeries.FromAV(av);
                if (StateComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Invalid State!");
                    return false;
                }
                m.State = StateComboBox.SelectedItem.ToString();
                string finish = FinishDatePicker.Value.ToString("yyyy-MM-dd");
                m.FinishDate = finish;

                Genre[] genres = GenresChecked.CheckedItems.Cast<Genre>().ToArray();

                Season s = new Season();

                s.Number = ((SeasonBox.SelectedIndex) + 1).ToString();
                s.Photo = PhotoSeason.Text;
                s.TrailerURL = TrailerSeason.Text;
                string release = ReleaseDateSeasonPicker.Value.ToString("yyyy-MM-dd");
                s.ReleaseDate = release;

                Episode e = new Episode();
                e.Number = ((EpisodeBox.SelectedIndex) + 1).ToString();
                e.Synopsis = SynopsisEpisode.Text;
                e.Runtime = RuntimeEpisode.Text;


                if (adding)
                {
                    try
                    {
                        if (av.Title == "")
                        {
                            MessageBox.Show("Invalid Title!");
                            return false;
                        }
                        if (m.State == "")
                        {
                            MessageBox.Show("Invalid Title!");
                            return false;
                        }

                        if (e.Runtime == "")
                        {
                            MessageBox.Show("Invalid Runtime!");
                            return false;
                        }
                        CreateSerie(m, genres, s, e);
                        loadAVContents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                else
                {
                    m.ID = ((AudiovisualContent)avList.SelectedItem).ID;
                    UpdateSerie(m, genres);
                    loadAVContents();
                }
            }

            return true;
        }

        private void seriesRadioDetails_CheckedChanged(object sender, EventArgs e)
        {
            StateLabel.Visible = true;
            StateComboBox.Visible = true;
            StateComboBox.SelectedIndex = -1;
            FinishDateLabel.Visible = false;
            FinishDatePicker.Visible = false;
            RuntimeBox.Visible = false;
            SeriesGroup.Visible = true;
            SeasonBox.SelectedIndex = -1;
            EpisodeBox.SelectedIndex = -1;

        }

        private void movieRadioDetails_CheckedChanged(object sender, EventArgs e)
        {
            StateLabel.Visible = false;
            StateComboBox.Visible = false;
            StateComboBox.SelectedIndex = -1;
            FinishDateLabel.Visible = false;
            FinishDatePicker.Visible = false;
            RuntimeBox.Visible = true;
            SeriesGroup.Visible = false;
        }

        private void StateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StateComboBox.SelectedIndex == 0 | StateComboBox.SelectedIndex == -1)
            {
                FinishDateLabel.Visible = false;
                FinishDatePicker.Visible = false;
            }
            else
            {

                FinishDateLabel.Visible = true;
                FinishDatePicker.Visible = true;
            }
        }

        private void SeasonBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SeasonBox.SelectedIndex >= 0)
            {
                Season s = (Season)SeasonBox.SelectedItem;

                ReleaseDateSeasonPicker.Text = s.ReleaseDate;
                TrailerSeason.Text = s.TrailerURL;
                PhotoSeason.Text = s.Photo;
            }

        }

        private void AddSeason_Click(object sender, EventArgs e)
        {

        }

        private void DeleteSeason_Click(object sender, EventArgs e)
        {
            if (SeasonBox.Items.Count == 1)
            {
                MessageBox.Show("It's not possible to remove this season because its the only one of the serie.");
                return;
            }
            currentAVContent = avList.SelectedIndex;
            if (SeasonBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a season to delete!");
                return;
            }
            if (avList.SelectedIndex > -1)
            {
                try
                {
                    AudiovisualContent av = (AudiovisualContent)avList.SelectedItem;
                   
                    Season item = (Season)SeasonBox.SelectedItem;
                    SeasonBox.Items.Remove(item);
                    SeasonBox.SelectedIndex = -1;
                    DELETESeason(av.ID, item.Number);
                    TrailerSeason.Text = "";
                    PhotoSeason.Text = "";
                    EpisodeBox.Items.Clear();
                    EpisodeBox.SelectedIndex = -1;
                    SynopsisEpisode.Text = "";
                    RuntimeEpisode.Text = "";
                    MessageBox.Show("Item apagado com sucesso!");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void DELETESeason(string ID, string Number)
        {
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE SEASON WHERE ID=@ID AND Number = @Number";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Number", Number);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete season in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

    }
}