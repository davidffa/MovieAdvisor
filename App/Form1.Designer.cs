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
            review = new TabPage();
            watchlists = new TabPage();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(movies);
            tabControl1.Controls.Add(review);
            tabControl1.Controls.Add(watchlists);
            tabControl1.Location = new Point(1, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1572, 956);
            tabControl1.TabIndex = 0;
            // 
            // movies
            // 
            movies.Location = new Point(8, 46);
            movies.Name = "movies";
            movies.Padding = new Padding(3);
            movies.Size = new Size(1556, 902);
            movies.TabIndex = 0;
            movies.Text = "Filmes";
            movies.UseVisualStyleBackColor = true;
            // 
            // review
            // 
            review.Location = new Point(8, 46);
            review.Name = "review";
            review.Padding = new Padding(3);
            review.Size = new Size(1556, 902);
            review.TabIndex = 1;
            review.Text = "Reviews";
            review.UseVisualStyleBackColor = true;
            // 
            // watchlists
            // 
            watchlists.Location = new Point(8, 46);
            watchlists.Name = "watchlists";
            watchlists.Padding = new Padding(3);
            watchlists.Size = new Size(1556, 902);
            watchlists.TabIndex = 2;
            watchlists.Text = "WatchLists";
            watchlists.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1568, 956);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "MovieAdvisor";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage movies;
        private TabPage review;
        private TabPage watchlists;
    }
}
