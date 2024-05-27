namespace MovieAdvisor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            movies = new TabPage();
            SeriesGroup = new GroupBox();
            ConfirmEpisode = new Button();
            ConfirmSeason = new Button();
            CancelSeason = new Button();
            CancelEpisode = new Button();
            EpisodeBox = new ComboBox();
            SeasonBox = new ComboBox();
            AddEpisode = new Button();
            DeleteSeason = new Button();
            AddSeason = new Button();
            DeleteEpisode = new Button();
            EpisodeGroup = new GroupBox();
            SynopsisEpisode = new TextBox();
            RuntimeEpisode = new TextBox();
            SeasonGroup = new GroupBox();
            ReleaseDateSeasonLabel = new Label();
            ReleaseDateSeasonPicker = new DateTimePicker();
            PhotoSeason = new TextBox();
            TrailerSeason = new TextBox();
            confirmButton = new Button();
            cancelButton = new Button();
            DeleteButton = new Button();
            EditButton = new Button();
            groupBox1 = new GroupBox();
            avadd = new GroupBox();
            movieRadioDetails = new RadioButton();
            seriesRadioDetails = new RadioButton();
            panel1 = new Panel();
            GenresLabel = new Label();
            groupBox2 = new GroupBox();
            label8 = new Label();
            dateTimePicker2 = new DateTimePicker();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            domainUpDown1 = new DomainUpDown();
            domainUpDown2 = new DomainUpDown();
            GenresChecked = new CheckedListBox();
            RuntimeBox = new TextBox();
            StateLabel = new Label();
            StateComboBox = new ComboBox();
            FinishDateLabel = new Label();
            FinishDatePicker = new DateTimePicker();
            ReleaseLabel = new Label();
            ReleaseDatePicker = new DateTimePicker();
            PhotoBox = new TextBox();
            TrailerBox = new TextBox();
            RevenueBox = new TextBox();
            BudgetBox = new TextBox();
            AgeRateBox = new GroupBox();
            ageRate = new RadioButton();
            ageRate4 = new RadioButton();
            ageRate3 = new RadioButton();
            ageRate2 = new RadioButton();
            NameBox = new TextBox();
            SynopsisBox = new TextBox();
            typeBox = new GroupBox();
            allRadio = new RadioButton();
            movieRadio = new RadioButton();
            seriesRadio = new RadioButton();
            AddButton = new Button();
            genreComboBox = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            movieOrderBy = new ComboBox();
            searchMoviesBtn = new Button();
            movieSearchBox = new TextBox();
            avList = new ListBox();
            review = new TabPage();
            groupBoxReview = new GroupBox();
            ReviewCancel = new Button();
            ReviewConfirm = new Button();
            label7 = new Label();
            CountLikes = new TextBox();
            ReviewCreatedAtLabel = new Label();
            ReviewDelete = new Button();
            ReviewCreatedAt = new DateTimePicker();
            ReviewEdit = new Button();
            ReviewLike = new Button();
            ReviewClassification = new TextBox();
            ReviewDescription = new TextBox();
            ReviewTitle = new TextBox();
            ReviewAdd = new Button();
            UserPassLabel = new Label();
            UserEmailLabel = new Label();
            ConfirmUserReviews = new Button();
            PasswordReview = new TextBox();
            UserEmail = new TextBox();
            overallScoreLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            reviewsList = new ListBox();
            avList2 = new ListBox();
            watchlists = new TabPage();
            checkedListBox1 = new CheckedListBox();
            Password2Label = new Label();
            UserEmail2Label = new Label();
            ConfirmAuthetication2 = new Button();
            PasswordWatchList = new TextBox();
            UserEmail2 = new TextBox();
            listBox1 = new ListBox();
            CancelWatchList = new Button();
            ConfirmWatchList = new Button();
            Visibilitygroup = new GroupBox();
            label10 = new Label();
            radioNo = new RadioButton();
            radioYes = new RadioButton();
            DeleteWatchList = new Button();
            TitleWatchList = new TextBox();
            CreateWatchList = new Button();
            label9 = new Label();
            PersonalsWatchLists = new ListBox();
            WathListsLabel = new Label();
            watchList = new ListBox();
            people = new TabPage();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tabControl1.SuspendLayout();
            movies.SuspendLayout();
            SeriesGroup.SuspendLayout();
            EpisodeGroup.SuspendLayout();
            SeasonGroup.SuspendLayout();
            groupBox1.SuspendLayout();
            avadd.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            AgeRateBox.SuspendLayout();
            typeBox.SuspendLayout();
            review.SuspendLayout();
            groupBoxReview.SuspendLayout();
            watchlists.SuspendLayout();
            Visibilitygroup.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(movies);
            tabControl1.Controls.Add(review);
            tabControl1.Controls.Add(watchlists);
            tabControl1.Controls.Add(people);
            tabControl1.Location = new Point(1, 0);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1116, 739);
            tabControl1.TabIndex = 0;
            // 
            // movies
            // 
            movies.Controls.Add(SeriesGroup);
            movies.Controls.Add(confirmButton);
            movies.Controls.Add(cancelButton);
            movies.Controls.Add(DeleteButton);
            movies.Controls.Add(EditButton);
            movies.Controls.Add(groupBox1);
            movies.Controls.Add(typeBox);
            movies.Controls.Add(AddButton);
            movies.Controls.Add(genreComboBox);
            movies.Controls.Add(label6);
            movies.Controls.Add(label5);
            movies.Controls.Add(label4);
            movies.Controls.Add(movieOrderBy);
            movies.Controls.Add(searchMoviesBtn);
            movies.Controls.Add(movieSearchBox);
            movies.Controls.Add(avList);
            movies.Location = new Point(4, 29);
            movies.Margin = new Padding(2);
            movies.Name = "movies";
            movies.Padding = new Padding(2);
            movies.Size = new Size(1108, 706);
            movies.TabIndex = 0;
            movies.Text = "Movies/Series";
            movies.UseVisualStyleBackColor = true;
            // 
            // SeriesGroup
            // 
            SeriesGroup.Controls.Add(ConfirmEpisode);
            SeriesGroup.Controls.Add(ConfirmSeason);
            SeriesGroup.Controls.Add(CancelSeason);
            SeriesGroup.Controls.Add(CancelEpisode);
            SeriesGroup.Controls.Add(EpisodeBox);
            SeriesGroup.Controls.Add(SeasonBox);
            SeriesGroup.Controls.Add(AddEpisode);
            SeriesGroup.Controls.Add(DeleteSeason);
            SeriesGroup.Controls.Add(AddSeason);
            SeriesGroup.Controls.Add(DeleteEpisode);
            SeriesGroup.Controls.Add(EpisodeGroup);
            SeriesGroup.Controls.Add(SeasonGroup);
            SeriesGroup.Location = new Point(764, 18);
            SeriesGroup.Name = "SeriesGroup";
            SeriesGroup.Size = new Size(335, 601);
            SeriesGroup.TabIndex = 23;
            SeriesGroup.TabStop = false;
            SeriesGroup.Visible = false;
            // 
            // ConfirmEpisode
            // 
            ConfirmEpisode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ConfirmEpisode.Location = new Point(33, 549);
            ConfirmEpisode.Name = "ConfirmEpisode";
            ConfirmEpisode.Size = new Size(113, 29);
            ConfirmEpisode.TabIndex = 48;
            ConfirmEpisode.Text = "Confirm";
            ConfirmEpisode.UseVisualStyleBackColor = true;
            ConfirmEpisode.Visible = false;
            ConfirmEpisode.Click += ConfirmEpisode_Click;
            // 
            // ConfirmSeason
            // 
            ConfirmSeason.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ConfirmSeason.Location = new Point(33, 254);
            ConfirmSeason.Name = "ConfirmSeason";
            ConfirmSeason.Size = new Size(113, 29);
            ConfirmSeason.TabIndex = 46;
            ConfirmSeason.Text = "Confirm";
            ConfirmSeason.UseVisualStyleBackColor = true;
            ConfirmSeason.Visible = false;
            ConfirmSeason.Click += ConfirmSeason_Click;
            // 
            // CancelSeason
            // 
            CancelSeason.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelSeason.BackColor = Color.Transparent;
            CancelSeason.Location = new Point(176, 254);
            CancelSeason.Name = "CancelSeason";
            CancelSeason.Size = new Size(113, 29);
            CancelSeason.TabIndex = 47;
            CancelSeason.Text = "Cancel";
            CancelSeason.UseVisualStyleBackColor = false;
            CancelSeason.Visible = false;
            CancelSeason.Click += CancelSeason_Click;
            // 
            // CancelEpisode
            // 
            CancelEpisode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelEpisode.BackColor = Color.Transparent;
            CancelEpisode.Location = new Point(176, 549);
            CancelEpisode.Name = "CancelEpisode";
            CancelEpisode.Size = new Size(113, 29);
            CancelEpisode.TabIndex = 49;
            CancelEpisode.Text = "Cancel";
            CancelEpisode.UseVisualStyleBackColor = false;
            CancelEpisode.Visible = false;
            CancelEpisode.Click += CancelEpisode_Click;
            // 
            // EpisodeBox
            // 
            EpisodeBox.FormattingEnabled = true;
            EpisodeBox.Location = new Point(6, 312);
            EpisodeBox.Name = "EpisodeBox";
            EpisodeBox.Size = new Size(171, 28);
            EpisodeBox.TabIndex = 45;
            EpisodeBox.Text = "Episodes";
            EpisodeBox.SelectedIndexChanged += EpisodeBox_SelectedIndexChanged;
            // 
            // SeasonBox
            // 
            SeasonBox.FormattingEnabled = true;
            SeasonBox.Location = new Point(6, 20);
            SeasonBox.Name = "SeasonBox";
            SeasonBox.Size = new Size(171, 28);
            SeasonBox.TabIndex = 44;
            SeasonBox.Text = "Seasons";
            SeasonBox.SelectedIndexChanged += SeasonBox_SelectedIndexChanged;
            // 
            // AddEpisode
            // 
            AddEpisode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AddEpisode.Location = new Point(33, 549);
            AddEpisode.Name = "AddEpisode";
            AddEpisode.Size = new Size(113, 29);
            AddEpisode.TabIndex = 40;
            AddEpisode.Text = "Add";
            AddEpisode.UseVisualStyleBackColor = true;
            AddEpisode.Click += AddEpisode_Click;
            // 
            // DeleteSeason
            // 
            DeleteSeason.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteSeason.BackColor = Color.Transparent;
            DeleteSeason.Location = new Point(176, 253);
            DeleteSeason.Name = "DeleteSeason";
            DeleteSeason.Size = new Size(113, 29);
            DeleteSeason.TabIndex = 39;
            DeleteSeason.Text = "Delete";
            DeleteSeason.UseVisualStyleBackColor = false;
            DeleteSeason.Click += DeleteSeason_Click;
            // 
            // AddSeason
            // 
            AddSeason.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AddSeason.Location = new Point(33, 253);
            AddSeason.Name = "AddSeason";
            AddSeason.Size = new Size(113, 29);
            AddSeason.TabIndex = 38;
            AddSeason.Text = "Add";
            AddSeason.UseVisualStyleBackColor = true;
            AddSeason.Click += AddSeason_Click;
            // 
            // DeleteEpisode
            // 
            DeleteEpisode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteEpisode.BackColor = Color.Transparent;
            DeleteEpisode.Location = new Point(176, 549);
            DeleteEpisode.Name = "DeleteEpisode";
            DeleteEpisode.Size = new Size(113, 29);
            DeleteEpisode.TabIndex = 41;
            DeleteEpisode.Text = "Delete";
            DeleteEpisode.UseVisualStyleBackColor = false;
            DeleteEpisode.Click += DeleteEpisode_Click;
            // 
            // EpisodeGroup
            // 
            EpisodeGroup.Controls.Add(SynopsisEpisode);
            EpisodeGroup.Controls.Add(RuntimeEpisode);
            EpisodeGroup.Enabled = false;
            EpisodeGroup.Location = new Point(6, 347);
            EpisodeGroup.Name = "EpisodeGroup";
            EpisodeGroup.Size = new Size(329, 183);
            EpisodeGroup.TabIndex = 43;
            EpisodeGroup.TabStop = false;
            // 
            // SynopsisEpisode
            // 
            SynopsisEpisode.Location = new Point(0, 30);
            SynopsisEpisode.Multiline = true;
            SynopsisEpisode.Name = "SynopsisEpisode";
            SynopsisEpisode.PlaceholderText = "Add a synopsis";
            SynopsisEpisode.Size = new Size(323, 99);
            SynopsisEpisode.TabIndex = 35;
            // 
            // RuntimeEpisode
            // 
            RuntimeEpisode.Location = new Point(80, 138);
            RuntimeEpisode.Name = "RuntimeEpisode";
            RuntimeEpisode.PlaceholderText = "Runtime (em minutos)";
            RuntimeEpisode.Size = new Size(163, 27);
            RuntimeEpisode.TabIndex = 37;
            RuntimeEpisode.TextAlign = HorizontalAlignment.Center;
            // 
            // SeasonGroup
            // 
            SeasonGroup.Controls.Add(ReleaseDateSeasonLabel);
            SeasonGroup.Controls.Add(ReleaseDateSeasonPicker);
            SeasonGroup.Controls.Add(PhotoSeason);
            SeasonGroup.Controls.Add(TrailerSeason);
            SeasonGroup.Enabled = false;
            SeasonGroup.Location = new Point(6, 64);
            SeasonGroup.Name = "SeasonGroup";
            SeasonGroup.Size = new Size(329, 164);
            SeasonGroup.TabIndex = 42;
            SeasonGroup.TabStop = false;
            // 
            // ReleaseDateSeasonLabel
            // 
            ReleaseDateSeasonLabel.AutoSize = true;
            ReleaseDateSeasonLabel.Location = new Point(0, 19);
            ReleaseDateSeasonLabel.Name = "ReleaseDateSeasonLabel";
            ReleaseDateSeasonLabel.Size = new Size(107, 20);
            ReleaseDateSeasonLabel.TabIndex = 34;
            ReleaseDateSeasonLabel.Text = "Release Date : ";
            // 
            // ReleaseDateSeasonPicker
            // 
            ReleaseDateSeasonPicker.CustomFormat = "";
            ReleaseDateSeasonPicker.Location = new Point(117, 16);
            ReleaseDateSeasonPicker.Name = "ReleaseDateSeasonPicker";
            ReleaseDateSeasonPicker.Size = new Size(206, 27);
            ReleaseDateSeasonPicker.TabIndex = 31;
            ReleaseDateSeasonPicker.Value = new DateTime(2024, 5, 26, 0, 0, 0, 0);
            // 
            // PhotoSeason
            // 
            PhotoSeason.Location = new Point(0, 109);
            PhotoSeason.Name = "PhotoSeason";
            PhotoSeason.PlaceholderText = "Type the URL of the Photo";
            PhotoSeason.Size = new Size(323, 27);
            PhotoSeason.TabIndex = 33;
            // 
            // TrailerSeason
            // 
            TrailerSeason.Location = new Point(0, 67);
            TrailerSeason.Name = "TrailerSeason";
            TrailerSeason.PlaceholderText = "Type the URL of the Trailer";
            TrailerSeason.Size = new Size(323, 27);
            TrailerSeason.TabIndex = 32;
            // 
            // confirmButton
            // 
            confirmButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            confirmButton.Location = new Point(445, 39);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(113, 29);
            confirmButton.TabIndex = 21;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Visible = false;
            confirmButton.Click += confirmButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cancelButton.BackColor = Color.Transparent;
            cancelButton.Location = new Point(576, 39);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(113, 29);
            cancelButton.TabIndex = 22;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Visible = false;
            cancelButton.Click += CancelButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(628, 39);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(117, 29);
            DeleteButton.TabIndex = 15;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(505, 39);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(117, 29);
            EditButton.TabIndex = 14;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(avadd);
            groupBox1.Controls.Add(panel1);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(386, 83);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(363, 536);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            // 
            // avadd
            // 
            avadd.Controls.Add(movieRadioDetails);
            avadd.Controls.Add(seriesRadioDetails);
            avadd.Location = new Point(196, 0);
            avadd.Name = "avadd";
            avadd.Size = new Size(167, 49);
            avadd.TabIndex = 14;
            avadd.TabStop = false;
            // 
            // movieRadioDetails
            // 
            movieRadioDetails.AutoSize = true;
            movieRadioDetails.Checked = true;
            movieRadioDetails.Location = new Point(6, 21);
            movieRadioDetails.Name = "movieRadioDetails";
            movieRadioDetails.Size = new Size(77, 24);
            movieRadioDetails.TabIndex = 8;
            movieRadioDetails.TabStop = true;
            movieRadioDetails.Text = "Movies";
            movieRadioDetails.UseVisualStyleBackColor = true;
            movieRadioDetails.CheckedChanged += movieRadioDetails_CheckedChanged;
            // 
            // seriesRadioDetails
            // 
            seriesRadioDetails.AutoSize = true;
            seriesRadioDetails.Location = new Point(92, 21);
            seriesRadioDetails.Name = "seriesRadioDetails";
            seriesRadioDetails.Size = new Size(69, 24);
            seriesRadioDetails.TabIndex = 9;
            seriesRadioDetails.Text = "Series";
            seriesRadioDetails.UseVisualStyleBackColor = true;
            seriesRadioDetails.CheckedChanged += seriesRadioDetails_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(GenresLabel);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(GenresChecked);
            panel1.Controls.Add(RuntimeBox);
            panel1.Controls.Add(StateLabel);
            panel1.Controls.Add(StateComboBox);
            panel1.Controls.Add(FinishDateLabel);
            panel1.Controls.Add(FinishDatePicker);
            panel1.Controls.Add(ReleaseLabel);
            panel1.Controls.Add(ReleaseDatePicker);
            panel1.Controls.Add(PhotoBox);
            panel1.Controls.Add(TrailerBox);
            panel1.Controls.Add(RevenueBox);
            panel1.Controls.Add(BudgetBox);
            panel1.Controls.Add(AgeRateBox);
            panel1.Controls.Add(NameBox);
            panel1.Controls.Add(SynopsisBox);
            panel1.Location = new Point(6, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 479);
            panel1.TabIndex = 14;
            // 
            // GenresLabel
            // 
            GenresLabel.AutoSize = true;
            GenresLabel.Location = new Point(3, 313);
            GenresLabel.Name = "GenresLabel";
            GenresLabel.Size = new Size(59, 20);
            GenresLabel.TabIndex = 31;
            GenresLabel.Text = "Genre : ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(dateTimePicker2);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(domainUpDown1);
            groupBox2.Controls.Add(domainUpDown2);
            groupBox2.Location = new Point(902, 40);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(335, 590);
            groupBox2.TabIndex = 36;
            groupBox2.TabStop = false;
            groupBox2.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 109);
            label8.Name = "label8";
            label8.Size = new Size(107, 20);
            label8.TabIndex = 34;
            label8.Text = "Release Date : ";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "";
            dateTimePicker2.Location = new Point(123, 106);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(206, 27);
            dateTimePicker2.TabIndex = 31;
            dateTimePicker2.Value = new DateTime(2024, 5, 26, 0, 0, 0, 0);
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 199);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Type the URL of the Photo";
            textBox4.Size = new Size(323, 27);
            textBox4.TabIndex = 33;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 157);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Type the URL of the Trailer";
            textBox5.Size = new Size(323, 27);
            textBox5.TabIndex = 32;
            // 
            // domainUpDown1
            // 
            domainUpDown1.Location = new Point(6, 264);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(140, 27);
            domainUpDown1.TabIndex = 1;
            domainUpDown1.Text = "Episode 1";
            // 
            // domainUpDown2
            // 
            domainUpDown2.Location = new Point(6, 26);
            domainUpDown2.Name = "domainUpDown2";
            domainUpDown2.Size = new Size(140, 27);
            domainUpDown2.TabIndex = 0;
            domainUpDown2.Text = "Season 1";
            // 
            // GenresChecked
            // 
            GenresChecked.FormattingEnabled = true;
            GenresChecked.Location = new Point(0, 335);
            GenresChecked.Name = "GenresChecked";
            GenresChecked.Size = new Size(125, 136);
            GenresChecked.TabIndex = 24;
            // 
            // RuntimeBox
            // 
            RuntimeBox.Location = new Point(150, 397);
            RuntimeBox.Name = "RuntimeBox";
            RuntimeBox.PlaceholderText = "Runtime (em minutos)";
            RuntimeBox.Size = new Size(163, 27);
            RuntimeBox.TabIndex = 30;
            RuntimeBox.TextAlign = HorizontalAlignment.Center;
            // 
            // StateLabel
            // 
            StateLabel.AutoSize = true;
            StateLabel.Location = new Point(131, 366);
            StateLabel.Name = "StateLabel";
            StateLabel.Size = new Size(54, 20);
            StateLabel.TabIndex = 29;
            StateLabel.Text = "State : ";
            // 
            // StateComboBox
            // 
            StateComboBox.FormattingEnabled = true;
            StateComboBox.Items.AddRange(new object[] { "Active", "Finished", "Cancelled" });
            StateComboBox.Location = new Point(131, 389);
            StateComboBox.Name = "StateComboBox";
            StateComboBox.Size = new Size(182, 28);
            StateComboBox.TabIndex = 28;
            StateComboBox.SelectedIndexChanged += StateComboBox_SelectedIndexChanged;
            // 
            // FinishDateLabel
            // 
            FinishDateLabel.AutoSize = true;
            FinishDateLabel.Location = new Point(131, 420);
            FinishDateLabel.Name = "FinishDateLabel";
            FinishDateLabel.Size = new Size(93, 20);
            FinishDateLabel.TabIndex = 27;
            FinishDateLabel.Text = "Finish Date : ";
            // 
            // FinishDatePicker
            // 
            FinishDatePicker.CustomFormat = "";
            FinishDatePicker.Location = new Point(131, 443);
            FinishDatePicker.Name = "FinishDatePicker";
            FinishDatePicker.Size = new Size(206, 27);
            FinishDatePicker.TabIndex = 26;
            FinishDatePicker.Value = new DateTime(2024, 5, 26, 0, 0, 0, 0);
            // 
            // ReleaseLabel
            // 
            ReleaseLabel.AutoSize = true;
            ReleaseLabel.Location = new Point(131, 313);
            ReleaseLabel.Name = "ReleaseLabel";
            ReleaseLabel.Size = new Size(107, 20);
            ReleaseLabel.TabIndex = 25;
            ReleaseLabel.Text = "Release Date : ";
            // 
            // ReleaseDatePicker
            // 
            ReleaseDatePicker.CustomFormat = "";
            ReleaseDatePicker.Location = new Point(131, 336);
            ReleaseDatePicker.Name = "ReleaseDatePicker";
            ReleaseDatePicker.Size = new Size(206, 27);
            ReleaseDatePicker.TabIndex = 15;
            ReleaseDatePicker.Value = new DateTime(2024, 5, 26, 0, 0, 0, 0);
            // 
            // PhotoBox
            // 
            PhotoBox.Location = new Point(3, 273);
            PhotoBox.Name = "PhotoBox";
            PhotoBox.PlaceholderText = "Type the URL of the Photo";
            PhotoBox.Size = new Size(334, 27);
            PhotoBox.TabIndex = 24;
            // 
            // TrailerBox
            // 
            TrailerBox.Location = new Point(0, 230);
            TrailerBox.Name = "TrailerBox";
            TrailerBox.PlaceholderText = "Type the URL of the Trailer";
            TrailerBox.Size = new Size(334, 27);
            TrailerBox.TabIndex = 23;
            // 
            // RevenueBox
            // 
            RevenueBox.Location = new Point(177, 181);
            RevenueBox.Name = "RevenueBox";
            RevenueBox.PlaceholderText = "Revenue";
            RevenueBox.Size = new Size(160, 27);
            RevenueBox.TabIndex = 22;
            RevenueBox.TextAlign = HorizontalAlignment.Center;
            // 
            // BudgetBox
            // 
            BudgetBox.Location = new Point(3, 181);
            BudgetBox.Name = "BudgetBox";
            BudgetBox.PlaceholderText = "Budget";
            BudgetBox.Size = new Size(163, 27);
            BudgetBox.TabIndex = 21;
            BudgetBox.TextAlign = HorizontalAlignment.Center;
            // 
            // AgeRateBox
            // 
            AgeRateBox.Controls.Add(ageRate);
            AgeRateBox.Controls.Add(ageRate4);
            AgeRateBox.Controls.Add(ageRate3);
            AgeRateBox.Controls.Add(ageRate2);
            AgeRateBox.Location = new Point(3, 116);
            AgeRateBox.Name = "AgeRateBox";
            AgeRateBox.Size = new Size(334, 58);
            AgeRateBox.TabIndex = 20;
            AgeRateBox.TabStop = false;
            AgeRateBox.Text = "AgeRate";
            // 
            // ageRate
            // 
            ageRate.AutoSize = true;
            ageRate.Checked = true;
            ageRate.Location = new Point(13, 26);
            ageRate.Name = "ageRate";
            ageRate.Size = new Size(38, 24);
            ageRate.TabIndex = 16;
            ageRate.TabStop = true;
            ageRate.Text = "0";
            ageRate.UseVisualStyleBackColor = true;
            // 
            // ageRate4
            // 
            ageRate4.AutoSize = true;
            ageRate4.Location = new Point(264, 26);
            ageRate4.Name = "ageRate4";
            ageRate4.Size = new Size(46, 24);
            ageRate4.TabIndex = 19;
            ageRate4.Text = "18";
            ageRate4.UseVisualStyleBackColor = true;
            // 
            // ageRate3
            // 
            ageRate3.AutoSize = true;
            ageRate3.Location = new Point(181, 26);
            ageRate3.Name = "ageRate3";
            ageRate3.Size = new Size(46, 24);
            ageRate3.TabIndex = 17;
            ageRate3.Text = "15";
            ageRate3.UseVisualStyleBackColor = true;
            // 
            // ageRate2
            // 
            ageRate2.AutoSize = true;
            ageRate2.Location = new Point(88, 26);
            ageRate2.Name = "ageRate2";
            ageRate2.Size = new Size(46, 24);
            ageRate2.TabIndex = 18;
            ageRate2.Text = "12";
            ageRate2.UseVisualStyleBackColor = true;
            // 
            // NameBox
            // 
            NameBox.Location = new Point(3, 6);
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Type the name";
            NameBox.Size = new Size(334, 27);
            NameBox.TabIndex = 13;
            // 
            // SynopsisBox
            // 
            SynopsisBox.Location = new Point(3, 42);
            SynopsisBox.Multiline = true;
            SynopsisBox.Name = "SynopsisBox";
            SynopsisBox.PlaceholderText = "Add a synopsis";
            SynopsisBox.Size = new Size(334, 70);
            SynopsisBox.TabIndex = 15;
            // 
            // typeBox
            // 
            typeBox.Controls.Add(allRadio);
            typeBox.Controls.Add(movieRadio);
            typeBox.Controls.Add(seriesRadio);
            typeBox.Location = new Point(239, 83);
            typeBox.Name = "typeBox";
            typeBox.Size = new Size(99, 118);
            typeBox.TabIndex = 11;
            typeBox.TabStop = false;
            // 
            // allRadio
            // 
            allRadio.AutoSize = true;
            allRadio.Checked = true;
            allRadio.Location = new Point(13, 81);
            allRadio.Name = "allRadio";
            allRadio.Size = new Size(48, 24);
            allRadio.TabIndex = 10;
            allRadio.TabStop = true;
            allRadio.Text = "All";
            allRadio.UseVisualStyleBackColor = true;
            allRadio.CheckedChanged += allRadio_CheckedChanged;
            // 
            // movieRadio
            // 
            movieRadio.AutoSize = true;
            movieRadio.Location = new Point(13, 21);
            movieRadio.Name = "movieRadio";
            movieRadio.Size = new Size(77, 24);
            movieRadio.TabIndex = 8;
            movieRadio.Text = "Movies";
            movieRadio.UseVisualStyleBackColor = true;
            movieRadio.CheckedChanged += movieRadio_CheckedChanged;
            // 
            // seriesRadio
            // 
            seriesRadio.AutoSize = true;
            seriesRadio.Location = new Point(13, 51);
            seriesRadio.Name = "seriesRadio";
            seriesRadio.Size = new Size(69, 24);
            seriesRadio.TabIndex = 9;
            seriesRadio.Text = "Series";
            seriesRadio.UseVisualStyleBackColor = true;
            seriesRadio.CheckedChanged += seriesRadio_CheckedChanged;
            // 
            // AddButton
            // 
            AddButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AddButton.Location = new Point(386, 39);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(113, 29);
            AddButton.TabIndex = 12;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += addButton_Click;
            // 
            // genreComboBox
            // 
            genreComboBox.FormattingEnabled = true;
            genreComboBox.Items.AddRange(new object[] { "All" });
            genreComboBox.Location = new Point(2, 107);
            genreComboBox.Margin = new Padding(2);
            genreComboBox.Name = "genreComboBox";
            genreComboBox.Size = new Size(217, 28);
            genreComboBox.TabIndex = 7;
            genreComboBox.SelectedIndexChanged += genreComboBox_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 82);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(105, 20);
            label6.TabIndex = 6;
            label6.Text = "Filter by Genre";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(2, 147);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 5;
            label5.Text = "Sort By";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(2, 18);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(165, 20);
            label4.TabIndex = 4;
            label4.Text = "Search Movies or Series";
            // 
            // movieOrderBy
            // 
            movieOrderBy.FormattingEnabled = true;
            movieOrderBy.Items.AddRange(new object[] { "Title (A-Z)", "Title (Z-A)", "Release Date (Older to Newer)", "Release Date (Newer to Older)" });
            movieOrderBy.Location = new Point(2, 174);
            movieOrderBy.Margin = new Padding(2);
            movieOrderBy.Name = "movieOrderBy";
            movieOrderBy.Size = new Size(217, 28);
            movieOrderBy.TabIndex = 3;
            movieOrderBy.SelectedIndexChanged += movieOrderBy_SelectedIndexChanged;
            // 
            // searchMoviesBtn
            // 
            searchMoviesBtn.Location = new Point(242, 38);
            searchMoviesBtn.Margin = new Padding(2);
            searchMoviesBtn.Name = "searchMoviesBtn";
            searchMoviesBtn.Size = new Size(99, 29);
            searchMoviesBtn.TabIndex = 2;
            searchMoviesBtn.Text = "Search";
            searchMoviesBtn.UseVisualStyleBackColor = true;
            searchMoviesBtn.Click += searchMoviesBtn_Click;
            // 
            // movieSearchBox
            // 
            movieSearchBox.Location = new Point(2, 40);
            movieSearchBox.Margin = new Padding(2);
            movieSearchBox.Name = "movieSearchBox";
            movieSearchBox.PlaceholderText = "Type a name of a movie/serie";
            movieSearchBox.Size = new Size(217, 27);
            movieSearchBox.TabIndex = 1;
            // 
            // avList
            // 
            avList.FormattingEnabled = true;
            avList.Location = new Point(2, 215);
            avList.Margin = new Padding(2);
            avList.Name = "avList";
            avList.Size = new Size(339, 404);
            avList.TabIndex = 0;
            avList.SelectedIndexChanged += avList_SelectedIndexChanged;
            // 
            // review
            // 
            review.Controls.Add(groupBoxReview);
            review.Controls.Add(UserPassLabel);
            review.Controls.Add(UserEmailLabel);
            review.Controls.Add(ConfirmUserReviews);
            review.Controls.Add(PasswordReview);
            review.Controls.Add(UserEmail);
            review.Controls.Add(overallScoreLabel);
            review.Controls.Add(label3);
            review.Controls.Add(label2);
            review.Controls.Add(label1);
            review.Controls.Add(reviewsList);
            review.Controls.Add(avList2);
            review.Location = new Point(4, 29);
            review.Margin = new Padding(2);
            review.Name = "review";
            review.Padding = new Padding(2);
            review.Size = new Size(1108, 706);
            review.TabIndex = 1;
            review.Text = "Reviews";
            review.UseVisualStyleBackColor = true;
            // 
            // groupBoxReview
            // 
            groupBoxReview.Controls.Add(ReviewCancel);
            groupBoxReview.Controls.Add(ReviewConfirm);
            groupBoxReview.Controls.Add(label7);
            groupBoxReview.Controls.Add(CountLikes);
            groupBoxReview.Controls.Add(ReviewCreatedAtLabel);
            groupBoxReview.Controls.Add(ReviewDelete);
            groupBoxReview.Controls.Add(ReviewCreatedAt);
            groupBoxReview.Controls.Add(ReviewEdit);
            groupBoxReview.Controls.Add(ReviewLike);
            groupBoxReview.Controls.Add(ReviewClassification);
            groupBoxReview.Controls.Add(ReviewDescription);
            groupBoxReview.Controls.Add(ReviewTitle);
            groupBoxReview.Controls.Add(ReviewAdd);
            groupBoxReview.Enabled = false;
            groupBoxReview.Location = new Point(413, 209);
            groupBoxReview.Name = "groupBoxReview";
            groupBoxReview.Size = new Size(624, 407);
            groupBoxReview.TabIndex = 21;
            groupBoxReview.TabStop = false;
            // 
            // ReviewCancel
            // 
            ReviewCancel.Location = new Point(240, 30);
            ReviewCancel.Name = "ReviewCancel";
            ReviewCancel.Size = new Size(121, 39);
            ReviewCancel.TabIndex = 23;
            ReviewCancel.Text = "Cancel";
            ReviewCancel.UseVisualStyleBackColor = true;
            ReviewCancel.Visible = false;
            ReviewCancel.Click += ReviewCancel_Click;
            // 
            // ReviewConfirm
            // 
            ReviewConfirm.Location = new Point(82, 30);
            ReviewConfirm.Name = "ReviewConfirm";
            ReviewConfirm.Size = new Size(121, 39);
            ReviewConfirm.TabIndex = 22;
            ReviewConfirm.Text = "Confirm";
            ReviewConfirm.UseVisualStyleBackColor = true;
            ReviewConfirm.Visible = false;
            ReviewConfirm.Click += ReviewConfirm_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(328, 185);
            label7.Name = "label7";
            label7.Size = new Size(128, 20);
            label7.TabIndex = 21;
            label7.Text = "Number of Likes : ";
            // 
            // CountLikes
            // 
            CountLikes.Enabled = false;
            CountLikes.Location = new Point(462, 180);
            CountLikes.Name = "CountLikes";
            CountLikes.PlaceholderText = "Number of Likes";
            CountLikes.Size = new Size(146, 27);
            CountLikes.TabIndex = 16;
            CountLikes.TextAlign = HorizontalAlignment.Center;
            // 
            // ReviewCreatedAtLabel
            // 
            ReviewCreatedAtLabel.AutoSize = true;
            ReviewCreatedAtLabel.Location = new Point(14, 185);
            ReviewCreatedAtLabel.Name = "ReviewCreatedAtLabel";
            ReviewCreatedAtLabel.Size = new Size(89, 20);
            ReviewCreatedAtLabel.TabIndex = 15;
            ReviewCreatedAtLabel.Text = "Created at : ";
            // 
            // ReviewDelete
            // 
            ReviewDelete.Location = new Point(322, 30);
            ReviewDelete.Name = "ReviewDelete";
            ReviewDelete.Size = new Size(121, 39);
            ReviewDelete.TabIndex = 14;
            ReviewDelete.Text = "Delete";
            ReviewDelete.UseVisualStyleBackColor = true;
            ReviewDelete.Click += ReviewDelete_Click;
            // 
            // ReviewCreatedAt
            // 
            ReviewCreatedAt.Enabled = false;
            ReviewCreatedAt.Location = new Point(111, 180);
            ReviewCreatedAt.Name = "ReviewCreatedAt";
            ReviewCreatedAt.Size = new Size(202, 27);
            ReviewCreatedAt.TabIndex = 13;
            // 
            // ReviewEdit
            // 
            ReviewEdit.Location = new Point(168, 30);
            ReviewEdit.Name = "ReviewEdit";
            ReviewEdit.Size = new Size(121, 39);
            ReviewEdit.TabIndex = 11;
            ReviewEdit.Text = "Edit";
            ReviewEdit.UseVisualStyleBackColor = true;
            ReviewEdit.Click += ReviewEdit_Click;
            // 
            // ReviewLike
            // 
            ReviewLike.BackColor = Color.Transparent;
            ReviewLike.Location = new Point(487, 30);
            ReviewLike.Name = "ReviewLike";
            ReviewLike.Size = new Size(121, 39);
            ReviewLike.TabIndex = 10;
            ReviewLike.Text = "Like";
            ReviewLike.UseVisualStyleBackColor = false;
            ReviewLike.Click += ReviewLike_Click;
            // 
            // ReviewClassification
            // 
            ReviewClassification.Enabled = false;
            ReviewClassification.Location = new Point(462, 110);
            ReviewClassification.Name = "ReviewClassification";
            ReviewClassification.PlaceholderText = "Classification";
            ReviewClassification.Size = new Size(146, 27);
            ReviewClassification.TabIndex = 9;
            ReviewClassification.TextAlign = HorizontalAlignment.Center;
            // 
            // ReviewDescription
            // 
            ReviewDescription.Enabled = false;
            ReviewDescription.Location = new Point(16, 245);
            ReviewDescription.Multiline = true;
            ReviewDescription.Name = "ReviewDescription";
            ReviewDescription.PlaceholderText = "Add a Description";
            ReviewDescription.Size = new Size(592, 146);
            ReviewDescription.TabIndex = 8;
            // 
            // ReviewTitle
            // 
            ReviewTitle.Enabled = false;
            ReviewTitle.Location = new Point(14, 110);
            ReviewTitle.Name = "ReviewTitle";
            ReviewTitle.PlaceholderText = "Type the title";
            ReviewTitle.Size = new Size(377, 27);
            ReviewTitle.TabIndex = 7;
            // 
            // ReviewAdd
            // 
            ReviewAdd.Location = new Point(16, 30);
            ReviewAdd.Name = "ReviewAdd";
            ReviewAdd.Size = new Size(121, 39);
            ReviewAdd.TabIndex = 6;
            ReviewAdd.Text = "Add";
            ReviewAdd.UseVisualStyleBackColor = true;
            ReviewAdd.Click += ReviewAdd_Click;
            // 
            // UserPassLabel
            // 
            UserPassLabel.AutoSize = true;
            UserPassLabel.Location = new Point(429, 92);
            UserPassLabel.Name = "UserPassLabel";
            UserPassLabel.Size = new Size(114, 20);
            UserPassLabel.TabIndex = 20;
            UserPassLabel.Text = "User Password : ";
            // 
            // UserEmailLabel
            // 
            UserEmailLabel.AutoSize = true;
            UserEmailLabel.Location = new Point(429, 43);
            UserEmailLabel.Name = "UserEmailLabel";
            UserEmailLabel.Size = new Size(90, 20);
            UserEmailLabel.TabIndex = 19;
            UserEmailLabel.Text = "User Email : ";
            // 
            // ConfirmUserReviews
            // 
            ConfirmUserReviews.BackColor = Color.Transparent;
            ConfirmUserReviews.Location = new Point(900, 58);
            ConfirmUserReviews.Name = "ConfirmUserReviews";
            ConfirmUserReviews.Size = new Size(121, 39);
            ConfirmUserReviews.TabIndex = 18;
            ConfirmUserReviews.Text = "Confirm";
            ConfirmUserReviews.UseVisualStyleBackColor = false;
            ConfirmUserReviews.Click += ConfirmUserReviews_Click;
            // 
            // PasswordReview
            // 
            PasswordReview.Location = new Point(559, 89);
            PasswordReview.Name = "PasswordReview";
            PasswordReview.PasswordChar = '*';
            PasswordReview.PlaceholderText = "Password";
            PasswordReview.Size = new Size(297, 27);
            PasswordReview.TabIndex = 17;
            // 
            // UserEmail
            // 
            UserEmail.Location = new Point(559, 40);
            UserEmail.Name = "UserEmail";
            UserEmail.PlaceholderText = "User Email";
            UserEmail.Size = new Size(299, 27);
            UserEmail.TabIndex = 12;
            // 
            // overallScoreLabel
            // 
            overallScoreLabel.AutoSize = true;
            overallScoreLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            overallScoreLabel.Location = new Point(717, 156);
            overallScoreLabel.Margin = new Padding(2, 0, 2, 0);
            overallScoreLabel.Name = "overallScoreLabel";
            overallScoreLabel.Size = new Size(57, 20);
            overallScoreLabel.TabIndex = 5;
            overallScoreLabel.Text = "NA/10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(429, 156);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(227, 20);
            label3.TabIndex = 4;
            label3.Text = "Overall Score (based in reviews): ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 336);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 3;
            label2.Text = "List of reviews";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 2;
            label1.Text = "Pick a movie/serie";
            // 
            // reviewsList
            // 
            reviewsList.FormattingEnabled = true;
            reviewsList.Location = new Point(0, 358);
            reviewsList.Margin = new Padding(2);
            reviewsList.Name = "reviewsList";
            reviewsList.Size = new Size(362, 344);
            reviewsList.TabIndex = 1;
            reviewsList.SelectedIndexChanged += reviewsList_SelectedIndexChanged;
            // 
            // avList2
            // 
            avList2.FormattingEnabled = true;
            avList2.Location = new Point(0, 40);
            avList2.Margin = new Padding(2);
            avList2.Name = "avList2";
            avList2.Size = new Size(362, 284);
            avList2.TabIndex = 0;
            avList2.SelectedIndexChanged += avList2_SelectedIndexChanged;
            // 
            // watchlists
            // 
            watchlists.Controls.Add(checkedListBox1);
            watchlists.Controls.Add(Password2Label);
            watchlists.Controls.Add(UserEmail2Label);
            watchlists.Controls.Add(ConfirmAuthetication2);
            watchlists.Controls.Add(PasswordWatchList);
            watchlists.Controls.Add(UserEmail2);
            watchlists.Controls.Add(listBox1);
            watchlists.Controls.Add(CancelWatchList);
            watchlists.Controls.Add(ConfirmWatchList);
            watchlists.Controls.Add(Visibilitygroup);
            watchlists.Controls.Add(DeleteWatchList);
            watchlists.Controls.Add(TitleWatchList);
            watchlists.Controls.Add(CreateWatchList);
            watchlists.Controls.Add(label9);
            watchlists.Controls.Add(PersonalsWatchLists);
            watchlists.Controls.Add(WathListsLabel);
            watchlists.Controls.Add(watchList);
            watchlists.Location = new Point(4, 29);
            watchlists.Margin = new Padding(2);
            watchlists.Name = "watchlists";
            watchlists.Padding = new Padding(2);
            watchlists.Size = new Size(1108, 706);
            watchlists.TabIndex = 2;
            watchlists.Text = "WatchLists";
            watchlists.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(716, 341);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(364, 268);
            checkedListBox1.TabIndex = 28;
            checkedListBox1.Visible = false;
            // 
            // Password2Label
            // 
            Password2Label.AutoSize = true;
            Password2Label.Location = new Point(466, 129);
            Password2Label.Name = "Password2Label";
            Password2Label.Size = new Size(114, 20);
            Password2Label.TabIndex = 26;
            Password2Label.Text = "User Password : ";
            // 
            // UserEmail2Label
            // 
            UserEmail2Label.AutoSize = true;
            UserEmail2Label.Location = new Point(466, 80);
            UserEmail2Label.Name = "UserEmail2Label";
            UserEmail2Label.Size = new Size(90, 20);
            UserEmail2Label.TabIndex = 25;
            UserEmail2Label.Text = "User Email : ";
            // 
            // ConfirmAuthetication2
            // 
            ConfirmAuthetication2.BackColor = Color.Transparent;
            ConfirmAuthetication2.Location = new Point(930, 94);
            ConfirmAuthetication2.Name = "ConfirmAuthetication2";
            ConfirmAuthetication2.Size = new Size(121, 39);
            ConfirmAuthetication2.TabIndex = 24;
            ConfirmAuthetication2.Text = "Confirm";
            ConfirmAuthetication2.UseVisualStyleBackColor = false;
            ConfirmAuthetication2.Click += ConfirmAuthentication2_Click;
            // 
            // PasswordWatchList
            // 
            PasswordWatchList.Location = new Point(596, 126);
            PasswordWatchList.Name = "PasswordWatchList";
            PasswordWatchList.PasswordChar = '*';
            PasswordWatchList.PlaceholderText = "Password";
            PasswordWatchList.Size = new Size(297, 27);
            PasswordWatchList.TabIndex = 23;
            // 
            // UserEmail2
            // 
            UserEmail2.Location = new Point(596, 77);
            UserEmail2.Name = "UserEmail2";
            UserEmail2.PlaceholderText = "User Email";
            UserEmail2.Size = new Size(299, 27);
            UserEmail2.TabIndex = 22;
            // 
            // listBox1
            // 
            listBox1.Enabled = false;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(718, 341);
            listBox1.Margin = new Padding(2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(362, 264);
            listBox1.TabIndex = 21;
            // 
            // CancelWatchList
            // 
            CancelWatchList.Location = new Point(503, 527);
            CancelWatchList.Name = "CancelWatchList";
            CancelWatchList.Size = new Size(94, 29);
            CancelWatchList.TabIndex = 20;
            CancelWatchList.Text = "Cancel";
            CancelWatchList.UseVisualStyleBackColor = true;
            CancelWatchList.Visible = false;
            // 
            // ConfirmWatchList
            // 
            ConfirmWatchList.Location = new Point(503, 412);
            ConfirmWatchList.Name = "ConfirmWatchList";
            ConfirmWatchList.Size = new Size(94, 29);
            ConfirmWatchList.TabIndex = 19;
            ConfirmWatchList.Text = "Confirm";
            ConfirmWatchList.UseVisualStyleBackColor = true;
            ConfirmWatchList.Visible = false;
            // 
            // Visibilitygroup
            // 
            Visibilitygroup.Controls.Add(label10);
            Visibilitygroup.Controls.Add(radioNo);
            Visibilitygroup.Controls.Add(radioYes);
            Visibilitygroup.Enabled = false;
            Visibilitygroup.Location = new Point(718, 263);
            Visibilitygroup.Name = "Visibilitygroup";
            Visibilitygroup.Size = new Size(362, 59);
            Visibilitygroup.TabIndex = 18;
            Visibilitygroup.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(35, 23);
            label10.Name = "label10";
            label10.Size = new Size(64, 20);
            label10.TabIndex = 17;
            label10.Text = "Visible : ";
            // 
            // radioNo
            // 
            radioNo.AutoSize = true;
            radioNo.Location = new Point(255, 21);
            radioNo.Name = "radioNo";
            radioNo.Size = new Size(50, 24);
            radioNo.TabIndex = 15;
            radioNo.TabStop = true;
            radioNo.Text = "No";
            radioNo.UseVisualStyleBackColor = true;
            // 
            // radioYes
            // 
            radioYes.AutoSize = true;
            radioYes.Location = new Point(156, 21);
            radioYes.Name = "radioYes";
            radioYes.Size = new Size(51, 24);
            radioYes.TabIndex = 14;
            radioYes.TabStop = true;
            radioYes.Text = "Yes";
            radioYes.UseVisualStyleBackColor = true;
            // 
            // DeleteWatchList
            // 
            DeleteWatchList.Enabled = false;
            DeleteWatchList.Location = new Point(503, 469);
            DeleteWatchList.Name = "DeleteWatchList";
            DeleteWatchList.Size = new Size(94, 29);
            DeleteWatchList.TabIndex = 12;
            DeleteWatchList.Text = "Delete";
            DeleteWatchList.UseVisualStyleBackColor = true;
            // 
            // TitleWatchList
            // 
            TitleWatchList.Enabled = false;
            TitleWatchList.Location = new Point(718, 238);
            TitleWatchList.Name = "TitleWatchList";
            TitleWatchList.PlaceholderText = "Type the title";
            TitleWatchList.Size = new Size(362, 27);
            TitleWatchList.TabIndex = 11;
            // 
            // CreateWatchList
            // 
            CreateWatchList.Enabled = false;
            CreateWatchList.Location = new Point(503, 358);
            CreateWatchList.Name = "CreateWatchList";
            CreateWatchList.Size = new Size(94, 29);
            CreateWatchList.TabIndex = 10;
            CreateWatchList.Text = "Create";
            CreateWatchList.UseVisualStyleBackColor = true;
            CreateWatchList.Click += CreateWatchList_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(24, 319);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(78, 20);
            label9.TabIndex = 9;
            label9.Text = "WatchLists";
            // 
            // PersonalsWatchLists
            // 
            PersonalsWatchLists.FormattingEnabled = true;
            PersonalsWatchLists.Location = new Point(26, 41);
            PersonalsWatchLists.Margin = new Padding(2);
            PersonalsWatchLists.Name = "PersonalsWatchLists";
            PersonalsWatchLists.Size = new Size(362, 264);
            PersonalsWatchLists.TabIndex = 8;
            PersonalsWatchLists.SelectedIndexChanged += PersonalsWatchLists_SelectedIndexChanged;
            // 
            // WathListsLabel
            // 
            WathListsLabel.AutoSize = true;
            WathListsLabel.Location = new Point(24, 19);
            WathListsLabel.Margin = new Padding(2, 0, 2, 0);
            WathListsLabel.Name = "WathListsLabel";
            WathListsLabel.Size = new Size(78, 20);
            WathListsLabel.TabIndex = 7;
            WathListsLabel.Text = "WatchLists";
            // 
            // watchList
            // 
            watchList.FormattingEnabled = true;
            watchList.Location = new Point(26, 341);
            watchList.Margin = new Padding(2);
            watchList.Name = "watchList";
            watchList.Size = new Size(362, 264);
            watchList.TabIndex = 5;
            watchList.SelectedIndexChanged += watchList_SelectedIndexChanged;
            // 
            // people
            // 
            people.Location = new Point(4, 29);
            people.Margin = new Padding(2);
            people.Name = "people";
            people.Size = new Size(1108, 706);
            people.TabIndex = 3;
            people.Text = "People";
            people.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 659);
            Controls.Add(tabControl1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "MovieAdvisor";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            movies.ResumeLayout(false);
            movies.PerformLayout();
            SeriesGroup.ResumeLayout(false);
            EpisodeGroup.ResumeLayout(false);
            EpisodeGroup.PerformLayout();
            SeasonGroup.ResumeLayout(false);
            SeasonGroup.PerformLayout();
            groupBox1.ResumeLayout(false);
            avadd.ResumeLayout(false);
            avadd.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            AgeRateBox.ResumeLayout(false);
            AgeRateBox.PerformLayout();
            typeBox.ResumeLayout(false);
            typeBox.PerformLayout();
            review.ResumeLayout(false);
            review.PerformLayout();
            groupBoxReview.ResumeLayout(false);
            groupBoxReview.PerformLayout();
            watchlists.ResumeLayout(false);
            watchlists.PerformLayout();
            Visibilitygroup.ResumeLayout(false);
            Visibilitygroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage movies;
        private TabPage review;
        private TabPage watchlists;
        private Button searchMoviesBtn;
        private TextBox movieSearchBox;
        private ListBox avList;
        private ListBox reviewsList;
        private ListBox avList2;
        private Label label2;
        private Label label1;
        private Label overallScoreLabel;
        private Label label3;
        private ComboBox movieOrderBy;
        private Label label5;
        private Label label4;
        private ComboBox genreComboBox;
        private Label label6;
        private TabPage people;
        private RadioButton movieRadio;
        private RadioButton allRadio;
        private RadioButton seriesRadio;
        private GroupBox typeBox;
        private Button AddButton;
        private GroupBox groupBox1;
        private TextBox NameBox;
        private GroupBox avadd;
        private RadioButton movieRadioDetails;
        private RadioButton seriesRadioDetails;
        private Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox SynopsisBox;
        private Button EditButton;
        private RadioButton ageRate;
        private GroupBox AgeRateBox;
        private RadioButton ageRate3;
        private RadioButton ageRate4;
        private RadioButton ageRate2;
        private Button cancelButton;
        private Button confirmButton;
        private Button DeleteButton;
        private TextBox BudgetBox;
        private TextBox TrailerBox;
        private TextBox RevenueBox;
        private TextBox PhotoBox;
        private DateTimePicker ReleaseDatePicker;
        private Label ReleaseLabel;
        private Label FinishDateLabel;
        private DateTimePicker FinishDatePicker;
        private ComboBox StateComboBox;
        private Label StateLabel;
        private TextBox RuntimeBox;
        private GroupBox SeriesGroup;
        private CheckedListBox GenresChecked;
        private Label GenresLabel;
        private Label ReleaseDateSeasonLabel;
        private DateTimePicker ReleaseDateSeasonPicker;
        private TextBox PhotoSeason;
        private TextBox TrailerSeason;
        private TextBox SynopsisEpisode;
        private TextBox RuntimeEpisode;
        private GroupBox groupBox2;
        private Label label8;
        private DateTimePicker dateTimePicker2;
        private TextBox textBox4;
        private TextBox textBox5;
        private DomainUpDown domainUpDown1;
        private DomainUpDown domainUpDown2;
        private Button AddEpisode;
        private Button DeleteEpisode;
        private Button AddSeason;
        private Button DeleteSeason;
        private GroupBox EpisodeGroup;
        private GroupBox SeasonGroup;
        private ComboBox EpisodeBox;
        private ComboBox SeasonBox;
        private Button ConfirmEpisode;
        private Button CancelEpisode;
        private Button ConfirmSeason;
        private Button CancelSeason;
        private Button ReviewAdd;
        private TextBox ReviewTitle;
        private TextBox ReviewDescription;
        private TextBox ReviewClassification;
        private Button ReviewEdit;
        private Button ReviewLike;
        private TextBox UserEmail;
        private DateTimePicker ReviewCreatedAt;
        private Button ReviewDelete;
        private Label ReviewCreatedAtLabel;
        private TextBox CountLikes;
        private TextBox PasswordReview;
        private Label UserPassLabel;
        private Label UserEmailLabel;
        private Button ConfirmUserReviews;
        private GroupBox groupBoxReview;
        private Label label7;
        private Button ReviewCancel;
        private Button ReviewConfirm;
        private Label WathListsLabel;
        private ListBox watchList;
        private Label label9;
        private ListBox PersonalsWatchLists;
        private Button CreateWatchList;
        private TextBox TitleWatchList;
        private Button DeleteWatchList;
        private RadioButton radioNo;
        private RadioButton radioYes;
        private GroupBox Visibilitygroup;
        private Label label10;
        private Button CancelWatchList;
        private Button ConfirmWatchList;
        private Label Password2Label;
        private Label UserEmail2Label;
        private Button ConfirmAuthetication2;
        private TextBox PasswordWatchList;
        private TextBox UserEmail2;
        private CheckedListBox checkedListBox1;
        private ListBox listBox1;
    }
}
