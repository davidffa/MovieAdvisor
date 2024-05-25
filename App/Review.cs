using System.Data.SqlClient;

namespace MovieAdvisor
{
    internal class Review
    {
        public static Review FromReader(SqlDataReader reader)
        {
            Review r = new Review();

            r.Id = reader["Id"].ToString();
            r.UserID = reader["UserID"].ToString();
            r.AvIdentifier = reader["AvIdentifier"].ToString();
            r.Title = reader["Title"].ToString();
            r.Description = reader["Description"].ToString();
            r.Classification = reader["Classification"].ToString();
            r.CreatedAt = reader["CreatedAt"].ToString();
            return r;
        }

        private String _id;
		private String _userID;
		private String _avIdentifier;
		private String _title;
		private String _description;
		private String _classification;
		private String _createdAt;

		public String Id { get => _id; set => _id = value; }
		public String UserID { get => _userID; set => _userID = value; }
		public String AvIdentifier { get => _avIdentifier; set => _avIdentifier = value; }
		public String Title { get => _title; set => _title = value; }
		public String Description { get => _description; set => _description = value; }
		public String Classification { get => _classification; set => _classification = value; }
		public String CreatedAt { get => _createdAt; set => _createdAt = value; }

        public override string ToString()
        {
            return Title;
        }
    }
}
