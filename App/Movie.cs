using System.Data.SqlClient;

namespace MovieAdvisor
{
    internal class Movie : AudiovisualContent
    {
        public static Movie FromReader(SqlDataReader reader)
        {
            Movie m = new Movie();

            m.ID = reader["ID"].ToString();
            m.Title = reader["Title"].ToString();
            m.Synopsis = reader["Synopsis"].ToString();
            m.TrailerURL = reader["TrailerURL"].ToString();
            m.Budget = reader["Budget"].ToString();
            m.Revenue = reader["Revenue"].ToString();
            m.Photo = reader["Photo"].ToString();
            m.AgeRate = reader["AgeRate"].ToString();
            m.ReleaseDate = reader["ReleaseDate"].ToString();
            m.Runtime = reader["Runtime"].ToString();

            return m;
        }

        private String _id;
        private String _runtime;

        public String Id { get => _id; set => _id = value; }
        public String Runtime { get => _runtime; set => _runtime = value; }
    }
}
