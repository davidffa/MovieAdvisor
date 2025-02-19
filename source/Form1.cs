using MovieAdvisor;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieAdvisor
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        private bool adding;
        private bool adding_season;
        private bool adding_episode;
        private int currentAVContent;
        private string LikeCount;
        private string utilizador;

        private string avOrderBy = "";
        private int typeSelector = 0; // 0 -> all 1 -> movies 2 -> series
        private string selectedGenreID = null;
        private string selectedAVID = null;
        private string OldTitle;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            verifyDBConnection();
            loadAVContents(true);
            loadGenres();
            loadWatchLists();
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

        //load
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

            reader.Close();
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

                if (first)
                {
                    avList2.Items.Add(m);
                }

            }
            reader.Close();
            cn.Close();
        }
        private void loadReviews(string avID)
        {
            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM getAVContentReviews( @av_id)", cn);
            cmd.Parameters.AddWithValue("@av_id", avID);
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
                r.CountLikes = reader["LikeCount"].ToString();

                reviewsList.Items.Add(r);
            }
            reader.Close();
            cn.Close();
        }
        private void loadUserWatchList()
        {
            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM getUserWatchlists(@utilizador )", cn);

            cmd.Parameters.AddWithValue("@utilizador", utilizador);
            SqlDataReader reader = cmd.ExecuteReader();
            PersonalsWatchLists.Items.Clear();

            while (reader.Read())
            {
                Watchlist w = new Watchlist();
                w.Title = reader["Title"].ToString();
                w.UserID = reader["UserID"].ToString();
                w.Visibility = reader["Visibility"].ToString();

                PersonalsWatchLists.Items.Add(w);
            }
            reader.Close();
            cn.Close();
        }
        private void loadWatchLists()
        {
            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM GetPublicWatchlists", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            watchList.Items.Clear();

            while (reader.Read())
            {
                Watchlist w = new Watchlist();
                w.Title = reader["Title"].ToString();
                w.UserID = reader["UserID"].ToString();
                w.Visibility = reader["Visibility"].ToString();

                watchList.Items.Add(w);
            }
            reader.Close();
            cn.Close();
        }
        private void loadAvCheckList()
        {
            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM AudioVisualContent", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            checkedListBox1.Items.Clear();

            while (reader.Read())
            {
                AudiovisualContent av = new AudiovisualContent();
                av.ID = reader["ID"].ToString();
                av.Title = reader["Title"].ToString();
                av.Synopsis = reader["Synopsis"].ToString();
                av.TrailerURL = reader["TrailerURL"].ToString();
                av.Budget = reader["Budget"].ToString();
                av.Revenue = reader["Revenue"].ToString();
                av.Photo = reader["Photo"].ToString();
                av.AgeRate = reader["AgeRate"].ToString();
                av.ReleaseDate = reader["ReleaseDate"].ToString();

                checkedListBox1.Items.Add(av);
            }
            reader.Close();
            cn.Close();
        }
        private void loadAVWatchLists()
        {
            Watchlist w = (Watchlist)watchList.SelectedItem;

            if (PersonalsWatchLists.SelectedIndex != -1)
            {
                w = (Watchlist)PersonalsWatchLists.SelectedItem;
            }

            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM getAVFromWatchlist( @w_Title , @w_UserID )", cn);
            cmd.Parameters.AddWithValue("@w_Title", w.Title);
            cmd.Parameters.AddWithValue("@w_UserID", w.UserID);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                AudiovisualContent av = new AudiovisualContent();
                av.Title = reader["Title"].ToString();
                av.Synopsis = reader["Synopsis"].ToString();
                av.TrailerURL = reader["TrailerURL"].ToString();
                av.Budget = reader["Budget"].ToString();
                av.Revenue = reader["Revenue"].ToString();
                av.Photo = reader["Photo"].ToString();
                av.AgeRate = reader["AgeRate"].ToString();
                av.ReleaseDate = reader["ReleaseDate"].ToString();

                listBox1.Items.Add(av);
            }
            reader.Close();
            cn.Close();
        }

        private void loadAVWatchListsBox()
        {
            Watchlist w = (Watchlist)watchList.SelectedItem;

            if (PersonalsWatchLists.SelectedIndex != -1)
            {
                w = (Watchlist)PersonalsWatchLists.SelectedItem;
            }

            if (!verifyDBConnection())
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM getAVFromWatchlist( @w_Title , @w_UserID )", cn);
            cmd.Parameters.AddWithValue("@w_Title", w.Title);
            cmd.Parameters.AddWithValue("@w_UserID", w.UserID);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                AudiovisualContent av = new AudiovisualContent();
                av.ID = reader["ID"].ToString();
                av.Title = reader["Title"].ToString();
                av.Synopsis = reader["Synopsis"].ToString();
                av.TrailerURL = reader["TrailerURL"].ToString();
                av.Budget = reader["Budget"].ToString();
                av.Revenue = reader["Revenue"].ToString();
                av.Photo = reader["Photo"].ToString();
                av.AgeRate = reader["AgeRate"].ToString();
                av.ReleaseDate = reader["ReleaseDate"].ToString();

                checkedListBox1.SetItemChecked(int.Parse(av.ID)-1, true);
            }
            reader.Close();
            cn.Close();
        }

        //save
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
            else if (ageRate2.Checked)
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
                        if (adding_episode)
                        {
                            m.ID = ((AudiovisualContent)avList.SelectedItem).ID;
                            s.ID = ((Season)SeasonBox.SelectedItem).ID;
                            CreateEpisode(m, s, e);
                        }
                        else if (adding_season)
                        {
                            m.ID = ((AudiovisualContent)avList.SelectedItem).ID;
                            CreateSeason(m, s, e);
                        }
                        else
                        {
                            CreateSerie(m, genres, s, e);
                        }

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
                    UpdateSeason(m, s, e);
                    UpdateEpisode(m, s, e);
                    loadAVContents();
                }
            }

            return true;
        }
        private bool SaveReview()
        {

            Review r = new Review();
            r.UserID = utilizador;
            r.Title = ReviewTitle.Text;
            r.Description = ReviewDescription.Text;
            r.Classification = ReviewClassification.Text;
            r.AvIdentifier = ((AudiovisualContent)avList2.SelectedItem).ID;

            if (r.Classification == "")
            {
                MessageBox.Show("Invalid Title!");
                return false;
            }
            if (r.Title == "")
            {
                MessageBox.Show("Invalid Runtime!");
                return false;
            }
            if (r.Description == "")
            {
                MessageBox.Show("Invalid Runtime!");
                return false;
            }
            if (adding)
            {
                try
                {

                    CreateReview(r);
                    loadReviews(r.AvIdentifier);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                UpdateReview(r);
                loadReviews(r.AvIdentifier);
            }

            return true;
        }
        private bool SaveWatchList()
        {

            Watchlist w = new Watchlist();
            w.Title = TitleWatchList.Text;
            w.UserID = utilizador;

            if (radioYes.Checked)
            {
                w.Visibility = "True";
            }
            else
            {
                w.Visibility = "False";
            }
            AudiovisualContent[] wlAV = checkedListBox1.CheckedItems.Cast<AudiovisualContent>().ToArray();
            if (adding)
            {
                try
                {

                    createWatchList(w, wlAV);
                    loadUserWatchList();
                    loadWatchLists();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                try
                {
                    updateWatchList(w,wlAV);
                    loadAVWatchLists();
                    loadUserWatchList();
                    loadWatchLists();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }


            return true;
        }


        //show + hide + clear
        public void ShowAVContent()
        {
            StateComboBox.SelectedIndex = -1;
            if (avList.Items.Count == 0 || currentAVContent < 0)
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


            cmd = new SqlCommand("SELECT * FROM Movie WHERE ID = @av_ID", cn);
            cmd.Parameters.AddWithValue("@av_id", av.ID);
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
                cmd = new SqlCommand("SELECT * FROM TVSeries WHERE ID = @av_ID", cn);
                cmd.Parameters.AddWithValue("@av_id", av.ID);
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

                cmd = new SqlCommand("SELECT * FROM getAllSeasonsOfSerie( @av_ID ) ", cn);
                cmd.Parameters.AddWithValue("@av_id", av.ID);
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
                reader.Close();
                cmd = new SqlCommand("SELECT * FROM getAllEpisodesOfSeason(@av_ID, @number) ", cn);
                cmd.Parameters.AddWithValue("@av_id", av.ID);
                cmd.Parameters.AddWithValue("@number", 1);
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
                reader.Close();
                SeasonBox.SelectedIndex = 0;
                EpisodeBox.SelectedIndex = 0;
            }
            cn.Close();

        }
        public void ShowReview()
        {
            if (avList2.Items.Count == 0 || avList2.SelectedIndex == -1)
                return;
            if (reviewsList.Items.Count == 0 || reviewsList.SelectedIndex == -1)
                return;

            Review r = (Review)reviewsList.SelectedItem;

            ReviewClassification.Text = r.Classification;
            ReviewTitle.Text = r.Title;
            ReviewDescription.Text = r.Description;
            ReviewCreatedAt.Text = r.CreatedAt;
            CountLikes.Text = r.CountLikes;

            ReviewClassification.Visible = true;
            ReviewCreatedAt.Visible = true;
            ReviewDescription.Visible = true;
            ReviewTitle.Visible = true;
            ReviewAdd.Visible = true;
            ReviewEdit.Visible = true;
            ReviewDelete.Visible = true;
            ReviewLike.Visible = true;

        }
        private void searchMoviesBtn_Click(object sender, EventArgs e)
        {
            if (!verifyDBConnection())
            {
                return;
            }

            string searchTerm = movieSearchBox.Text;

            SqlCommand cmd = new SqlCommand("SELECT * FROM AudioVisualContent WHERE Title LIKE @searchTerm", cn);
            cmd.Parameters.AddWithValue("@searchTerm", searchTerm + '%');
            SqlDataReader reader = cmd.ExecuteReader();
            avList.Items.Clear();
            // TODO: Limpar filtragens / sort ( ou nao )

            while (reader.Read())
            {
                AudiovisualContent m = AudiovisualContent.FromReader(reader);

                avList.Items.Add(m);
            }
            reader.Close();
            cn.Close();
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

        //SelectedIndexChanged
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
        private void avList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReviewLike.BackColor = Color.Transparent;
            if (avList2.SelectedItem != null)
            {
                AudiovisualContent av = (AudiovisualContent)avList2.SelectedItem;
                ReviewClassification.Text = "";
                ReviewDescription.Text = "";
                ReviewTitle.Text = "";
                CountLikes.Text = "0";
                loadReviews(av.ID);

                if (!verifyDBConnection())
                {
                    return;
                }

                SqlCommand cmd = new SqlCommand("SELECT dbo.overallScoreByID( @av.ID )", cn);
                cmd.Parameters.AddWithValue("@av_id", av.ID);
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
            if (SeasonBox.SelectedIndex < 0) return;

            Season s = (Season)SeasonBox.SelectedItem;

            ReleaseDateSeasonPicker.Text = s.ReleaseDate;
            TrailerSeason.Text = s.TrailerURL;
            PhotoSeason.Text = s.Photo;

            if (!verifyDBConnection()) return;

            string av_id = ((AudiovisualContent)avList.SelectedItem).ID;

            SqlCommand cmd = new SqlCommand("SELECT * FROM getAllEpisodesOfSeason( @av_id , @sNumber) ", cn);
            cmd.Parameters.AddWithValue("@av_id", av_id);
            cmd.Parameters.AddWithValue("@sNumber", s.Number);

            SqlDataReader reader = cmd.ExecuteReader();

            EpisodeBox.Items.Clear();
            while (reader.Read())
            {
                Episode ep = new Episode();

                ep.Number = reader["Number"].ToString();
                ep.Runtime = reader["Runtime"].ToString();
                ep.Synopsis = reader["Synopsis"].ToString();

                EpisodeBox.Items.Add(ep);
                SynopsisEpisode.Text = ep.Synopsis;
                RuntimeEpisode.Text = ep.Runtime;
            }
            cn.Close();
            //EpisodeBox.SelectedIndex = 0;
        }
        private void EpisodeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EpisodeBox.SelectedIndex < 0) return;

            Episode ep = (Episode)EpisodeBox.SelectedItem;

            RuntimeEpisode.Text = ep.Runtime;
            SynopsisEpisode.Text = ep.Synopsis;
        }
        private void reviewsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reviewsList.SelectedIndex >= 0)
            {
                Review r = ((Review)reviewsList.SelectedItem);
                if (utilizador != null)
                {
                    if (!verifyDBConnection())
                        return;
                    SqlCommand cmd = new SqlCommand("SELECT * FROM ReviewLikes WHERE UserID=@utilizador AND ReviewID = @r_Id", cn);
                    cmd.Parameters.AddWithValue("@utilizador", utilizador);
                    cmd.Parameters.AddWithValue("@r_Id", r.Id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ReviewLike.BackColor = Color.LightSteelBlue;

                    }
                    else
                    {
                        ReviewLike.BackColor = Color.Transparent;
                    }
                    cn.Close();
                }
                ReviewClassification.Text = "";
                ReviewDescription.Text = "";
                ReviewTitle.Text = "";
                CountLikes.Text = "0";

                ShowReview();

            }
        }
        private void watchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (watchList.SelectedItem != null)
            {
                PersonalsWatchLists.SelectedIndex = -1;
                TitleWatchList.Text = watchList.SelectedItem.ToString();
                radioYes.Checked = true;
                loadAVWatchLists();
            }

        }
        private void PersonalsWatchLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PersonalsWatchLists.SelectedItem != null)
            {
                watchList.SelectedIndex = -1;
                TitleWatchList.Text = PersonalsWatchLists.SelectedItem.ToString();
                Watchlist w = (Watchlist)PersonalsWatchLists.SelectedItem;
                if (w.Visibility.Equals("True"))
                {
                    radioYes.Checked = true;
                }
                else
                {
                    radioNo.Checked = true;
                }
                loadAVWatchLists();
            }
        }

        //CheckedChanged
        private void movieRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (movieRadio.Checked)
            {
                typeSelector = 1;
                loadAVContents();
            }
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
        private void seriesRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (seriesRadio.Checked)
            {
                typeSelector = 2;
                loadAVContents();
            }
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
        private void allRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (allRadio.Checked)
            {
                typeSelector = 0;
                loadAVContents();
            }
        }


        // CRUD + Confirm + Delete
        private void addButton_Click(object sender, EventArgs e)
        {
            avList.SelectedIndex = -1;
            adding = true;
            adding_season = false;
            adding_episode = false;
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
            if (currentAVContent < 0)
            {
                MessageBox.Show("Please select a movie or serie to edit");
                return;
            }
            adding = false;
            adding_season = false;
            adding_episode = false;
            HideButtons();
            avList.Enabled = false;
            avadd.Enabled = false;
            panel1.Enabled = true;
            groupBox1.Enabled = true;
            SeasonGroup.Enabled = true;
            EpisodeGroup.Enabled = true;
            AddEpisode.Visible = false;
            DeleteEpisode.Visible = false;
            AddSeason.Visible = false;
            DeleteSeason.Visible = false;
            /*ConfirmEpisode.Visible = false;
            ConfirmSeason.Visible = false;
            CancelSeason.Visible = false;
            CancelSeason.Visible = false;
            */
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            currentAVContent = avList.SelectedIndex;
            if (currentAVContent < 0)
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
            adding_episode = false;
            adding_season = false;
            SeasonGroup.Enabled = false;
            EpisodeGroup.Enabled = false;
            AddEpisode.Visible = true;
            DeleteEpisode.Visible = true;
            AddSeason.Visible = true;
            DeleteSeason.Visible = true;
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

                AddEpisode.Visible = true;
                DeleteEpisode.Visible = true;
                AddSeason.Visible = true;
                DeleteSeason.Visible = true;
            }
        }

        // Season 
        private void AddSeason_Click(object sender, EventArgs e)
        {
            Season season = new Season();
            season.Number = (SeasonBox.Items.Count + 1).ToString();
            SeasonBox.Items.Add(season);
            adding = true;
            adding_episode = false;
            adding_season = true;

            avList.Enabled = false;
            groupBox1.Enabled = false;
            SeasonBox.Enabled = true;
            EpisodeBox.Enabled = true;
            AddEpisode.Visible = false;
            DeleteEpisode.Visible = false;
            AddSeason.Visible = false;
            confirmButton.Visible = false;
            cancelButton.Visible = false;
            DeleteSeason.Visible = false;
            ConfirmSeason.Visible = true;
            CancelSeason.Visible = true;
            SeasonBox.SelectedIndex = SeasonBox.Items.Count - 1;
            EpisodeBox.Items.Clear();
            Episode episode = new Episode();
            episode.Number = "1";
            EpisodeBox.Items.Add(episode);
            EpisodeBox.SelectedIndex = 0;
            SynopsisEpisode.Text = "";
            RuntimeEpisode.Text = "";
            EpisodeGroup.Enabled = true;
            SeasonGroup.Enabled = true;

            AddButton.Visible = false;
            EditButton.Visible = false;
            DeleteButton.Visible = false;
            confirmButton.Visible = false;
            cancelButton.Visible = false;
        }
        private void DeleteSeason_Click(object sender, EventArgs e)
        {
            if (SeasonBox.Items.Count == 1)
            {
                MessageBox.Show("It's not possible to remove this season because its the only one of the serie.");
                return;
            }
            currentAVContent = avList.SelectedIndex;
            if (SeasonBox.SelectedIndex < 0)
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
                    DELETESeason(av.ID, item.Number);
                    SeasonBox.SelectedIndex = 0;
                    SeasonBox.Items.Remove(item);
                    TrailerSeason.Text = "";
                    PhotoSeason.Text = "";
                    EpisodeBox.Items.Clear();
                    EpisodeBox.SelectedIndex = -1;
                    SynopsisEpisode.Text = "";
                    RuntimeEpisode.Text = "";
                    MessageBox.Show("Item apagado com sucesso!");

                    if (!verifyDBConnection()) return;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM getAllEpisodesOfSeason(" + av.ID + "," + ((SeasonBox.SelectedIndex) + 1) + ") ", cn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Episode ep = new Episode();

                        ep.Number = reader["Number"].ToString();
                        ep.Runtime = reader["Runtime"].ToString();
                        ep.Synopsis = reader["Synopsis"].ToString();

                        EpisodeBox.Items.Add(ep);
                        SynopsisEpisode.Text = ep.Synopsis;
                        RuntimeEpisode.Text = ep.Runtime;
                    }
                    EpisodeBox.SelectedIndex = 0;
                    reader.Close();
                    cn.Close();

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
        private void ConfirmSeason_Click(object sender, EventArgs e)
        {
            adding = true;
            adding_season = true;
            adding_episode = false;
            if (SaveAVContent())
            {
                avList.Enabled = true;
                int idx = avList.FindString(NameBox.Text);
                avList.SelectedIndex = idx;

                AddButton.Visible = true;
                EditButton.Visible = true;
                DeleteButton.Visible = true;
                cancelButton.Visible = false;
                confirmButton.Visible = false;
                ConfirmSeason.Visible = false;
                CancelSeason.Visible = false;
                AddEpisode.Visible = true;
                AddSeason.Visible = true;
                DeleteEpisode.Visible = true;
                DeleteSeason.Visible = true;

                groupBox1.Enabled = false;
                SeasonGroup.Enabled = false;
                EpisodeGroup.Enabled = false;

                SeasonBox.Enabled = true;
                EpisodeBox.Enabled = true;

            }
        }
        private void CancelSeason_Click(object sender, EventArgs e)
        {
            EpisodeBox.SelectedIndex = 0;
            EpisodeBox.Items.RemoveAt(EpisodeBox.Items.Count - 1);
            SeasonBox.SelectedIndex = 0;
            SeasonBox.Items.RemoveAt(SeasonBox.Items.Count - 1);
            avList.Enabled = true;
            int idx = avList.FindString(NameBox.Text);
            avList.SelectedIndex = idx;

            groupBox1.Enabled = false;

            adding = false;
            adding_episode = false;
            adding_season = false;

            AddButton.Visible = true;
            EditButton.Visible = true;
            DeleteButton.Visible = true;
            cancelButton.Visible = false;
            confirmButton.Visible = false;

            ConfirmSeason.Visible = false;
            ConfirmEpisode.Visible = false;
            CancelEpisode.Visible = false;
            CancelSeason.Visible = false;

            AddEpisode.Visible = true;
            AddSeason.Visible = true;
            DeleteEpisode.Visible = true;
            DeleteSeason.Visible = true;

            SeasonBox.Enabled = true;
            EpisodeBox.Enabled = true;
            SeasonGroup.Enabled = false;
            EpisodeGroup.Enabled = false;
        }

        // Episode
        private void AddEpisode_Click(object sender, EventArgs e)
        {
            Episode episode = new Episode();

            episode.Number = (EpisodeBox.Items.Count + 1).ToString();
            EpisodeBox.Items.Add(episode);
            adding = true;
            adding_episode = true;
            adding_season = false;

            avList.Enabled = false;
            groupBox1.Enabled = false;
            SeasonBox.Enabled = false;
            EpisodeBox.Enabled = true;
            EpisodeGroup.Enabled = true;

            AddEpisode.Visible = false;
            DeleteEpisode.Visible = false;

            AddSeason.Visible = false;
            DeleteSeason.Visible = false;

            confirmButton.Visible = false;
            cancelButton.Visible = false;

            ConfirmEpisode.Visible = true;
            CancelEpisode.Visible = true;
            EpisodeBox.SelectedIndex = EpisodeBox.Items.Count - 1;
            SynopsisEpisode.Text = "";
            RuntimeEpisode.Text = "";
            SeasonGroup.Enabled = false;

            AddButton.Visible = false;
            EditButton.Visible = false;
            DeleteButton.Visible = false;
        }
        private void DeleteEpisode_Click(object sender, EventArgs e)
        {
            if (EpisodeBox.Items.Count == 1)
            {
                MessageBox.Show("It's not possible to remove this episode because its the only one of the season.");
                return;
            }
            currentAVContent = avList.SelectedIndex;
            if (EpisodeBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an episode to delete!");
                return;
            }
            if (SeasonBox.SelectedIndex < 0)
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
                    Episode episode = (Episode)EpisodeBox.SelectedItem;
                    EpisodeBox.Items.Remove(item);
                    EpisodeBox.SelectedIndex = -1;
                    DELETEEpisode(av.ID, item.Number, episode.Number);
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
        private void DELETEEpisode(string ID, string Number, string episodeNumber)
        {
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE Episode WHERE Series_ID=@ID AND Season_ID = @Number AND Number = @episodeNumber";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Series_ID", ID);
            cmd.Parameters.AddWithValue("@Season_ID", Number);
            cmd.Parameters.AddWithValue("@Number", episodeNumber);

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
        private void ConfirmEpisode_Click(object sender, EventArgs e)
        {
            int id_season = SeasonBox.SelectedIndex;
            int ep = EpisodeBox.SelectedIndex;
            adding = true;
            adding_season = false;
            adding_episode = true;
            if (SaveAVContent())
            {
                avList.Enabled = true;
                int idx = avList.FindString(NameBox.Text);
                avList.SelectedIndex = idx;

                AddButton.Visible = true;
                EditButton.Visible = true;
                DeleteButton.Visible = true;
                cancelButton.Visible = false;
                confirmButton.Visible = false;
                ConfirmEpisode.Visible = false;
                CancelEpisode.Visible = false;

                AddEpisode.Visible = true;
                AddSeason.Visible = true;
                DeleteEpisode.Visible = true;
                DeleteSeason.Visible = true;

                groupBox1.Enabled = false;
                SeasonGroup.Enabled = false;
                EpisodeGroup.Enabled = false;
                SeasonBox.Enabled = true;
                EpisodeBox.Enabled = true;
                SeasonBox.SelectedIndex = id_season;
                EpisodeBox.SelectedIndex = ep;

            }
        }
        private void CancelEpisode_Click(object sender, EventArgs e)
        {
            EpisodeBox.SelectedIndex = 0;
            EpisodeBox.Items.RemoveAt(EpisodeBox.Items.Count - 1);
            avList.Enabled = true;
            int idx = avList.FindString(NameBox.Text);
            avList.SelectedIndex = idx;

            groupBox1.Enabled = false;

            adding = false;
            adding_episode = false;
            adding_season = false;

            AddButton.Visible = true;
            EditButton.Visible = true;
            DeleteButton.Visible = true;
            cancelButton.Visible = false;
            confirmButton.Visible = false;
            ConfirmSeason.Visible = false;
            ConfirmEpisode.Visible = false;
            CancelEpisode.Visible = false;
            CancelSeason.Visible = false;
            AddEpisode.Visible = true;
            AddSeason.Visible = true;
            DeleteEpisode.Visible = true;
            DeleteSeason.Visible = true;

            SeasonBox.Enabled = true;
            SeasonGroup.Enabled = false;
            EpisodeGroup.Enabled = false;
        }

        //Review
        private void ReviewAdd_Click(object sender, EventArgs e)
        {
            adding = true;
            if (avList2.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie or serie!");
                return;
            }
            ReviewClassification.Text = "";
            ReviewDescription.Text = "";
            ReviewTitle.Text = "";
            CountLikes.Text = "0";
            avList2.Enabled = false;
            reviewsList.SelectedIndex = -1;
            reviewsList.Enabled = false;
            ReviewDelete.Visible = false;
            ReviewAdd.Visible = false;
            ReviewEdit.Visible = false;
            ReviewLike.Visible = false;

            ReviewTitle.Enabled = true;
            ReviewClassification.Enabled = true;
            ReviewDescription.Enabled = true;


            ReviewCancel.Visible = true;
            ReviewConfirm.Visible = true;

        }
        private void ReviewEdit_Click(object sender, EventArgs e)
        {
            adding = false;
            if (avList2.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie or serie!");
                return;
            }
            if (reviewsList.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a review to edit!");
                return;
            }
            avList2.Enabled = false;
            reviewsList.Enabled = false;
            ReviewDelete.Visible = false;
            ReviewAdd.Visible = false;
            ReviewEdit.Visible = false;
            ReviewLike.Visible = false;

            ReviewTitle.Enabled = true;
            ReviewClassification.Enabled = true;
            ReviewDescription.Enabled = true;


            ReviewCancel.Visible = true;
            ReviewConfirm.Visible = true;
        }
        private void ReviewDelete_Click(object sender, EventArgs e)
        {
            if (reviewsList.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a review to delete!");
                return;
            }
            if (utilizador.Equals(""))
            {
                MessageBox.Show("Utilizador vazio!");
                return;
            }

            try
            {
                Review item = (Review)reviewsList.SelectedItem;
                DELETEReview(item);
                reviewsList.Items.Remove(item);
                reviewsList.SelectedIndex = -1;



                MessageBox.Show("Item apagado com sucesso!");
                ReviewDelete.Visible = true;
                ReviewAdd.Visible = true;
                EditButton.Visible = true;
                ReviewLike.Visible = true;

                ReviewTitle.Enabled = false;
                ReviewClassification.Enabled = false;
                ReviewDescription.Enabled = false;

                ReviewCancel.Visible = false;
                ReviewConfirm.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void DELETEReview(Review r)
        {
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC DeleteReview @UserID, @ReviewID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserID", utilizador);
            cmd.Parameters.AddWithValue("@ReviewID", r.Id);

            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete review in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        private void ReviewConfirm_Click(object sender, EventArgs e)
        {
            if (SaveReview())
            {
                avList2.Enabled = true;
                reviewsList.Enabled = true;
                int idx = reviewsList.FindString(ReviewTitle.Text);
                reviewsList.SelectedIndex = idx;

                ReviewDelete.Visible = true;
                ReviewAdd.Visible = true;
                ReviewEdit.Visible = true;
                ReviewLike.Visible = true;
                ReviewCancel.Visible = false;
                ReviewConfirm.Visible = false;

                ReviewTitle.Enabled = false;
                ReviewClassification.Enabled = false;
                ReviewDescription.Enabled = false;

            }

        }
        private void ReviewCancel_Click(object sender, EventArgs e)
        {
            if (adding == true)
            {
                ReviewTitle.Text = "";
                ReviewClassification.Text = "";
                ReviewDescription.Text = "";

            }

            reviewsList.Enabled = true;
            avList2.Enabled = true;
            adding = false;
            ReviewDelete.Visible = true;
            ReviewAdd.Visible = true;
            ReviewEdit.Visible = true;
            ReviewLike.Visible = true;
            ReviewCancel.Visible = false;
            ReviewConfirm.Visible = false;

            ReviewTitle.Enabled = false;
            ReviewClassification.Enabled = false;
            ReviewDescription.Enabled = false;
        }

        //Review Like
        private void ReviewLike_Click(object sender, EventArgs e)
        {
            if (reviewsList.SelectedIndex >= 0)
            {
                Review r = ((Review)reviewsList.SelectedItem);
                if (!verifyDBConnection())
                    return;
                SqlCommand cmd = new SqlCommand("SELECT * FROM ReviewLikes WHERE UserID= @utilizador AND ReviewID= @r_Id", cn);
                cmd.Parameters.AddWithValue("@utilizador", utilizador);
                cmd.Parameters.AddWithValue("@r_Id", r.Id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ReviewLike.BackColor = Color.LightSteelBlue;

                }
                else
                {
                    ReviewLike.BackColor = Color.Transparent;
                }
                cn.Close();
                if (ReviewLike.BackColor == Color.Transparent)
                {
                    ReviewLike.BackColor = Color.LightSteelBlue;
                    CreateReviewLike(r);
                    ShowReview();

                }
                else
                {
                    ReviewLike.BackColor = Color.Transparent;
                    DeleteReviewLike(r);
                    ShowReview();
                }
            }
        }
        private void DeleteReviewLike(Review r)
        {
            int rows = 0;
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC DeleteReviewLike @UserID, @ReviewID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserID", utilizador);
            cmd.Parameters.AddWithValue("@ReviewID", r.Id);

            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete Like in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        private void CreateReviewLike(Review r)
        {
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC CreateReviewLike @UserID, @ReviewID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserID", utilizador);
            cmd.Parameters.AddWithValue("@ReviewID", r.Id);

            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to insert Like in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        //WatchList

        private void CreateWatchList_Click(object sender, EventArgs e)
        {
            adding = true;

            PersonalsWatchLists.SelectedIndex = -1;
            watchList.SelectedIndex = -1;

            TitleWatchList.Text = "";
            radioYes.Checked = true;

            CreateWatchList.Visible = false;
            EditWatchList.Visible = false;
            DeleteWatchList.Visible = false;
            ConfirmWatchList.Visible = true;
            CancelWatchList.Visible = true;

            TitleWatchList.Enabled = true;
            Visibilitygroup.Enabled = true;
            checkedListBox1.Visible = true;
            loadAvCheckList();

        }
        private void ConfirmWatchList_Click(object sender, EventArgs e)
        {
            if (SaveWatchList())
            {
                int idx = PersonalsWatchLists.FindString(TitleWatchList.Text);
                PersonalsWatchLists.SelectedIndex = idx;

                CreateWatchList.Visible = true;
                EditWatchList.Visible = true;
                DeleteWatchList.Visible = true;
                ConfirmWatchList.Visible = false;
                CancelWatchList.Visible = false;

                TitleWatchList.Enabled = false;
                Visibilitygroup.Enabled = false;
                checkedListBox1.Visible = false;


            }

        }
        private void DeleteWatchList_Click(object sender, EventArgs e)
        {
            if (PersonalsWatchLists.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a personal review to delete!");
                return;
            }
            if (utilizador.Equals(""))
            {
                MessageBox.Show("Utilizador vazio!");
                return;
            }

            try
            {
                Watchlist item = (Watchlist)PersonalsWatchLists.SelectedItem;
                if (!verifyDBConnection())
                    return;
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "DELETE Watchlist WHERE Title=@Title AND UserID=@UserID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Title", item.Title);
                cmd.Parameters.AddWithValue("@UserID", item.UserID);
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

                TitleWatchList.Text = "";
                radioYes.Checked = true;
                listBox1.Items.Clear();

                loadWatchLists();
                loadUserWatchList();

                MessageBox.Show("Item apagado com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void CancelWatchList_Click(object sender, EventArgs e)
        {
            if (adding == true)
            {
                TitleWatchList.Text = "";
                radioYes.Checked = true;
                checkedListBox1.Items.Clear();
            }
            else
            {
                TitleWatchList.Text = OldTitle;
            }
            CreateWatchList.Visible = true;
            EditWatchList.Visible = true;
            DeleteWatchList.Visible = true;
            ConfirmWatchList.Visible = false;
            CancelWatchList.Visible = false;

            TitleWatchList.Enabled = false;
            Visibilitygroup.Enabled = false;
            checkedListBox1.Visible = false;
            

        }
        private void EditWatchList_Click(object sender, EventArgs e)
        {
            adding = false;
            if (PersonalsWatchLists.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a personal watchlist to edit!");
                return;
            }
            OldTitle = PersonalsWatchLists.Text;
            CreateWatchList.Visible = false;
            EditWatchList.Visible = false;
            DeleteWatchList.Visible = false;
            ConfirmWatchList.Visible = true;
            CancelWatchList.Visible = true;

            TitleWatchList.Enabled = true;
            Visibilitygroup.Enabled = true;
            checkedListBox1.Visible = true;

            loadAvCheckList();
            loadAVWatchListsBox();


        }

        //Create + Update
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
                throw new Exception("Failed to create Episode in database. \n ERROR MESSAGE: \n" + ex.Message);
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

        private void CreateReview(Review r)
        {
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC CreateReview @UserID, @AVIdentifier, @Title, @Description, @Classification";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserID", utilizador);
            cmd.Parameters.AddWithValue("@AVIdentifier", r.AvIdentifier);
            cmd.Parameters.AddWithValue("@Title", r.Title);
            cmd.Parameters.AddWithValue("@Description", r.Description);
            cmd.Parameters.AddWithValue("@Classification", r.Classification);

            cmd.Connection = cn;

            try
            {
                if (r.Title == "")
                {
                    return;
                }
                if (r.Description == "")
                {
                    return;
                }
                if (r.Classification == "")
                {
                    return;
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create a Review in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        private void UpdateReview(Review r)
        {
            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC UpdateReview @UserID, @ReviewID, @Title, @Description, @Classification";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserID", utilizador);
            cmd.Parameters.AddWithValue("@ReviewID", ((Review)reviewsList.SelectedItem).Id);
            cmd.Parameters.AddWithValue("@Title", r.Title);
            cmd.Parameters.AddWithValue("@Description", r.Description);
            cmd.Parameters.AddWithValue("@Classification", r.Classification);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update a Review in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void createWatchList(Watchlist w, AudiovisualContent[] wlAV)
        {

            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "EXEC CreateWatchList @Title, @UserID, @Visibility";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Title", w.Title);
            cmd.Parameters.AddWithValue("@UserID", utilizador);
            cmd.Parameters.AddWithValue("@Visibility", w.Visibility);
            cmd.Connection = cn;

            try
            {
                if (w.Title == "")
                {
                    return;
                }
                if (w.Visibility == "")
                {
                    return;
                }
                cmd.ExecuteNonQuery();
                foreach (AudiovisualContent av in wlAV)
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = "EXEC AddAVContentToWatchlist @WLTitle, @UserID, @AVIdentifier";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@WLTitle", w.Title);
                    cmd.Parameters.AddWithValue("@UserID", utilizador);
                    cmd.Parameters.AddWithValue("@AVIdentifier", av.ID);
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create a Review in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        private void updateWatchList(Watchlist w, AudiovisualContent[] wlAV)
        {
            int rows = 0;

            if (!verifyDBConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DECLARE @AVList AVList;";

            if (wlAV.Length > 0)
            {
                cmd.CommandText += "INSERT INTO @AVList VALUES ";

                foreach (AudiovisualContent av in wlAV)
                {
                    cmd.CommandText += "(" + av.ID + "),";
                }

                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);

                cmd.CommandText += ";";
            }

            cmd.CommandText += "EXEC UpdateWatchlist @OldTitle, @Title, @UserID, @Visibility, @AVList";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OldTitle", OldTitle);

            cmd.Parameters.AddWithValue("@Title", w.Title);
            cmd.Parameters.AddWithValue("@UserID", utilizador);
            cmd.Parameters.AddWithValue("@Visibility", w.Visibility);

            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
                MessageBox.Show("Update OK");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update watchList in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        //Authentication
        private void ConfirmUserReviews_Click(object sender, EventArgs e)
        {
            groupBoxReview.Enabled = false;

            if (Authenticate())
            {
                groupBoxReview.Enabled = true;
                MessageBox.Show("Successfully authenticated!");
            }

        }
        private bool Authenticate()
        {
            if (!verifyDBConnection())
                return false;
            try
            {
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand("Authenticate", con);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Email", UserEmail.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordReview.Text);
                SqlParameter outputIdParam = new SqlParameter("@UserID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                utilizador = outputIdParam.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            cn.Close();
            return true;
        }
        private void ConfirmAuthentication2_Click(object sender, EventArgs e)
        {
            CreateWatchList.Enabled = false;
            EditWatchList.Enabled = false;
            DeleteWatchList.Enabled = false;

            if (Authenticate2())
            {
                CreateWatchList.Enabled = true;
                EditWatchList.Enabled = true;
                DeleteWatchList.Enabled = true;
                loadUserWatchList();
                MessageBox.Show("Successfully authenticated!");

            }

        }
        private bool Authenticate2()
        {
            if (!verifyDBConnection())
                return false;
            try
            {
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand("Authenticate", con);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Email", UserEmail2.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordWatchList.Text);
                SqlParameter outputIdParam = new SqlParameter("@UserID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                utilizador = outputIdParam.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            cn.Close();
            return true;
        }
    }
}