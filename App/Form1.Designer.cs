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
            tabControl1.SuspendLayout();
            movies.SuspendLayout();
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
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1814, 1182);
            tabControl1.TabIndex = 0;
            // 
            // movies
            // 
            movies.Controls.Add(genreComboBox);
            movies.Controls.Add(label6);
            movies.Controls.Add(label5);
            movies.Controls.Add(label4);
            movies.Controls.Add(movieOrderBy);
            movies.Controls.Add(searchMoviesBtn);
            movies.Controls.Add(movieSearchBox);
            movies.Controls.Add(avList);
            movies.Location = new Point(8, 46);
            movies.Name = "movies";
            movies.Padding = new Padding(3);
            movies.Size = new Size(1798, 1128);
            movies.TabIndex = 0;
            movies.Text = "Movies/Series";
            movies.UseVisualStyleBackColor = true;
            // 
            // genreComboBox
            // 
            genreComboBox.FormattingEnabled = true;
            genreComboBox.Items.AddRange(new object[] { "All" });
            genreComboBox.Location = new Point(276, 192);
            genreComboBox.Name = "genreComboBox";
            genreComboBox.Size = new Size(240, 40);
            genreComboBox.TabIndex = 7;
            genreComboBox.SelectedIndexChanged += genreComboBox_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(276, 157);
            label6.Name = "label6";
            label6.Size = new Size(171, 32);
            label6.TabIndex = 6;
            label6.Text = "Filter by Genre";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 157);
            label5.Name = "label5";
            label5.Size = new Size(90, 32);
            label5.TabIndex = 5;
            label5.Text = "Sort By";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 48);
            label4.Name = "label4";
            label4.Size = new Size(268, 32);
            label4.TabIndex = 4;
            label4.Text = "Search Movies or Series";
            // 
            // movieOrderBy
            // 
            movieOrderBy.FormattingEnabled = true;
            movieOrderBy.Items.AddRange(new object[] { "Title", "Popularity", "Release Date" });
            movieOrderBy.Location = new Point(0, 192);
            movieOrderBy.Name = "movieOrderBy";
            movieOrderBy.Size = new Size(240, 40);
            movieOrderBy.TabIndex = 3;
            movieOrderBy.SelectedIndexChanged += movieOrderBy_SelectedIndexChanged;
            // 
            // searchMoviesBtn
            // 
            searchMoviesBtn.Location = new Point(498, 79);
            searchMoviesBtn.Name = "searchMoviesBtn";
            searchMoviesBtn.Size = new Size(150, 46);
            searchMoviesBtn.TabIndex = 2;
            searchMoviesBtn.Text = "Search";
            searchMoviesBtn.UseVisualStyleBackColor = true;
            searchMoviesBtn.Click += searchMoviesBtn_Click;
            // 
            // movieSearchBox
            // 
            movieSearchBox.Location = new Point(3, 83);
            movieSearchBox.Name = "movieSearchBox";
            movieSearchBox.PlaceholderText = "Type a name of a movie/serie";
            movieSearchBox.Size = new Size(444, 39);
            movieSearchBox.TabIndex = 1;
            // 
            // avList
            // 
            avList.FormattingEnabled = true;
            avList.Location = new Point(3, 286);
            avList.Name = "avList";
            avList.Size = new Size(648, 836);
            avList.TabIndex = 0;
            // 
            // review
            // 
            review.Controls.Add(overallScoreLabel);
            review.Controls.Add(label3);
            review.Controls.Add(label2);
            review.Controls.Add(label1);
            review.Controls.Add(reviewsList);
            review.Controls.Add(avList2);
            review.Location = new Point(8, 46);
            review.Name = "review";
            review.Padding = new Padding(3);
            review.Size = new Size(1798, 1128);
            review.TabIndex = 1;
            review.Text = "Reviews";
            review.UseVisualStyleBackColor = true;
            // 
            // overallScoreLabel
            // 
            overallScoreLabel.AutoSize = true;
            overallScoreLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            overallScoreLabel.Location = new Point(1070, 76);
            overallScoreLabel.Name = "overallScoreLabel";
            overallScoreLabel.Size = new Size(89, 32);
            overallScoreLabel.TabIndex = 5;
            overallScoreLabel.Text = "NA/10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(700, 74);
            label3.Name = "label3";
            label3.Size = new Size(364, 32);
            label3.TabIndex = 4;
            label3.Text = "Overall Score (based in reviews): ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 537);
            label2.Name = "label2";
            label2.Size = new Size(164, 32);
            label2.TabIndex = 3;
            label2.Text = "List of reviews";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 29);
            label1.Name = "label1";
            label1.Size = new Size(207, 32);
            label1.TabIndex = 2;
            label1.Text = "Pick a movie/serie";
            // 
            // reviewsList
            // 
            reviewsList.FormattingEnabled = true;
            reviewsList.Location = new Point(0, 572);
            reviewsList.Name = "reviewsList";
            reviewsList.Size = new Size(586, 548);
            reviewsList.TabIndex = 1;
            // 
            // avList2
            // 
            avList2.FormattingEnabled = true;
            avList2.Location = new Point(0, 64);
            avList2.Name = "avList2";
            avList2.Size = new Size(586, 452);
            avList2.TabIndex = 0;
            avList2.SelectedIndexChanged += avList2_SelectedIndexChanged;
            // 
            // watchlists
            // 
            watchlists.Location = new Point(8, 46);
            watchlists.Name = "watchlists";
            watchlists.Padding = new Padding(3);
            watchlists.Size = new Size(1798, 1128);
            watchlists.TabIndex = 2;
            watchlists.Text = "WatchLists";
            watchlists.UseVisualStyleBackColor = true;
            // 
            // people
            // 
            people.Location = new Point(8, 46);
            people.Name = "people";
            people.Size = new Size(1798, 1128);
            people.TabIndex = 3;
            people.Text = "People";
            people.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1814, 1180);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "MovieAdvisor";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            movies.ResumeLayout(false);
            movies.PerformLayout();
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
    }
}
