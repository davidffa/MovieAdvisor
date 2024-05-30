using System.Data.SqlClient;

namespace MovieAdvisor
{
    internal class AudiovisualContent
    {
        public static AudiovisualContent FromReader(SqlDataReader reader)
        {
            AudiovisualContent m = new AudiovisualContent();

            m.ID = reader["ID"].ToString();
            m.Title = reader["Title"].ToString();
            m.Synopsis = reader["Synopsis"].ToString();
            m.TrailerURL = reader["TrailerURL"].ToString();
            m.Budget = reader["Budget"].ToString();
            m.Revenue = reader["Revenue"].ToString();
            m.Photo = reader["Photo"].ToString();
            m.AgeRate = reader["AgeRate"].ToString();
            m.ReleaseDate = reader["ReleaseDate"].ToString();

            return m;
        }

        private String _id;
        private String _title;
        private String _synopsis;
        private String _popularity;
        private String _trailerURL;
        private String _budget;
        private String _revenue;
        private String _photo;
        private String _ageRate;
        private String _releaseDate;

        public String ID { get => _id; set => _id = value; }
        public String Title { get => _title; set => _title = value; }
        public String Synopsis { get => _synopsis; set => _synopsis = value; }
        public String Popularity { get => _popularity; set => _popularity = value; }
        public String TrailerURL { get => _trailerURL; set => _trailerURL = value; }
        public String Budget { get => _budget; set => _budget = value.Split(",")[0]; }
        public String Revenue { get => _revenue; set => _revenue = value.Split(",")[0]; }
        public String Photo { get => _photo; set => _photo = value; }
        public String AgeRate { get => _ageRate; set => _ageRate = value; }
        public String ReleaseDate { get => _releaseDate; set => _releaseDate = value; }

        public override string ToString()
        {
            return Title;
        }
    }
}
