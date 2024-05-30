using System.Data.SqlClient;


namespace MovieAdvisor
{
    internal class User
    {
        public static User FromReader(SqlDataReader reader)
        {
            User u = new User();

            u.ID = reader["ID"].ToString();
            u.Email = reader["Email"].ToString();
            u.Password = reader["Password"].ToString();
            u.CreatedAt = reader["CreatedAt"].ToString();
            u.IsAdmin = reader["IsAdmin"].ToString();

            return u;
        }

        private String _id;
        private String _email;
        private String _password;
        private String _createdat;
        private String _isadmin;

        public String ID { get => _id; set => _id = value; }
        public String Email { get => _email; set => _email = value; }
        public String Password { get => _password; set => _password = value; }
        public String CreatedAt { get => _createdat; set => _createdat = value; }
        public String IsAdmin { get => _isadmin; set => _isadmin = value; }

    }
}
    