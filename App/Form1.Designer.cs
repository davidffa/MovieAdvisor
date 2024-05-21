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
            DeleteButton = new Button();
            EditButton = new Button();
            groupBox1 = new GroupBox();
            cancelButton = new Button();
            confirmButton = new Button();
            avadd = new GroupBox();
            movieRadioDetails = new RadioButton();
            seriesRadioDetails = new RadioButton();
            panel1 = new Panel();
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
            overallScoreLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            reviewsList = new ListBox();
            avList2 = new ListBox();
            watchlists = new TabPage();
            people = new TabPage();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tabControl1.SuspendLayout();
            movies.SuspendLayout();
            groupBox1.SuspendLayout();
            avadd.SuspendLayout();
            panel1.SuspendLayout();
            AgeRateBox.SuspendLayout();
            typeBox.SuspendLayout();
            review.SuspendLayout();
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
            // DeleteButton
            // 
            DeleteButton.Location = new Point(766, 40);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(117, 29);
            DeleteButton.TabIndex = 15;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(617, 40);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(117, 29);
            EditButton.TabIndex = 14;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cancelButton);
            groupBox1.Controls.Add(confirmButton);
            groupBox1.Controls.Add(avadd);
            groupBox1.Controls.Add(panel1);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(455, 104);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(434, 514);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            // 
            // cancelButton
            // 
            cancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cancelButton.BackColor = Color.Transparent;
            cancelButton.Location = new Point(237, 467);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(113, 29);
            cancelButton.TabIndex = 22;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Visible = false;
            cancelButton.Click += CancelButton_Click;
            // 
            // confirmButton
            // 
            confirmButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            confirmButton.Enabled = false;
            confirmButton.Location = new Point(75, 467);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(113, 29);
            confirmButton.TabIndex = 21;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Visible = false;
            confirmButton.Click += confirmButton_Click;
            // 
            // avadd
            // 
            avadd.Controls.Add(movieRadioDetails);
            avadd.Controls.Add(seriesRadioDetails);
            avadd.Location = new Point(267, 0);
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
            // 
            // seriesRadioDetails
            // 
            seriesRadioDetails.AutoSize = true;
            seriesRadioDetails.Location = new Point(96, 20);
            seriesRadioDetails.Name = "seriesRadioDetails";
            seriesRadioDetails.Size = new Size(69, 24);
            seriesRadioDetails.TabIndex = 9;
            seriesRadioDetails.Text = "Series";
            seriesRadioDetails.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(AgeRateBox);
            panel1.Controls.Add(NameBox);
            panel1.Controls.Add(SynopsisBox);
            panel1.Location = new Point(6, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(422, 388);
            panel1.TabIndex = 14;
            // 
            // AgeRateBox
            // 
            AgeRateBox.Controls.Add(ageRate);
            AgeRateBox.Controls.Add(ageRate4);
            AgeRateBox.Controls.Add(ageRate3);
            AgeRateBox.Controls.Add(ageRate2);
            AgeRateBox.Location = new Point(3, 115);
            AgeRateBox.Name = "AgeRateBox";
            AgeRateBox.Size = new Size(400, 69);
            AgeRateBox.TabIndex = 20;
            AgeRateBox.TabStop = false;
            AgeRateBox.Text = "AgeRate";
            // 
            // ageRate
            // 
            ageRate.AutoSize = true;
            ageRate.Checked = true;
            ageRate.Location = new Point(40, 26);
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
            ageRate4.Location = new Point(320, 26);
            ageRate4.Name = "ageRate4";
            ageRate4.Size = new Size(46, 24);
            ageRate4.TabIndex = 19;
            ageRate4.Text = "18";
            ageRate4.UseVisualStyleBackColor = true;
            // 
            // ageRate3
            // 
            ageRate3.AutoSize = true;
            ageRate3.Location = new Point(224, 26);
            ageRate3.Name = "ageRate3";
            ageRate3.Size = new Size(46, 24);
            ageRate3.TabIndex = 17;
            ageRate3.Text = "15";
            ageRate3.UseVisualStyleBackColor = true;
            // 
            // ageRate2
            // 
            ageRate2.AutoSize = true;
            ageRate2.Location = new Point(123, 26);
            ageRate2.Name = "ageRate2";
            ageRate2.Size = new Size(46, 24);
            ageRate2.TabIndex = 18;
            ageRate2.Text = "12";
            ageRate2.UseVisualStyleBackColor = true;
            ageRate2.CheckedChanged += ageRate2_CheckedChanged;
            // 
            // NameBox
            // 
            NameBox.Location = new Point(3, 10);
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Type the name";
            NameBox.Size = new Size(400, 27);
            NameBox.TabIndex = 13;
            // 
            // SynopsisBox
            // 
            SynopsisBox.Location = new Point(3, 41);
            SynopsisBox.Multiline = true;
            SynopsisBox.Name = "SynopsisBox";
            SynopsisBox.PlaceholderText = "Add a synopsis";
            SynopsisBox.Size = new Size(400, 70);
            SynopsisBox.TabIndex = 15;
            SynopsisBox.TextChanged += SynopsisBox_TextChanged;
            // 
            // typeBox
            // 
            typeBox.Controls.Add(allRadio);
            typeBox.Controls.Add(movieRadio);
            typeBox.Controls.Add(seriesRadio);
            typeBox.Location = new Point(303, 83);
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
            AddButton.Location = new Point(464, 38);
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
            genreComboBox.Size = new Size(149, 28);
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
            movieOrderBy.Items.AddRange(new object[] { "Title", "Popularity", "Release Date" });
            movieOrderBy.Location = new Point(2, 174);
            movieOrderBy.Margin = new Padding(2);
            movieOrderBy.Name = "movieOrderBy";
            movieOrderBy.Size = new Size(149, 28);
            movieOrderBy.TabIndex = 3;
            movieOrderBy.SelectedIndexChanged += movieOrderBy_SelectedIndexChanged;
            // 
            // searchMoviesBtn
            // 
            searchMoviesBtn.Location = new Point(303, 38);
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
            movieSearchBox.Size = new Size(275, 27);
            movieSearchBox.TabIndex = 1;
            // 
            // avList
            // 
            avList.FormattingEnabled = true;
            avList.Location = new Point(2, 215);
            avList.Margin = new Padding(2);
            avList.Name = "avList";
            avList.Size = new Size(400, 404);
            avList.TabIndex = 0;
            avList.SelectedIndexChanged += avList_SelectedIndexChanged;
            // 
            // review
            // 
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
            // overallScoreLabel
            // 
            overallScoreLabel.AutoSize = true;
            overallScoreLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            overallScoreLabel.Location = new Point(658, 48);
            overallScoreLabel.Margin = new Padding(2, 0, 2, 0);
            overallScoreLabel.Name = "overallScoreLabel";
            overallScoreLabel.Size = new Size(57, 20);
            overallScoreLabel.TabIndex = 5;
            overallScoreLabel.Text = "NA/10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(431, 46);
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
            watchlists.Location = new Point(4, 29);
            watchlists.Margin = new Padding(2);
            watchlists.Name = "watchlists";
            watchlists.Padding = new Padding(2);
            watchlists.Size = new Size(1108, 706);
            watchlists.TabIndex = 2;
            watchlists.Text = "WatchLists";
            watchlists.UseVisualStyleBackColor = true;
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
            groupBox1.ResumeLayout(false);
            avadd.ResumeLayout(false);
            avadd.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            AgeRateBox.ResumeLayout(false);
            AgeRateBox.PerformLayout();
            typeBox.ResumeLayout(false);
            typeBox.PerformLayout();
            review.ResumeLayout(false);
            review.PerformLayout();
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
    }
}
